using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 客户表
/// </summary>
public partial class CusCustomer
{
    /// <summary>
    /// 客户id
    /// </summary>
    public string Cid { get; set; } = null!;

    /// <summary>
    /// 头像
    /// </summary>
    public string? Cavatar { get; set; }

    /// <summary>
    /// 客户姓名
    /// </summary>
    public string Cname { get; set; } = null!;

    /// <summary>
    /// 账号/手机号码
    /// </summary>
    public string Cphone { get; set; } = null!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? Cpassword { get; set; }

    /// <summary>
    /// 盐
    /// </summary>
    public string? Csalt { get; set; }

    /// <summary>
    /// 微信号
    /// </summary>
    public string? Cwechat { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateOnly? Cbirthday { get; set; }

    /// <summary>
    /// 性别(0:男,1:女)
    /// </summary>
    public int? Cgender { get; set; }

    /// <summary>
    /// 健康主诉
    /// </summary>
    public string? ChealthConcerns { get; set; }

    /// <summary>
    /// 客户来源
    /// </summary>
    public string? Csource { get; set; }

    /// <summary>
    /// 负责人id
    /// </summary>
    public string? CassigneeId { get; set; }

    /// <summary>
    /// 状态(0:公海,1:跟进中,2:VIP)
    /// </summary>
    public int? Cstatus { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CcreateTime { get; set; }

    /// <summary>
    /// 是否禁用(0:否,1:是)
    /// </summary>
    public int? CisBan { get; set; }

    /// <summary>
    /// 是否激活
    /// </summary>
    public int? CisActive { get; set; }

    /// <summary>
    /// 是否是推广员(0-否,1-是)
    /// </summary>
    public int? CisPromoter { get; set; }

    /// <summary>
    /// 总消费
    /// </summary>
    public decimal? CtotalConsumption { get; set; }

    /// <summary>
    /// 累计取消订单金额
    /// </summary>
    public decimal? CcancelAmount { get; set; }

    /// <summary>
    /// 累计下单数量
    /// </summary>
    public int? CorderCount { get; set; }

    /// <summary>
    /// 累计取消订单数量
    /// </summary>
    public int? CancelOrderCount { get; set; }

    /// <summary>
    /// 账户余额
    /// </summary>
    public decimal? Cbalance { get; set; }

    /// <summary>
    /// 推荐类型:0-自然流量,1-线上推广,2-客户推荐 3-线下活动 4-其他
    /// </summary>
    public int? CreferralType { get; set; }
}
