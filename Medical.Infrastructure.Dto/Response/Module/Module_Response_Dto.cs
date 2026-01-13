namespace Medical.Infrastructure.Dto.Response.Module
{
    public class Module_Response_Dto
    {
        public int? Id { get; set; } // 主键ID
        public string? Name { get; set; } = ""; // 模块名称
        public string? Icon { get; set; } // 图标标识
        public int? ParentId { get; set; } // 父级模块ID
        public string? ParentName { get; set; } // 父级模块名称（关联查询后返回）
        public string? Route { get; set; } // 路由地址
        public int? IsShow { get; set; } // 是否显示
        public int? OrderNum { get; set; } // 排序序号
        public int? Status { get; set; } // 状态
        public string? CreateTime { get; set; } // 创建时间

    }
}
