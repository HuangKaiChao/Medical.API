using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 推广订单表
/// </summary>
public partial class MktPromoterOrder
{
    /// <summary>
    /// 订单id
    /// </summary>
    public string Mpoid { get; set; } = null!;

    /// <summary>
    /// 推广员id
    /// </summary>
    public string MpopromoterId { get; set; } = null!;

    /// <summary>
    /// 结算状态(0:待结算,1:已结算,2:已拒绝)
    /// </summary>
    public int? MposettlementStatus { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? MpoisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? MpocreateTime { get; set; }

    /// <summary>
    /// 被推荐的客户id
    /// </summary>
    public string? MpocustomerId { get; set; }

    /// <summary>
    /// 推广渠道
    /// </summary>
    public string? MpochannelId { get; set; }

    /// <summary>
    /// 关联下单订单id
    /// </summary>
    public string? MpoorderId { get; set; }

    /// <summary>
    /// 结算时间
    /// </summary>
    public DateTime? MposettlementTime { get; set; }

    /// <summary>
    /// 订单总金额
    /// </summary>
    public decimal? MpoorderAmount { get; set; }

    /// <summary>
    /// 总佣金金额
    /// </summary>
    public decimal? MpocommissionAmount { get; set; }
}
