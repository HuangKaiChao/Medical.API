using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Request.Module
{
    public class Add_in_bulk_Module_Request_Dto
    {
        public List<Module_Dto> Modules { get; set; } = new List<Module_Dto>();
    }

    public class Module_Dto
    {
        public int Id { get; set; } // 对应id字段
        public string Name { get; set; } // 对应name字段
        public string Icon { get; set; } // 对应icon字段
        public int ParentId { get; set; } // 对应parent_id字段
        public string Route { get; set; } // 对应route字段
        public int IsShow { get; set; } // 对应is_show字段（1=显示，0=隐藏）
        public int OrderNum { get; set; } // 对应order_num字段
        public int Status { get; set; } // 对应status字段（1=启用，0=禁用）
    }
}

