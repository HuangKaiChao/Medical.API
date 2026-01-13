using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 佣金规则表
/// </summary>
public partial class MktCommissionRule
{
    /// <summary>
    /// 规则id
    /// </summary>
    public string Mcrid { get; set; } = null!;

    /// <summary>
    /// 产品id
    /// </summary>
    public string? McrproductId { get; set; }

    /// <summary>
    /// 佣金比例
    /// </summary>
    public decimal McrcommissionRate { get; set; }

    /// <summary>
    /// 最低金额限制
    /// </summary>
    public decimal? McrminAmount { get; set; }

    /// <summary>
    /// 最高金额限制
    /// </summary>
    public decimal? McrmaxAmount { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? McrisBan { get; set; }

    /// <summary>
    /// 是否发布(0:否,1:是)
    /// </summary>
    public int? Mcpublish { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? McrcreateTime { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    public int? McruseCount { get; set; }

    /// <summary>
    /// 规则描述
    /// </summary>
    public string? Mcrexplain { get; set; }

    /// <summary>
    /// 产品类型:1-服务,2-产品,3-套餐
    /// </summary>
    public int? McrproductType { get; set; }
}
