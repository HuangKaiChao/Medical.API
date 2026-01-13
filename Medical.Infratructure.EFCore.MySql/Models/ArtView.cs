using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 文章浏览记录表
/// </summary>
public partial class ArtView
{
    /// <summary>
    /// 浏览记录id
    /// </summary>
    public string Avid { get; set; } = null!;

    /// <summary>
    /// 文章id
    /// </summary>
    public string AvarticleId { get; set; } = null!;

    /// <summary>
    /// 浏览用户id
    /// </summary>
    public string? AvcustomerId { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    public string? Avipaddress { get; set; }

    /// <summary>
    /// 设备信息
    /// </summary>
    public string? AvdeviceInfo { get; set; }

    /// <summary>
    /// 地区
    /// </summary>
    public string? Avregion { get; set; }

    /// <summary>
    /// 浏览时间
    /// </summary>
    public DateTime? AvcreateTime { get; set; }
}
