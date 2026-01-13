using System;
using System.Collections.Generic;

namespace Medical.API.Admin.Models;

/// <summary>
/// 客户跟进表
/// </summary>
public partial class CusFollowup
{
    /// <summary>
    /// 跟进id
    /// </summary>
    public string Cfid { get; set; } = null!;

    /// <summary>
    /// 客户id
    /// </summary>
    public string CfcustomerId { get; set; } = null!;

    /// <summary>
    /// 跟进内容
    /// </summary>
    public string Cfcontent { get; set; } = null!;

    /// <summary>
    /// 下次跟进时间
    /// </summary>
    public DateTime? CfnextTime { get; set; }

    /// <summary>
    /// 操作人id
    /// </summary>
    public string CfoperatorId { get; set; } = null!;

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime? CfcreateTime { get; set; }

    /// <summary>
    /// 跟进方式:1-电话 2-微信 3-到店 4-其他
    /// </summary>
    public int? CfollowType { get; set; }

    /// <summary>
    /// 结果：0-首次跟进 1-客户咨询 2-初次沟通 
    ///   3-需求确认 4-已成交 5-已流失
    /// </summary>
    public int? CfollowResult { get; set; }
}
