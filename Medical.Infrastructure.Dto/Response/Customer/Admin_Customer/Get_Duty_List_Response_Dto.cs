using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Response.Customer.Admin_Customer
{
    public class Get_Duty_List_Response_Dto
    {
        /// <summary>
        /// 岗位id
        /// </summary>
        public string? id { get; set; }
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public string? dept_id { get; set; }
        /// <summary>
        /// 岗位数量
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// 岗位描述
        /// </summary>
        public string? description { get; set; }
        /// <summary>
        /// 岗位等级
        /// </summary>
        public int? level { get; set; }
        /// <summary>
        /// 岗位状态
        /// </summary>
        public int? isBan { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string? create_time { get; set; }
    }
}
