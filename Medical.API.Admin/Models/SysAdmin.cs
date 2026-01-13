using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 系统管理员表
/// </summary>
public partial class SysAdmin
{
    /// <summary>
    /// 管理员ID（主键）
    /// </summary>
    public string Aid { get; set; } = null!;

    /// <summary>
    /// 登录姓名
    /// </summary>
    public string? Ausername { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string? Apassword { get; set; }

    /// <summary>
    /// 盐值
    /// </summary>
    public string? Asalt { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string? Aavatar { get; set; }

    /// <summary>
    /// 角色ID
    /// </summary>
    public string? AroleId { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Aemail { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    public string? Aphone { get; set; }

    /// <summary>
    /// 状态（0-禁用，1-正常）
    /// </summary>
    public int? Astatus { get; set; }

    /// <summary>
    /// 是否激活
    /// </summary>
    public int? AisActive { get; set; }

    /// <summary>
    /// 最后登录时间
    /// </summary>
    public DateTime? AlastLoginTime { get; set; }

    /// <summary>
    /// 最后登录IP
    /// </summary>
    public string? AlastLoginIp { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? AcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? AupdateTime { get; set; }
}
