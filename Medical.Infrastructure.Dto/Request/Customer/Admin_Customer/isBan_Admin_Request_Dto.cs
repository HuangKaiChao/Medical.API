using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Dto.Request.Customer.Admin_Customer
{
    public class isBan_Admin_Request_Dto
    {
        public List<string>? eid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? status { get; set; }

    }
}
