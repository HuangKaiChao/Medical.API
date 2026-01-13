using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 产品规格表
/// </summary>
public partial class ProProductSpec
{
    /// <summary>
    /// 规格id
    /// </summary>
    public string Psid { get; set; } = null!;

    /// <summary>
    /// 产品id
    /// </summary>
    public string PproductId { get; set; } = null!;

    /// <summary>
    /// 规格名称
    /// </summary>
    public string PsspecName { get; set; } = null!;

    /// <summary>
    /// 规格值(如:一瓶,一箱)
    /// </summary>
    public string PsspecValue { get; set; } = null!;

    /// <summary>
    /// 规格价格
    /// </summary>
    public decimal Psprice { get; set; }

    /// <summary>
    /// 规格图片
    /// </summary>
    public string Psphoto { get; set; } = null!;

    /// <summary>
    /// 排序号
    /// </summary>
    public int? PssortOrder { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? Psiban { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PscreateTime { get; set; }
}
