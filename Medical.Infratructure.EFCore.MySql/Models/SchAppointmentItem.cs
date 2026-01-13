using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 预约项目明细表
/// </summary>
public partial class SchAppointmentItem
{
    /// <summary>
    /// 预约项目id
    /// </summary>
    public string Saiid { get; set; } = null!;

    /// <summary>
    /// 关联预约id
    /// </summary>
    public string SaiappointmentId { get; set; } = null!;

    /// <summary>
    /// 项目类型(1:服务,2:套餐)
    /// </summary>
    public int Saitype { get; set; }

    /// <summary>
    /// 服务/套餐id
    /// </summary>
    public string SaiitemId { get; set; } = null!;

    /// <summary>
    /// 数量
    /// </summary>
    public int? Saiquantity { get; set; }

    /// <summary>
    /// 单价
    /// </summary>
    public decimal? Saiprice { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? SaicreateTime { get; set; }
}
