using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 管理员登录日志表
/// </summary>
public partial class SysAdminLoginLog
{
    /// <summary>
    /// 日志ID（主键）
    /// </summary>
    public string Lid { get; set; } = null!;

    /// <summary>
    /// 管理员ID（关联sys_admins表AID）
    /// </summary>
    public string? Laid { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string? Llcode { get; set; }

    /// <summary>
    /// 登录用户名
    /// </summary>
    public string? Lausername { get; set; }

    /// <summary>
    /// 登录时间
    /// </summary>
    public DateTime? LloginTime { get; set; }

    /// <summary>
    /// 登录IP地址
    /// </summary>
    public string? LloginIp { get; set; }

    /// <summary>
    /// 登录地点
    /// </summary>
    public string? Llocation { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public string? Lbrowser { get; set; }

    /// <summary>
    /// 操作系统
    /// </summary>
    public string? LoperatingSystem { get; set; }

    /// <summary>
    /// 登录结果（0-失败，1-成功）
    /// </summary>
    public int? LloginResult { get; set; }

    /// <summary>
    /// 失败原因
    /// </summary>
    public string? LfailReason { get; set; }

    /// <summary>
    /// 登录状态过期时间
    /// </summary>
    public DateTime? LexpireTime { get; set; }
}
