using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 员工角色关联表
/// </summary>
public partial class SysEmployeeRole
{
    /// <summary>
    /// 关联id
    /// </summary>
    public string Erid { get; set; } = null!;

    /// <summary>
    /// 员工id
    /// </summary>
    public string Ereid { get; set; } = null!;

    /// <summary>
    /// 角色id
    /// </summary>
    public string Errid { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? ErcreateTime { get; set; }
}
