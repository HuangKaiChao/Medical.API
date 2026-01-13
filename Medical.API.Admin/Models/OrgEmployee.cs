using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 员工表
/// </summary>
public partial class OrgEmployee
{
    /// <summary>
    /// 员工id
    /// </summary>
    public string Eid { get; set; } = null!;

    /// <summary>
    /// 员工姓名
    /// </summary>
    public string Ename { get; set; } = null!;

    /// <summary>
    /// 所属部门id
    /// </summary>
    public string EdeptId { get; set; } = null!;

    /// <summary>
    /// 岗位id
    /// </summary>
    public string EdutyId { get; set; } = null!;

    /// <summary>
    /// 角色
    /// </summary>
    public string? ErolesId { get; set; }

    /// <summary>
    /// 账号/手机号
    /// </summary>
    public string? Eaccount { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string? Epassword { get; set; }

    /// <summary>
    /// 盐
    /// </summary>
    public string? Esalt { get; set; }

    /// <summary>
    /// 专业技能/职称
    /// </summary>
    public string? Especialty { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string? Eavatar { get; set; }

    /// <summary>
    /// 性别(0:男-1:女)
    /// </summary>
    public int? Egender { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Eemail { get; set; }

    /// <summary>
    /// 入职日期
    /// </summary>
    public DateTime? EentryDate { get; set; }

    /// <summary>
    /// 状态(0:离职,1:在职)
    /// </summary>
    public int? Estatus { get; set; }

    /// <summary>
    /// 是否禁用
    /// </summary>
    public int? EisBan { get; set; }

    /// <summary>
    /// 账号是否激活
    /// </summary>
    public int? EisActive { get; set; }

    /// <summary>
    /// 是否在线
    /// </summary>
    public int? EisOnline { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? EcreateTime { get; set; }

    /// <summary>
    /// 员工呢称
    /// </summary>
    public string? Enick { get; set; }

    /// <summary>
    /// 员工描述
    /// </summary>
    public string? Eexplain { get; set; }
}
