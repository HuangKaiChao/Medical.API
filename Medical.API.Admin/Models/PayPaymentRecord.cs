using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 支付记录表
/// </summary>
public partial class PayPaymentRecord
{
    /// <summary>
    /// 记录id
    /// </summary>
    public string Prid { get; set; } = null!;

    /// <summary>
    /// 支付id
    /// </summary>
    public string PrpaymentId { get; set; } = null!;

    /// <summary>
    /// 记录类型(1-支付,2-退款)
    /// </summary>
    public sbyte Prtype { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Pramount { get; set; }

    /// <summary>
    /// 状态(0-处理中,1-成功,2-失败)
    /// </summary>
    public sbyte Prstatus { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PrcreateTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? PrcompleteTime { get; set; }
}
