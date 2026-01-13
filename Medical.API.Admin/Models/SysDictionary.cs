using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 字典表
/// </summary>
public partial class SysDictionary
{
    /// <summary>
    /// 类型id
    /// </summary>
    public string Did { get; set; } = null!;

    /// <summary>
    /// 类型名称
    /// </summary>
    public string? Dname { get; set; }

    /// <summary>
    /// 类型图标
    /// </summary>
    public string? Dicon { get; set; }

    /// <summary>
    /// 类型图片
    /// </summary>
    public string? Dphoto { get; set; }

    /// <summary>
    /// 类型描述
    /// </summary>
    public string? Dexplain { get; set; }

    /// <summary>
    /// 类型值
    /// </summary>
    public string? Dvalue { get; set; }

    /// <summary>
    /// 是否是类型
    /// </summary>
    public int? DisType { get; set; }

    /// <summary>
    /// 上级
    /// </summary>
    public string? DparentId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? DcreateTime { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? DisBan { get; set; }

    /// <summary>
    /// 使用次数
    /// </summary>
    public int? Dcount { get; set; }

    /// <summary>
    /// 是否置顶
    /// </summary>
    public int? DisTop { get; set; }
}
