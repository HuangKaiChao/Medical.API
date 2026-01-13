using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

public partial class ProProductPhoto
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
    /// 是否主图(0-否,1-是)
    /// </summary>
    public sbyte? PdisMain { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? Pdsort { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PdcreateTime { get; set; }
}
