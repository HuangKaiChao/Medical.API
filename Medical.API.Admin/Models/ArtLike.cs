using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 文章点赞表
/// </summary>
public partial class ArtLike
{
    /// <summary>
    /// 点赞id
    /// </summary>
    public string Alid { get; set; } = null!;

    /// <summary>
    /// 文章id
    /// </summary>
    public string AlarticleId { get; set; } = null!;

    /// <summary>
    /// 点赞用户/客户id
    /// </summary>
    public string AlcustomerId { get; set; } = null!;

    /// <summary>
    /// 点赞时间
    /// </summary>
    public DateTime? AlcreateTime { get; set; }
}
