using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 排班表
/// </summary>
public partial class SchSchedule
{
    /// <summary>
    /// 排班id
    /// </summary>
    public string Sid { get; set; } = null!;

    /// <summary>
    /// 计划id
    /// </summary>
    public string? SplanId { get; set; }

    /// <summary>
    /// 员工id
    /// </summary>
    public string SemployeeId { get; set; } = null!;

    /// <summary>
    /// 排班日期
    /// </summary>
    public DateOnly Sdate { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public TimeOnly SstartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public TimeOnly SendTime { get; set; }

    /// <summary>
    /// 状态(1:值班,2:休息,3:请假)
    /// </summary>
    public int? Sstatus { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Snote { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? ScreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? SupdateTime { get; set; }
}
