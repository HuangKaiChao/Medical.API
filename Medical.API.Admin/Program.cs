// 注意：添加必要的 using 引用（静态文件相关）
using IGeekFan.AspNetCore.Knife4jUI;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.IOC;
using Medical.Infrastructure.SignalR;
using Medical.Repository.Instance;
using Medical.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.StaticFiles; // 新增：静态文件MIME类型支持
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders; // 新增：文件提供器
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.IO; // 新增：IO操作

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:5123"); //指定运行端口 并允许外网访问

////数据库配置
builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    var serverVersion = ServerVersion.Parse("8.0.30");

    options.UseMySql(connectionString, serverVersion);
});

//默认仓储注入
builder.Services.AddScoped(typeof(I_Repository<>), typeof(MySql_Repository<>));
//数据库仓储注入
builder.Services.AddScoped<DbContext, MyDbContext>();
//获取IP注入
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//控制器支持
builder.Services.AddControllers();
//SignalR服务
builder.Services.AddSignalR();
//注册服务
builder.Services.AddScoped(Assembly.Load("Medical.Service.Interface"), Assembly.Load("Medical.Service.Instance"));
builder.Services.AddScoped(Assembly.Load("Medical.Service.EFCore"), Assembly.Load("Medical.Service.EFCore"));
builder.Services.AddScoped(Assembly.Load("Medical.Infrastructure.Redis"), Assembly.Load("Medical.Infrastructure.Redis"));
//builder.Services.AddScoped(Assembly.Load("Medical.Infrastructure.Rabbit"), Assembly.Load("Medical.Infrastructure.Rabbit"));
builder.Services.AddScoped(Assembly.Load("Medical.Infrastructure.IOC"), Assembly.Load("Medical.Infrastructure.IOC"));
builder.Services.AddScoped(Assembly.Load("Medical.Infrastructure.SIgnalR"), Assembly.Load("Medical.Infrastructure.SIgnalR"));
//builder.Services.AddScoped(Assembly.Load("Medical.Infrastructure.Global"), Assembly.Load("Medical.Infrastructure.Global"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var provider = builder.Services.BuildServiceProvider();//手动注入

#region JWT Auth
string jwtKey = builder.Configuration["JWT:issuer"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,//是否验证Issuer
         ValidateAudience = true,//是否验证Audience
         ValidateLifetime = true,//是否验证失效时间
         ValidateIssuerSigningKey = true,//是否验证SecurityKey
         ValidAudience = jwtKey,//Audience
         ValidIssuer = jwtKey,//Issuer，这两项和后面签发jwt的设置一致
                              //ClockSkew = TimeSpan.Zero, // // 默认允许 300s  的时间偏移量，设置为0
         ClockSkew = TimeSpan.FromSeconds(60),
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]))//拿到SecurityKey
     };
     options.Events = new JwtBearerEvents
     {
         //自定义验证规则
         OnMessageReceived = context =>
         {
             string url = context.Request.Path;
             //用户登录验证
             if (url.ToLower() == "/api/org/check_login") //只有check_login接口做多端验证
             {
                 if (!StringValues.IsNullOrEmpty(context.Request.Headers["Authorization"]))
                 {
                     try
                     {
                         //todo 验证多app登陆
                         var startLength = "Bearer ".Length;
                         var tokenStr = context.Request.Headers["Authorization"].ToString();
                         //验证权限
                         var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenStr.Substring(startLength, tokenStr.Length - startLength));
                         //得到保存的code 验证code是否过期
                         string code = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
                         string account = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Actor).Value.ToString();
                         var _login_service = provider.GetService<Medical.Service.Interface.Admin.Service.I_Org_Service>();//必须不能new对象 一定要注入对象

                         if (_login_service!.Check_Login(code, account) == null)
                         {
                             context.Request.Headers["Authorization"] = string.Empty;
                         }
                     }
                     catch (System.Exception ex)
                     {
                         Console.WriteLine(ex.Message);
                         context.Request.Headers["Authorization"] = string.Empty;
                     }
                 }
             }

             ////客户登录验证
             //if (url.ToLower() == "/api/customer/check_login") //只有check_login接口做多端验证
             //{
             //    if (!StringValues.IsNullOrEmpty(context.Request.Headers["Authorization"]))
             //    {
             //        try
             //        {
             //            //todo 验证多app登陆
             //            var startLength = "Bearer ".Length;
             //            var tokenStr = context.Request.Headers["Authorization"].ToString();
             //            //验证权限
             //            var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenStr.Substring(startLength, tokenStr.Length - startLength));
             //            //得到保存的code 验证code是否过期
             //            string code = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Name).Value.ToString();
             //            string account = token.Claims.ToList().First(o => o.Type == System.Security.Claims.ClaimTypes.Actor).Value.ToString();
             //            var _login_service = provider.GetService<I_Customers_Service>();//必须不能new对象 一定要注入对象

             //            if (_login_service!.Check_Login(code, account) == null)
             //            {
             //                context.Request.Headers["Authorization"] = string.Empty;
             //            }
             //        }
             //        catch (System.Exception ex)
             //        {
             //            Console.WriteLine(ex.Message);
             //            context.Request.Headers["Authorization"] = string.Empty;
             //        }
             //    }
             //}
             return Task.CompletedTask;
         }
     };
 });
#endregion

//添加Swagger文档
#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "HKC.中医理疗.Api",
            Version = "v1.0",
            Contact = new OpenApiContact()
            {
                Name = "HKC",
                Email = "3181238912@qq.com",
                Url = new Uri("https://www.cnblogs.com/zhoujieyu")
            },
            Description = "HKC·中医理疗.接口文档",
            License = new OpenApiLicense
            {
                Name = "Author：zhoujieyu",
                Url = new Uri("https://www.cnblogs.com/zhoujieyu")
            }
        });
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Medical.Api.Admin.xml"), true);
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Medical.Infrastructure.Dto.xml"), true);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格,正确格式为 Bearer+空格+Token）\"",
        Name = "Authorization", //jwt默认的参数名称
        In = ParameterLocation.Header, //jwt默认存放Authorization信息的位置(请求头中)
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference() { Id = "Bearer", Type = ReferenceType.SecurityScheme }
            },
            Array.Empty<string>()
        }
    });
});
#endregion

#region 全局过滤器注入
builder.Services.AddControllers(options =>
{
    //options.Filters.Add(typeof(Action_Filter));//行为日志过滤器注入
    //options.Filters.Add(typeof(Result_Filter));//结果过滤器注入
});
#endregion

builder.Services.AddSwaggerGen();

#region Cors跨域配置
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllRequests", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173"
            )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials(); // 新增：允许携带凭证（比如cookie、头像访问授权）
    });
});
#endregion

var app = builder.Build();

// 配置SignalR端点
app.MapHub<NotificationHub>("/notificationHub");

// 启动时立即执行一次解锁检查
using (var scope = app.Services.CreateScope())
{
    //var backgroundService = scope.ServiceProvider.GetRequiredService<I_Background_Service>();
    //await backgroundService.StartAsync();
}

// ========== 核心配置：静态文件访问（头像文件） ==========
// 1. 启用默认的 wwwroot 静态文件目录
app.UseStaticFiles();

// 2. 配置 Files 目录的静态文件访问（支持头像等文件）
var filesPath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "Files");
// 确保目录存在（防止启动时目录不存在报错）
if (!Directory.Exists(filesPath))
{
    Directory.CreateDirectory(filesPath);
}

// 配置静态文件访问规则
app.UseStaticFiles(new StaticFileOptions
{
    // 指定文件存储的物理路径
    FileProvider = new PhysicalFileProvider(filesPath),
    // 访问路径前缀（前端访问：http://服务器IP:5123/Files/xxx.png）
    RequestPath = "/Files",
    // 支持更多图片格式的MIME类型（防止图片访问时404/下载）
    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings =
        {
            [".png"] = "image/png",
            [".jpg"] = "image/jpeg",
            [".jpeg"] = "image/jpeg",
            [".gif"] = "image/gif",
            [".bmp"] = "image/bmp",
            [".webp"] = "image/webp"
        }
    },
    // 允许浏览目录（可选，生产环境建议关闭）
    ServeUnknownFileTypes = true,
    // 缓存配置（优化图片加载性能）
    OnPrepareResponse = ctx =>
    {
        // 设置缓存时间为7天（减少重复请求）
        ctx.Context.Response.Headers.Append(
            "Cache-Control", "public, max-age=604800");
    }
});

// ========== 静态文件配置结束 ==========

// 启动时佣金检查
//_ = Task.Run(async () =>
//{
//    using var scope = app.Services.CreateScope();
//    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//    try
//    {
//        logger.LogInformation("开始启动时佣金检查...");
//        var commissionService = scope.ServiceProvider.GetRequiredService<I_Commission_Service>();
//        await commissionService.ProcessCompletedOrdersForCommissions();
//        logger.LogInformation("启动时佣金检查完成");
//    }
//    catch (Exception ex)
//    {
//        logger.LogError(ex, "启动时佣金检查失败");
//    }
//});

//app.UseMiddleware<Exception_Middle>();//全局异常处理
app.UseCors("AllRequests"); //开启Cors跨域请求中间件

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//身份验证中间件
app.UseAuthentication(); //前
app.UseAuthorization(); //后

//接口文档
app.UseKnife4UI(d =>
{
    d.RoutePrefix = String.Empty;
    d.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); //Endpoint 终端中间件
});

//允许重复读取参数
app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next(context);
});

//路由映射
app.MapControllers(); //这一行以映射控制器路由

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5)
        .Select(index => new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55), summaries[Random.Shared.Next(summaries.Length)]))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}