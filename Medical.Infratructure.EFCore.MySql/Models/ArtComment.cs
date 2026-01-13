using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 文章评论表
/// </summary>
public partial class ArtComment
{
    /// <summary>
    /// 评论id
    /// </summary>
    public string Acid { get; set; } = null!;

    /// <summary>
    /// 文章id
    /// </summary>
    public string AcarticleId { get; set; } = null!;

    /// <summary>
    /// 评论用户id/客户id
    /// </summary>
    public string AccustomerId { get; set; } = null!;

    /// <summary>
    /// 父评论id
    /// </summary>
    public string? AcparentId { get; set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string Accontent { get; set; } = null!;

    /// <summary>
    /// 点赞数
    /// </summary>
    public int? AclikeCount { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? AccreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? AcupdateTime { get; set; }
}
