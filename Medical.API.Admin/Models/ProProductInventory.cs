using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 产品库存表
/// </summary>
public partial class ProProductInventory
{
    /// <summary>
    /// 库存记录id
    /// </summary>
    public string Siid { get; set; } = null!;

    /// <summary>
    /// 产品id
    /// </summary>
    public string? SiproductId { get; set; }

    /// <summary>
    /// 规格id(为空表示产品总库存)
    /// </summary>
    public string? SispecId { get; set; }

    /// <summary>
    /// 库存数量
    /// </summary>
    public int? SistockQuantity { get; set; }

    /// <summary>
    /// 最后更新时间
    /// </summary>
    public DateTime? SilastUpdateTime { get; set; }
}
