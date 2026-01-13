using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 服务表
/// </summary>
public partial class ProService
{
    /// <summary>
    /// 服务id
    /// </summary>
    public string Sid { get; set; } = null!;

    /// <summary>
    /// 服务图片
    /// </summary>
    public string Sphoto { get; set; } = null!;

    /// <summary>
    /// 服务名称
    /// </summary>
    public string Sname { get; set; } = null!;

    /// <summary>
    /// 分类id
    /// </summary>
    public string ScategoryId { get; set; } = null!;

    /// <summary>
    /// 价格
    /// </summary>
    public decimal Sprice { get; set; }

    /// <summary>
    /// 时长(分钟)
    /// </summary>
    public string Sduration { get; set; } = null!;

    /// <summary>
    /// 服务描述
    /// </summary>
    public string? Sexplain { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? ScreateTime { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? SisBan { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    public int? SuseCount { get; set; }

    /// <summary>
    /// 服务销量
    /// </summary>
    public int? Ssales { get; set; }
}
