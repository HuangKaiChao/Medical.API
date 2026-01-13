using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 产品表
/// </summary>
public partial class ProProduct
{
    /// <summary>
    /// 产品id
    /// </summary>
    public string Pid { get; set; } = null!;

    /// <summary>
    /// 产品名称
    /// </summary>
    public string? Pname { get; set; }

    /// <summary>
    /// 分类id
    /// </summary>
    public string? PcategoryId { get; set; }

    /// <summary>
    /// 起购数量
    /// </summary>
    public int? PminPurchase { get; set; }

    /// <summary>
    /// 是否限购(0-不限购,1-限购)
    /// </summary>
    public int? PlimitPurchase { get; set; }

    /// <summary>
    /// 限购数量
    /// </summary>
    public int? PlimitQuantity { get; set; }

    /// <summary>
    /// 商品售价
    /// </summary>
    public decimal? Pprice { get; set; }

    /// <summary>
    /// 库存
    /// </summary>
    public int? Pinventory { get; set; }

    /// <summary>
    /// 销量
    /// </summary>
    public int? Psales { get; set; }

    /// <summary>
    /// 是否有规格(0-否,1-是)
    /// </summary>
    public int? PhasSpecs { get; set; }

    /// <summary>
    /// 是否上架
    /// </summary>
    public int? PisShelve { get; set; }

    /// <summary>
    /// 上架时间
    /// </summary>
    public DateTime? PshelveTime { get; set; }

    /// <summary>
    /// 基础规格
    /// </summary>
    public string? Pspecs { get; set; }

    /// <summary>
    /// 产品描述
    /// </summary>
    public string? Pexplain { get; set; }

    /// <summary>
    /// 产品图片
    /// </summary>
    public string? Pphoto { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? PisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PcreateTime { get; set; }
}
