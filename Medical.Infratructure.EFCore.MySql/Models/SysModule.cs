using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 管理端系统模块表
/// </summary>
public partial class SysModule
{
    public int Id { get; set; }

    /// <summary>
    /// 模块名称
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 图标标识
    /// </summary>
    public string? Icon { get; set; }

    public int? ParentId { get; set; }

    /// <summary>
    /// 路由地址
    /// </summary>
    public string? Route { get; set; }

    /// <summary>
    /// 是否显示（1=显示，0=隐藏）
    /// </summary>
    public int IsShow { get; set; }

    /// <summary>
    /// 排序序号
    /// </summary>
    public int OrderNum { get; set; }

    /// <summary>
    /// 状态（1=启用，0=禁用）
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
