using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 文章主表
/// </summary>
public partial class ArtArticle
{
    /// <summary>
    /// 文章id
    /// </summary>
    public string Aid { get; set; } = null!;

    /// <summary>
    /// 文章标题
    /// </summary>
    public string Atitle { get; set; } = null!;

    /// <summary>
    /// 文章内容
    /// </summary>
    public string Acontent { get; set; } = null!;

    /// <summary>
    /// 作者id
    /// </summary>
    public string AauthorId { get; set; } = null!;

    /// <summary>
    /// 封面图片URL
    /// </summary>
    public string? AcoverImage { get; set; }

    /// <summary>
    /// 状态(1:发布,2:草稿)
    /// </summary>
    public int? Astatus { get; set; }

    /// <summary>
    /// 是否允许评论(0:否,1:是)
    /// </summary>
    public sbyte? AisCommentAllowed { get; set; }

    /// <summary>
    /// 浏览量
    /// </summary>
    public int? AviewCount { get; set; }

    /// <summary>
    /// 点赞数
    /// </summary>
    public int? AlikeCount { get; set; }

    /// <summary>
    /// 评论数
    /// </summary>
    public int? AcommentCount { get; set; }

    /// <summary>
    /// 标签，逗号分隔
    /// </summary>
    public string? Atags { get; set; }

    /// <summary>
    /// 是否置顶(0:否,1:是)
    /// </summary>
    public int? AisTop { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? AcreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? AupdateTime { get; set; }

    /// <summary>
    /// 分类1:服务,2:产品,3:套餐
    /// </summary>
    public int? Atype { get; set; }
}
