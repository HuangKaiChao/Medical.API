using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 角色菜单关联表
/// </summary>
public partial class SysEmployeeRight
{
    /// <summary>
    /// 关联id
    /// </summary>
    public string Ermid { get; set; } = null!;

    /// <summary>
    /// 角色id
    /// </summary>
    public string ErroleId { get; set; } = null!;

    /// <summary>
    /// 权限id
    /// </summary>
    public string Errid { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? RcreateTime { get; set; }
}
