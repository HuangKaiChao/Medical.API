using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 理疗室信息表
/// </summary>
public partial class SchTherapyRoom
{
    /// <summary>
    /// 理疗室id
    /// </summary>
    public string Trid { get; set; } = null!;

    /// <summary>
    /// 理疗室名称
    /// </summary>
    public string Trname { get; set; } = null!;

    /// <summary>
    /// 理疗室编号
    /// </summary>
    public string Trcode { get; set; } = null!;

    /// <summary>
    /// 类型(1:单人,2:双人)
    /// </summary>
    public int Trtype { get; set; }

    /// <summary>
    /// 1:可用,2:维护中,3:停用,4已满
    /// </summary>
    public int? Trstatus { get; set; }

    /// <summary>
    /// 所在楼层
    /// </summary>
    public int? Trfloor { get; set; }

    /// <summary>
    /// 容纳人数
    /// </summary>
    public int? Trcapacity { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Trdescription { get; set; }

    /// <summary>
    /// 设备是否就位(0:否,1:是)
    /// </summary>
    public int? TrisEquipmentReady { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? TrcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? TrupdateTime { get; set; }
}
