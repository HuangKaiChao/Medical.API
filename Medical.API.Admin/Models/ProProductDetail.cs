using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 产品详情表
/// </summary>
public partial class ProProductDetail
{
    /// <summary>
    /// 详情id
    /// </summary>
    public string Pdid { get; set; } = null!;

    /// <summary>
    /// 产品id
    /// </summary>
    public string? Pdpid { get; set; }

    /// <summary>
    /// 产品图片
    /// </summary>
    public string? Pdpphoto { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? Pdsort { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PdcreateTime { get; set; }
}
