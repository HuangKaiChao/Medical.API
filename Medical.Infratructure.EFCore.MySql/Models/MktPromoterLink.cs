using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 推广链接表
/// </summary>
public partial class MktPromoterLink
{
    /// <summary>
    /// 链接id
    /// </summary>
    public string Mplid { get; set; } = null!;

    /// <summary>
    /// 推广员id
    /// </summary>
    public string MplpromoterId { get; set; } = null!;

    /// <summary>
    /// 渠道id
    /// </summary>
    public string MplchannelId { get; set; } = null!;

    /// <summary>
    /// 基础URL
    /// </summary>
    public string MplbaseUrl { get; set; } = null!;

    /// <summary>
    /// 完整推广URL
    /// </summary>
    public string MplfullUrl { get; set; } = null!;

    /// <summary>
    /// 二维码URL
    /// </summary>
    public string? MplqrcodeUrl { get; set; }

    /// <summary>
    /// 点击次数
    /// </summary>
    public int? MplclickCount { get; set; }

    /// <summary>
    /// 转化次数
    /// </summary>
    public int? MplconversionCount { get; set; }

    /// <summary>
    /// 状态(1:有效,0:无效)
    /// </summary>
    public int? Mplstatus { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? MplisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? MplcreateTime { get; set; }
}
