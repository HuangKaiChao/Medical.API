namespace Medical.Infrastructure.Dto.Response.Customer.Admin_Customer
{
    public class Get_All_Customer_Response_Dto
    {

        /// <summary>
        /// 客户id
        /// </summary>
        public string id { get; set; } = null!;

        /// <summary>
        /// 头像
        /// </summary>
        public string? avatar { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string name { get; set; } = null!;

        /// <summary>
        /// 账号/手机号码
        /// </summary>
        public string account { get; set; } = null!;

        /// <summary>
        /// 微信号
        /// </summary>
        public string? wechat { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string? birthday { get; set; }

        /// <summary>
        /// 性别(0:男,1:女)
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// 健康主诉
        /// </summary>
        public string? health_concerns { get; set; }

        /// <summary>
        /// 客户来源
        /// </summary>
        public string? source { get; set; }

        /// <summary>
        /// 负责人id
        /// </summary>
        public string? assignee_id { get; set; }
        /// <summary>
        /// 负责人姓名
        /// </summary>
        public string? assignee_name { get; set; }
        /// <summary>
        /// 负责人账号
        /// </summary>
        public string? assignee_account { get; set; }
        /// <summary>
        /// 状态(0:公海,1:跟进中,2:VIP)
        /// </summary>
        public int? status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string? create_time { get; set; }

        /// <summary>
        /// 是否禁用(0:否,1:是)
        /// </summary>
        public int? isBan { get; set; }

        /// <summary>
        /// 是否激活(0:否,1:是)
        /// </summary>
        public int? isActive { get; set; }
        /// <summary>
        /// 总消费金额
        /// </summary>
        public decimal? total_consumption { get; set; }
        /// <summary>
        /// 钱包余额
        /// </summary>
        public decimal? balance { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public int? level { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int? order_count { get; set; }
        /// <summary>
        /// 跟进数量
        /// </summary>
        public int? followup_count { get; set; }
    }
}
