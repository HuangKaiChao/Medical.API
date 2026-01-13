using System;
using System.Collections.Generic;

namespace Medical.Infrastructure.EFCore.MySql.Models;

/// <summary>
/// 系统消息通知表
/// </summary>
public partial class SysNotification
{
    /// <summary>
    /// 消息id
    /// </summary>
    public string Nid { get; set; } = null!;

    /// <summary>
    /// 消息类型:0-订单,1-预约,2-佣金,3-跟进,4-支付,5-系统
    /// </summary>
    public int Ntype { get; set; }

    /// <summary>
    /// 消息标题
    /// </summary>
    public string Ntitle { get; set; } = null!;

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Ncontent { get; set; } = null!;

    /// <summary>
    /// 关联业务id
    /// </summary>
    public string? NrelatedId { get; set; }

    /// <summary>
    /// 接收人类型:1-员工,2-客户
    /// </summary>
    public int? NreceiverType { get; set; }

    /// <summary>
    /// 接收人id
    /// </summary>
    public string NreceiverId { get; set; } = null!;

    /// <summary>
    /// 状态:0-未读,1-已读
    /// </summary>
    public int? Nstatus { get; set; }

    /// <summary>
    /// 是否删除
    /// </summary>
    public int? NisDeleted { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? NcreateTime { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    public DateTime? NreadTime { get; set; }
}
