using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Response.Module
{
    public class ModuleTree_Response_Dto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Icon { get; set; }
        public int ParentId { get; set; }
        public string? Route { get; set; }
        public int IsShow { get; set; }
        public int OrderNum { get; set; }
        public int Status { get; set; }
        public string CreateTime { get; set; } = ""; // 格式化后的时间
        public List<ModuleTree_Response_Dto> Children { get; set; } = new(); // 子模块（仅DTO有）
    }
}
