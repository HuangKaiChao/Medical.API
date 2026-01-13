using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 服务套餐表
/// </summary>
public partial class ProPackage
{
    /// <summary>
    /// 套餐id
    /// </summary>
    public string Pkid { get; set; } = null!;

    /// <summary>
    /// 套餐图片
    /// </summary>
    public string Pkphoto { get; set; } = null!;

    /// <summary>
    /// 套餐名称
    /// </summary>
    public string Pkname { get; set; } = null!;

    /// <summary>
    /// 套餐价格
    /// </summary>
    public decimal Pkprice { get; set; }

    /// <summary>
    /// 套餐描述
    /// </summary>
    public string? Pkexplain { get; set; }

    /// <summary>
    /// 套餐有效期(天)
    /// </summary>
    public int? PkvalidityDays { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? PkcreateTime { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? PkisBan { get; set; }

    /// <summary>
    /// 是否发布(0:否,1:是)
    /// </summary>
    public int? Pkpublish { get; set; }

    /// <summary>
    /// 销量
    /// </summary>
    public int? Pksales { get; set; }

    /// <summary>
    /// 套餐类型
    /// </summary>
    public string? PkcategoryId { get; set; }
}
