using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 提现申请
/// </summary>
public partial class FinWithdrawal
{
    /// <summary>
    /// 提现id
    /// </summary>
    public string Fwid { get; set; } = null!;

    /// <summary>
    /// 推广员id
    /// </summary>
    public string FwpromoterId { get; set; } = null!;

    /// <summary>
    /// 提现金额
    /// </summary>
    public decimal Fwamount { get; set; }

    /// <summary>
    /// 银行账号
    /// </summary>
    public string FwbankAccount { get; set; } = null!;

    /// <summary>
    /// 状态:0-申请中,1-已打款,2-已驳回
    /// </summary>
    public sbyte? Fwstatus { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Fwremark { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? FwcreateTime { get; set; }
}
