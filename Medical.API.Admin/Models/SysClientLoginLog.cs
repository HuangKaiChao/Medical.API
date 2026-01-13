using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 客户登录日志表
/// </summary>
public partial class SysClientLoginLog
{
    /// <summary>
    /// 日志id
    /// </summary>
    public string Llid { get; set; } = null!;

    /// <summary>
    /// 客户id
    /// </summary>
    public string? Llcid { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string? Llaccount { get; set; }

    /// <summary>
    /// 生成的凭据
    /// </summary>
    public string? Llcode { get; set; }

    /// <summary>
    /// 耗时
    /// </summary>
    public int? Lltake { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public string? Llbrowser { get; set; }

    /// <summary>
    /// 地区
    /// </summary>
    public string? Llregion { get; set; }

    /// <summary>
    /// 设备
    /// </summary>
    public string? Llapex { get; set; }

    /// <summary>
    /// 登录系统
    /// </summary>
    public string? Llox { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? LlcreateTime { get; set; }

    /// <summary>
    /// 登录状态保持时间
    /// </summary>
    public DateTime? LltimeOut { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    public string? Llip { get; set; }
}
