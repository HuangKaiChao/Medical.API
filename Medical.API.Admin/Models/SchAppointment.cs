using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 预约表
/// </summary>
public partial class SchAppointment
{
    /// <summary>
    /// 预约id
    /// </summary>
    public string Said { get; set; } = null!;

    /// <summary>
    /// 客户id
    /// </summary>
    public string SacustomerId { get; set; } = null!;

    /// <summary>
    /// 理疗师id
    /// </summary>
    public string SatherapistId { get; set; } = null!;

    /// <summary>
    /// 预约日期
    /// </summary>
    public DateOnly Sadate { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime SastartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime SaendTime { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Sanote { get; set; }

    /// <summary>
    /// 状态(0:待确认,1:已预约,2:已完成,3:已取消,4:已转订单)
    /// </summary>
    public int? Sastatus { get; set; }

    /// <summary>
    /// 是否已提醒(0:否,1:是)
    /// </summary>
    public sbyte? SaisReminded { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? SacreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? SaupdateTime { get; set; }
}
