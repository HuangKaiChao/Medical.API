using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 订单明细表
/// </summary>
public partial class ProOrderDetail
{
    /// <summary>
    /// 明细id
    /// </summary>
    public string Odid { get; set; } = null!;

    /// <summary>
    /// 订单id
    /// </summary>
    public string OdorderId { get; set; } = null!;

    /// <summary>
    /// 项目id
    /// </summary>
    public string OditemId { get; set; } = null!;

    /// <summary>
    /// 规格名称
    /// </summary>
    public string? OdspecName { get; set; }

    /// <summary>
    /// 规格id
    /// </summary>
    public string? OdspecId { get; set; }

    /// <summary>
    /// 理疗师id
    /// </summary>
    public string? OdtherapistId { get; set; }

    /// <summary>
    /// 服务时间
    /// </summary>
    public DateTime? OdserviceTime { get; set; }

    /// <summary>
    /// 项目类型(1:服务,2:产品,3:套餐)
    /// </summary>
    public int OditemType { get; set; }

    /// <summary>
    /// 状态(1:服务中,2:已完成3:已取消)
    /// </summary>
    public int? Odstatus { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public decimal Odprice { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int? Odquantity { get; set; }

    /// <summary>
    /// 取消时间
    /// </summary>
    public DateTime? OdcancelTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? OdcompleteTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? OdcreateTime { get; set; }

    /// <summary>
    /// 服务结束时间
    /// </summary>
    public DateTime? OdserviceEndTime { get; set; }

    /// <summary>
    /// 小计金额(单价*数量)
    /// </summary>
    public decimal? Odsubtotal { get; set; }
}
