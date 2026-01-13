using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 部门岗位表
/// </summary>
public partial class OrgDepartmentDuty
{
    /// <summary>
    /// 主键id
    /// </summary>
    public string Ddid { get; set; } = null!;

    /// <summary>
    /// 部门id
    /// </summary>
    public string DddeptId { get; set; } = null!;

    /// <summary>
    /// 岗位id
    /// </summary>
    public string DddutyId { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? DdcreateTime { get; set; }
}
