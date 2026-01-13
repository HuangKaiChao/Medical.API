using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 推广员信息表
/// </summary>
public partial class MktPromoter
{
    /// <summary>
    /// 推广员id
    /// </summary>
    public string Mpid { get; set; } = null!;

    /// <summary>
    /// 关联用户id/客户id
    /// </summary>
    public string MpuserId { get; set; } = null!;

    /// <summary>
    /// 专属推广码
    /// </summary>
    public string MppromoCode { get; set; } = null!;

    /// <summary>
    /// 累计收益
    /// </summary>
    public decimal? MptotalIncome { get; set; }

    /// <summary>
    /// 本月收益
    /// </summary>
    public decimal? MpmonthIncome { get; set; }

    /// <summary>
    /// 待结算金额
    /// </summary>
    public decimal? MppendingAmount { get; set; }

    /// <summary>
    /// 推广订单数
    /// </summary>
    public int? MporderCount { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? MpisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? MpcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? MpupdateTime { get; set; }
}
