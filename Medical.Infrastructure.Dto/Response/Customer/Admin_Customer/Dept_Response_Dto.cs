using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Response.Customer.Admin_Customer
{
    public class Dept_Response_Dto
    {
        /// <summary>
        /// 部门id
        /// </summary>
        public string? id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        ///  部门图标
        /// </summary>
        public string? icon { get; set; }
        /// <summary>
        ///  创建时间
        /// </summary>
        public string? time { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int? level { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? explain { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// 父部门id
        /// </summary>
        public string? parent_id { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int? isBan { get; set; }
        /// <summary>
        /// 子部门
        /// </summary>
        public List<Dept_Response_Dto>? children { get; set; }

        /// <summary>
        /// 职务列表
        /// </summary>
        public List<string>? duty_dids { get; set; }
    }
}
