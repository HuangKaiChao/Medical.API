using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 理疗室排班表
/// </summary>
public partial class SchRoomAppointment
{
    /// <summary>
    /// 疗室预约id
    /// </summary>
    public string Raid { get; set; } = null!;

    /// <summary>
    /// 理疗室id
    /// </summary>
    public string RaroomId { get; set; } = null!;

    /// <summary>
    /// 排班id
    /// </summary>
    public string RascheduleId { get; set; } = null!;

    /// <summary>
    /// 状态(0-待确认, 1-已预约, 2-使用中, 3-已完成, 4-已取消)
    /// </summary>
    public int? Rastatus { get; set; }

    /// <summary>
    /// 预约人数
    /// </summary>
    public int RapeopleCount { get; set; }

    /// <summary>
    /// 关联预约id
    /// </summary>
    public string? RaappointmentId { get; set; }

    /// <summary>
    /// 员工/负责人id
    /// </summary>
    public string? RaemployeeId { get; set; }

    /// <summary>
    /// 预约开始时间
    /// </summary>
    public DateTime RastartTime { get; set; }

    /// <summary>
    /// 预约结束时间
    /// </summary>
    public DateTime RaendTime { get; set; }

    /// <summary>
    /// 确认时间
    /// </summary>
    public DateTime? RaconfirmTime { get; set; }

    /// <summary>
    /// 取消时间
    /// </summary>
    public DateTime? RacancelTime { get; set; }

    /// <summary>
    /// 完成时间
    /// </summary>
    public DateTime? RacompleteTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? RacreateTime { get; set; }
}
