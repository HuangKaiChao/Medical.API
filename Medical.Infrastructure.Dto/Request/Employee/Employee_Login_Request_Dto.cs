namespace Medical.Infrastructure.Dto.Request.Org.Employee;

/// <summary>
/// 员工登录请求Dto
/// </summary>
public class Employee_Login_Request_Dto
{
    /// <summary>
    /// 账号
    /// </summary>
    public string? account { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    public string? password { get; set; }
    /// <summary>
    /// 凭据
    /// </summary>
    public string? code { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    public string? token { get; set; }
}