using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 岗位表
/// </summary>
public partial class OrgDuty
{
    /// <summary>
    /// 岗位id
    /// </summary>
    public string Did { get; set; } = null!;

    /// <summary>
    /// 岗位名称
    /// </summary>
    public string Dname { get; set; } = null!;

    /// <summary>
    /// 岗位描述
    /// </summary>
    public string? Ddescription { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public int? Dcount { get; set; }

    /// <summary>
    /// 等级
    /// </summary>
    public int? Dlevel { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? DisBan { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? DcreateTime { get; set; }
}
