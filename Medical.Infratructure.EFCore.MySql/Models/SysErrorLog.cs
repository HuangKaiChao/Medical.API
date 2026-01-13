using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 错误日志表
/// </summary>
public partial class SysErrorLog
{
    /// <summary>
    /// 日志id
    /// </summary>
    public string Elid { get; set; } = null!;

    /// <summary>
    /// 操作用户
    /// </summary>
    public string? Eluid { get; set; }

    /// <summary>
    /// 操作信息
    /// </summary>
    public string? Elmessage { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? ElcreateTime { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    public string? ElParams { get; set; }

    /// <summary>
    /// 操作IP地址
    /// </summary>
    public string? ElIp { get; set; }

    /// <summary>
    /// 操作URL地址
    /// </summary>
    public string? ElUrl { get; set; }

    /// <summary>
    /// HTTP请求方法
    /// </summary>
    public string? ElMethod { get; set; }
}
