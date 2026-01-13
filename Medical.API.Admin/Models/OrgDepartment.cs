using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 部门表
/// </summary>
public partial class OrgDepartment
{
    /// <summary>
    /// 部门id
    /// </summary>
    public string Did { get; set; } = null!;

    /// <summary>
    /// 部门名称
    /// </summary>
    public string Dname { get; set; } = null!;

    /// <summary>
    /// 父部门id
    /// </summary>
    public string? DparentId { get; set; }

    /// <summary>
    /// 部门描述
    /// </summary>
    public string? Ddescription { get; set; }

    /// <summary>
    /// 排序号
    /// </summary>
    public int? DsortOrder { get; set; }

    /// <summary>
    /// 部门图标
    /// </summary>
    public string Dicon { get; set; } = null!;

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? DisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? DcreateTime { get; set; }
}
