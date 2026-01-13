using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 角色表
/// </summary>
public partial class SysRole
{
    /// <summary>
    /// 角色id
    /// </summary>
    public string Rid { get; set; } = null!;

    /// <summary>
    /// 角色名称
    /// </summary>
    public string Rname { get; set; } = null!;

    /// <summary>
    /// 角色描述
    /// </summary>
    public string? Rdescription { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? RcreateTime { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? RisBan { get; set; }

    /// <summary>
    /// 编码/唯一标识
    /// </summary>
    public string? Rcode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int? RsortOrder { get; set; }
}
