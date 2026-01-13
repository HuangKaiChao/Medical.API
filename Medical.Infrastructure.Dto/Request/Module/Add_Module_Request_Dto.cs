namespace Medical.Infrastructure.Dto.Request.Module
{

    /// <summary>
    /// 单个模块详情DTO
    /// </summary>
    public class Add_Module_Request_Dto
    {

        public int Id { get; set; }
        /// <summary>
        /// 模块名称（必填，需唯一）
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标标识
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// 父级模块ID（0为顶级）
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        public string? Route { get; set; }

        /// <summary>
        /// 是否显示（1=显示，0=隐藏）
        /// </summary>
        public int IsShow { get; set; } = 1;

        /// <summary>
        /// 排序序号
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 状态（1=启用，0=禁用）
        /// </summary>
        public int Status { get; set; } = 1;
    }
}