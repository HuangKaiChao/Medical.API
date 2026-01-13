using System.Reflection;
using Medical.Infrastructure.Attr;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Infrastructure.IOC;

/// <summary>
/// 自动注入帮助类
/// </summary>
public static class Inject_Help
{
    /// <summary>
    /// 自动注入
    /// </summary>
    /// <param name="services"></param>
    /// <param name="providers"></param>
    /// <param name="injects"></param>
    public static void AddScoped(this IServiceCollection services, Assembly providers, Assembly injects)
    {
        var prs = providers.GetTypes()
            .Where(d=>d.GetCustomAttribute(typeof(Provider_Attribute))!=null).ToList();

        var ins = injects.GetTypes().Where(d => d.GetCustomAttribute(typeof(Inject_Attribute)) != null).ToList();

        prs.ForEach(d =>
        {
            //IsAssignableFrom 判断一个类是否是另一个类的子类(符合里氏替换原则的子类)
            var list = ins.Where(e => d.IsAssignableFrom(e)).ToList();
            list.ForEach(e =>
            {
                services.AddScoped(d,e);//使用原方法注入
            });
        });
    }
    /// <summary>
    /// 自动注入
    /// </summary>
    /// <param name="services"></param>
    /// <param name="providers"></param>
    /// <param name="injects"></param>
    public static void AddTransient(this IServiceCollection services, Assembly providers, Assembly injects)
    {
        var prs = providers.GetTypes()
            .Where(d=>d.GetCustomAttribute(typeof(Provider_Attribute))!=null).ToList();

        var ins = injects.GetTypes().Where(d => d.GetCustomAttribute(typeof(Inject_Attribute)) != null).ToList();

        prs.ForEach(d =>
        {
            //IsAssignableFrom 判断一个类是否是另一个类的子类(符合里氏替换原则的子类)
            var list = ins.Where(e => d.IsAssignableFrom(e)).ToList();
            list.ForEach(e =>
            {
                services.AddScoped(d,e);//使用原方法注入
            });
        });
    }
    /// <summary>
    /// 自动注入
    /// </summary>
    /// <param name="services"></param>
    /// <param name="providers"></param>
    /// <param name="injects"></param>
    public static void AddSingleton(this IServiceCollection services, Assembly providers, Assembly injects)
    {
        var prs = providers.GetTypes()
            .Where(d=>d.GetCustomAttribute(typeof(Provider_Attribute))!=null).ToList();

        var ins = injects.GetTypes().Where(d => d.GetCustomAttribute(typeof(Inject_Attribute)) != null).ToList();

        prs.ForEach(d =>
        {
            //IsAssignableFrom 判断一个类是否是另一个类的子类(符合里氏替换原则的子类)
            var list = ins.Where(e => d.IsAssignableFrom(e)).ToList();
            list.ForEach(e =>
            {
                services.AddScoped(d,e);//使用原方法注入
            });
        });
    }
}