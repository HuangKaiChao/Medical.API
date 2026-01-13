using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 排班历史记录表
/// </summary>
public partial class SchHistory
{
    /// <summary>
    /// 历史id
    /// </summary>
    public string Shid { get; set; } = null!;

    /// <summary>
    /// 排班id
    /// </summary>
    public string ShscheduleId { get; set; } = null!;

    /// <summary>
    /// 变更类型:0-人员变更,1-班次交换,2-替班安排,3-状态变更,4-时间调整
    /// </summary>
    public int ShchangeType { get; set; }

    /// <summary>
    /// 变更详情
    /// </summary>
    public string? ShchangeDetails { get; set; }

    /// <summary>
    /// 变更时间
    /// </summary>
    public DateTime? ShchangeTime { get; set; }

    /// <summary>
    /// 变更人id
    /// </summary>
    public string ShchangedById { get; set; } = null!;
}
