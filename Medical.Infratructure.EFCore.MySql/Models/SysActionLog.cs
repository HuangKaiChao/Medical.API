using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 操作日志表
/// </summary>
public partial class SysActionLog
{
    /// <summary>
    /// 日志id
    /// </summary>
    public string Alid { get; set; } = null!;

    /// <summary>
    /// 操作分组/模块
    /// </summary>
    public string? AlGroup { get; set; }

    /// <summary>
    /// 操作行为/动作
    /// </summary>
    public string? AlAction { get; set; }

    /// <summary>
    /// 操作人
    /// </summary>
    public string? AlUid { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? AlCreateTime { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    public string? AlParams { get; set; }

    /// <summary>
    /// 结果
    /// </summary>
    public int? Alresult { get; set; }

    /// <summary>
    /// 操作IP地址
    /// </summary>
    public string? AlIp { get; set; }

    /// <summary>
    /// 操作URL地址
    /// </summary>
    public string? AlUrl { get; set; }

    /// <summary>
    /// HTTP请求方法
    /// </summary>
    public string? AlMethod { get; set; }
}
