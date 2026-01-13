using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Request.Customer.Admin_Customer
{
    /// <summary>
    /// 实现添加客户请求Dto
    /// </summary>
    public class Add_Customer_Request_Dto
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 客户手机号/账号
        /// </summary>
        public string? phone { get; set; }
        /// <summary>
        /// 客户性别
        /// </summary>
        public int? gender { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? status { get; set; }
        /// <summary>
        /// 客户生日
        /// </summary>
        public string? birthday { get; set; }
        /// <summary>
        /// 客户诉求
        /// </summary>
        public string? health_concerns { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        public int? referral_type { get; set; }
        /// <summary>
        /// 负责人id
        /// </summary>
        public string? assignee_id { get; set; }
    }
}
