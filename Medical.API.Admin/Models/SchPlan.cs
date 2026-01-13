using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 排班计划表
/// </summary>
public partial class SchPlan
{
    /// <summary>
    /// 计划id
    /// </summary>
    public string Spid { get; set; } = null!;

    /// <summary>
    /// 计划名称
    /// </summary>
    public string Spname { get; set; } = null!;

    /// <summary>
    /// 开始日期
    /// </summary>
    public DateOnly SpstartDate { get; set; }

    /// <summary>
    /// 结束日期
    /// </summary>
    public DateOnly SpendDate { get; set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public int? SpisPublish { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? SpcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? SpupdateTime { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Spexplain { get; set; }
}
