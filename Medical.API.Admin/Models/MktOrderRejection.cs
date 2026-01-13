using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 订单拒绝记录表
/// </summary>
public partial class MktOrderRejection
{
    /// <summary>
    /// 拒绝记录id
    /// </summary>
    public string Morid { get; set; } = null!;

    /// <summary>
    /// 关联订单id
    /// </summary>
    public string MororderId { get; set; } = null!;

    /// <summary>
    /// 拒绝人(员工id)
    /// </summary>
    public string MorrejecterId { get; set; } = null!;

    /// <summary>
    /// 拒绝原因
    /// </summary>
    public string Morreason { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? MorcreateTime { get; set; }
}
