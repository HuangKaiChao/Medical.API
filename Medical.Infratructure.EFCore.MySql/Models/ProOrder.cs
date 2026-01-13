using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 订单表
/// </summary>
public partial class ProOrder
{
    /// <summary>
    /// 订单id
    /// </summary>
    public string Oid { get; set; } = null!;

    /// <summary>
    /// 客户id
    /// </summary>
    public string OcustomerId { get; set; } = null!;

    /// <summary>
    /// 订单类型(1:服务,2:产品,3:套餐,4:混合项目)
    /// </summary>
    public int Otype { get; set; }

    /// <summary>
    /// 总金额
    /// </summary>
    public decimal OtotalAmount { get; set; }

    /// <summary>
    /// 已付金额
    /// </summary>
    public decimal? OpaidAmount { get; set; }

    /// <summary>
    /// 产品数量
    /// </summary>
    public int? Ototal { get; set; }

    /// <summary>
    /// 支付方式
    /// </summary>
    public string? OpaymentMethod { get; set; }

    /// <summary>
    /// 支付状态(0:未支付,1:已支付,2:已退款)
    /// </summary>
    public int OpaymentStatus { get; set; }

    /// <summary>
    /// 是否完成
    /// </summary>
    public int? OisComplete { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? OcompleteTime { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTime? OpaymentTime { get; set; }

    /// <summary>
    /// 取消时间
    /// </summary>
    public DateTime? OcancelTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? OcreateTime { get; set; }

    /// <summary>
    /// 操作人/员工id
    /// </summary>
    public string? OemployeeId { get; set; }

    /// <summary>
    /// 订单状态:1-处理中,2-已完成 3-已取消
    /// </summary>
    public int Ostatus { get; set; }

    /// <summary>
    /// 理疗室id
    /// </summary>
    public string? OroomId { get; set; }
}
