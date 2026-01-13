using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 推广订单详情表
/// </summary>
public partial class MktPromoterOrderDetail
{
    /// <summary>
    /// 详情id
    /// </summary>
    public string Mpodid { get; set; } = null!;

    /// <summary>
    /// 关联推广订单id
    /// </summary>
    public string MpodorderId { get; set; } = null!;

    /// <summary>
    /// 推广链接id
    /// </summary>
    public string? MpodlinkId { get; set; }

    /// <summary>
    /// 1-服务,2-产品,3-套餐
    /// </summary>
    public int MpodproductType { get; set; }

    /// <summary>
    /// 产品id
    /// </summary>
    public string MpodproductId { get; set; } = null!;

    /// <summary>
    /// 规格id
    /// </summary>
    public string? MpodspecId { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int? Mpodquantity { get; set; }

    /// <summary>
    /// 单价
    /// </summary>
    public decimal Mpodprice { get; set; }

    /// <summary>
    /// 小计金额
    /// </summary>
    public decimal Mpodsubtotal { get; set; }

    /// <summary>
    /// 佣金比例(%)
    /// </summary>
    public decimal MpodcommissionRate { get; set; }

    /// <summary>
    /// 佣金金额
    /// </summary>
    public decimal MpodcommissionAmount { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? MpodcreateTime { get; set; }
}
