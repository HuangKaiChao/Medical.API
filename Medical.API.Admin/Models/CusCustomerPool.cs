using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 客户公海管理表
/// </summary>
public partial class CusCustomerPool
{
    /// <summary>
    /// 公海记录id
    /// </summary>
    public string Cpid { get; set; } = null!;

    /// <summary>
    /// 关联客户id
    /// </summary>
    public string CpcustomerId { get; set; } = null!;

    /// <summary>
    /// 进入公海类型：1-新客户未分配,2-新客户已分配,3-跟进超时退回,4-客户无响应退回 ,5-员工主动退回
    /// </summary>
    public int CpenterType { get; set; }

    /// <summary>
    /// 进入公海时间
    /// </summary>
    public DateTime CpenterTime { get; set; }

    /// <summary>
    /// 退回公海原因（仅EnterType=2/3/4时必填）
    /// </summary>
    public string? CpreturnReason { get; set; }

    /// <summary>
    /// 锁定状态:0-未锁定 1-已锁定(领取时锁定,防止并发)
    /// </summary>
    public int CplockStatus { get; set; }

    /// <summary>
    /// 锁定人id(LockStatus=1时必填)
    /// </summary>
    public string? CplockOperatorId { get; set; }

    /// <summary>
    /// 锁定过期时间(锁定后30分钟自动解锁，防止占而不领)
    /// </summary>
    public DateTime? CplockExpireTime { get; set; }

    /// <summary>
    /// 领取人id
    /// </summary>
    public string? CptakeOperatorId { get; set; }

    /// <summary>
    /// 领取时间
    /// </summary>
    public DateTime? CptakeTime { get; set; }
}
