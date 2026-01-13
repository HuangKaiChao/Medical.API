using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 佣金结算记录
/// </summary>
public partial class FinCommission
{
    /// <summary>
    /// 结算id
    /// </summary>
    public string Fcid { get; set; } = null!;

    /// <summary>
    /// 推广员id
    /// </summary>
    public string FcpromoterId { get; set; } = null!;

    /// <summary>
    /// 推广员账号
    /// </summary>
    public string Fcaccount { get; set; } = null!;

    /// <summary>
    /// 结算金额
    /// </summary>
    public decimal Fcamount { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? FccreateTime { get; set; }
}
