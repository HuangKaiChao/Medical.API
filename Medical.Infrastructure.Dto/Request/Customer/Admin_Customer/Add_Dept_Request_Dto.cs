using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Request.Customer.Admin_Customer
{
    public class Add_Dept_Request_Dto
    {

        /// <summary>
        /// 部门名称
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 部门级别
        /// </summary>
        public int? level { get; set; }
        /// <summary>
        /// 部门图标
        /// </summary>
        public string? icon { get; set; }
        /// <summary>
        /// 父部门id
        /// </summary>
        public string? parent_id { get; set; }
        /// <summary>
        /// 该部门所选择的岗位id
        /// </summary>
        public List<string>? dids { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string? explain { get; set; }
    }
}
