using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 客户与推广员关联表
/// </summary>
public partial class MktCustomerPromoter
{
    /// <summary>
    /// 关联id
    /// </summary>
    public string Cpid { get; set; } = null!;

    /// <summary>
    /// 被推广客户id
    /// </summary>
    public string CpcustomerId { get; set; } = null!;

    /// <summary>
    /// 推广员id
    /// </summary>
    public string CppromoterId { get; set; } = null!;

    /// <summary>
    /// 关联类型(1-注册,2-购买)
    /// </summary>
    public int? Cptype { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CpcreateTime { get; set; }

    /// <summary>
    /// 推广员类型:1-员工,2-客户
    /// </summary>
    public int? CppromoterType { get; set; }
}
