using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 支付主表
/// </summary>
public partial class PayPayment
{
    /// <summary>
    /// 支付id
    /// </summary>
    public string Pid { get; set; } = null!;

    /// <summary>
    /// 订单id
    /// </summary>
    public string PorderId { get; set; } = null!;

    /// <summary>
    /// 支付金额
    /// </summary>
    public decimal Pamount { get; set; }

    /// <summary>
    /// 实际支付金额
    /// </summary>
    public decimal PactualAmount { get; set; }

    /// <summary>
    /// 支付类型(1-支付宝,2-微信,3-银联,4-余额,5-现金)
    /// </summary>
    public int Ptype { get; set; }

    /// <summary>
    /// 支付状态(0-未支付,1-支付成功,3-支付失败,4-已退款)
    /// </summary>
    public int Pstatus { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PcreateTime { get; set; }

    /// <summary>
    /// 支付时间
    /// </summary>
    public DateTime? PpayTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? PcompleteTime { get; set; }

    /// <summary>
    /// 退款时间
    /// </summary>
    public DateTime? PrefundTime { get; set; }
}
