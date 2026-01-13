using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 套餐服务项关联表
/// </summary>
public partial class ProPackageDetail
{
    /// <summary>
    /// 关联id
    /// </summary>
    public string Pdid { get; set; } = null!;

    /// <summary>
    /// 套餐id
    /// </summary>
    public string PpackageId { get; set; } = null!;

    /// <summary>
    /// 服务id
    /// </summary>
    public string PserviceId { get; set; } = null!;

    /// <summary>
    /// 服务次数
    /// </summary>
    public int? Pdquantity { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PdcreateTime { get; set; }
}
