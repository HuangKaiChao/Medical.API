namespace Medical.Infrastructure.Dto.Response.Org.Employee;

/// <summary>
/// 员工信息返回Dto
/// </summary>
public class Employee_Response_Dto
{
    /// <summary>
    ///  员工id
    /// </summary>
    public string? id { get; set; }
    /// <summary>
    ///  员工名称
    /// </summary>
    public string? name { get; set; }
    /// <summary>
    /// 员工昵称
    /// </summary>
    public string? nick { get; set; }
    /// <summary>
    ///  员工账号
    /// </summary>
    public string? account { get; set; }

    /// <summary>
    ///  员工头像
    /// </summary>
    public string? avatar { get; set; }

    /// <summary>
    ///  员工角色
    /// </summary>
    public string? role_name { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public int? isBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public string? create_time { get; set; }

    /// <summary>
    /// 部门id
    /// </summary>
    public string? dept_id { get; set; }
    /// <summary>
    /// 岗位id
    /// </summary>
    public string? duty_id { get; set; }
    /// <summary>
    /// 部门名称
    /// </summary>
    public string? dept_name { get; set; }
    /// <summary>
    /// 岗位名称
    /// </summary>
    public string? duty_name { get; set; }
    /// <summary>
    /// 性别0:男 1:女
    /// </summary>
    public int? gender { get; set; }
    /// <summary>
    /// 邮箱
    /// </summary>
    public string? email { get; set; }
    /// <summary>
    /// 是否激活
    /// </summary>
    public int? isActive { get; set; }
    /// <summary>
    /// 是否离职-0:在职 1:离职
    /// </summary>
    public int? status { get; set; }
    /// <summary>
    /// 入职时间
    /// </summary>
    public string? entry_date { get; set; }
    /// <summary>
    /// 消息未读数
    /// </summary>
    public int? unreadCount { get; set; }
}