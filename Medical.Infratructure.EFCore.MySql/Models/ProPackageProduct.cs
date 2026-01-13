using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 套餐产品项关联表
/// </summary>
public partial class ProPackageProduct
{
    /// <summary>
    /// 关联id
    /// </summary>
    public string Ppid { get; set; } = null!;

    /// <summary>
    /// 套餐id
    /// </summary>
    public string PpackageId { get; set; } = null!;

    /// <summary>
    /// 产品id
    /// </summary>
    public string? PproductId { get; set; }

    /// <summary>
    /// 规格id
    /// </summary>
    public string? PspecId { get; set; }

    /// <summary>
    /// 产品数量
    /// </summary>
    public int? Ppquantity { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PppcreateTime { get; set; }
}
