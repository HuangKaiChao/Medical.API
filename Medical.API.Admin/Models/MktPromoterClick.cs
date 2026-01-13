using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 推广点击记录表
/// </summary>
public partial class MktPromoterClick
{
    /// <summary>
    /// 点击id
    /// </summary>
    public string Pcid { get; set; } = null!;

    /// <summary>
    /// 推广链接id
    /// </summary>
    public string PclinkId { get; set; } = null!;

    /// <summary>
    /// ip地址
    /// </summary>
    public string? Pcip { get; set; }

    /// <summary>
    /// 设备类型
    /// </summary>
    public string? Pcdevice { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public string? Pcbrowser { get; set; }

    /// <summary>
    /// 地区
    /// </summary>
    public string? Pcregion { get; set; }

    /// <summary>
    /// 点击时间
    /// </summary>
    public DateTime? PccreateTime { get; set; }
}
