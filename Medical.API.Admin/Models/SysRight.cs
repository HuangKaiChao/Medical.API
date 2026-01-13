using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 菜单表
/// </summary>
public partial class SysRight
{
    /// <summary>
    /// 菜单id
    /// </summary>
    public string Rid { get; set; } = null!;

    /// <summary>
    /// 父菜单id
    /// </summary>
    public string? RparentId { get; set; }

    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Rname { get; set; } = null!;

    /// <summary>
    /// 权限类型(1:菜单 2:按钮 3:Api)
    /// </summary>
    public int? Rtype { get; set; }

    /// <summary>
    /// 权限编码(唯一标识:employee:add_dept)
    /// </summary>
    public string Rcode { get; set; } = null!;

    /// <summary>
    /// 菜单路径
    /// </summary>
    public string? Rurl { get; set; }

    /// <summary>
    /// 菜单图标
    /// </summary>
    public string? Ricon { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    public int? RsortOrder { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? RcreateTime { get; set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public int? RisPublish { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? RisBan { get; set; }
}
