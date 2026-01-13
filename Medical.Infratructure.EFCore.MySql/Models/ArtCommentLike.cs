using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 评论点赞表
/// </summary>
public partial class ArtCommentLike
{
    /// <summary>
    /// 评论点赞id
    /// </summary>
    public string Aclid { get; set; } = null!;

    /// <summary>
    /// 评论id
    /// </summary>
    public string AclcommentId { get; set; } = null!;

    /// <summary>
    /// 点赞用户/客户id
    /// </summary>
    public string AclcustomerId { get; set; } = null!;

    /// <summary>
    /// 点赞时间
    /// </summary>
    public DateTime? AclcreateTime { get; set; }
}
