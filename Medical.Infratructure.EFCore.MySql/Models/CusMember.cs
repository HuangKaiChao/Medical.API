using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 客户会员信息表
/// </summary>
public partial class CusMember
{
    /// <summary>
    /// 会员id
    /// </summary>
    public string Cmid { get; set; } = null!;

    /// <summary>
    /// 客户id
    /// </summary>
    public string CmcustomerId { get; set; } = null!;

    /// <summary>
    /// 会员等级(1-普通,2-银卡,3-金卡,4-钻石)
    /// </summary>
    public int? Cmlevel { get; set; }

    /// <summary>
    /// 累计消费金额
    /// </summary>
    public decimal? CmtotalSpend { get; set; }

    /// <summary>
    /// 会员费
    /// </summary>
    public decimal? CmmembershipFee { get; set; }

    /// <summary>
    /// 会员开始日期
    /// </summary>
    public DateTime? CmstartTime { get; set; }

    /// <summary>
    /// 会员到期日期
    /// </summary>
    public DateTime? CmendTime { get; set; }

    /// <summary>
    /// 状态(0-已过期,1-有效,2-冻结)
    /// </summary>
    public int? Cmstatus { get; set; }

    /// <summary>
    /// 折扣率(%)
    /// </summary>
    public decimal? CmdiscountRate { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CmcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? CmupdateTime { get; set; }
}
