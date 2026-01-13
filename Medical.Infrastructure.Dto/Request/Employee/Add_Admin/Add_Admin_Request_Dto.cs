namespace Medical.Infrastructure.Dto.Request.Employee.Add_Admin
{
    public class Add_Admin_Request_Dto
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 员工昵称
        /// </summary>
        public string? nick { get; set; }
        /// <summary>
        /// 员工邮箱
        /// </summary>
        public string? email { get; set; }
        /// <summary>
        /// 员工性别
        /// </summary>
        public int? gender { get; set; }
        /// <summary>
        /// 员工部门
        /// </summary>
        public string? dept_id { get; set; }
        /// <summary>
        /// 员工职务
        /// </summary>
        public string? duty_id { get; set; }
        /// <summary>
        /// 员工角色
        /// </summary>
        public List<string>? role_ids { get; set; }
        /// <summary>
        /// 员工账号
        /// </summary>
        public string? account { get; set; }
        /// <summary>
        /// 员工密码
        /// </summary>
        public string? password { get; set; }
        /// <summary>
        /// 员工头像
        /// </summary>
        public string? avatar { get; set; }
        /// <summary>
        /// 员工简介
        /// </summary>
        public string? explain { get; set; }
    }
}
