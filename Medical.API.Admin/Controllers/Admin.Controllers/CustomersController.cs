using Medical.Api.Admin.Controllers;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Customer.isBan_Customer;
using Medical.Service.Instance.Admin.Service;
using Medical.Service.Interface.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace Medical.API.Admin.Controllers.Admin.Controllers
{
    /// <summary>
    /// 管理端-客户-控制器
    /// </summary>
    public class CustomersController: BaseController
    {
        private readonly I_Customer_Service _customer_Service;

        public CustomersController(I_Customer_Service customer_Service)
        {
            _customer_Service = customer_Service;
        }

        /// <summary>
        /// 获取全部客户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get_All_Customers(Get_All_Customer_Request_Dto dto)
        {
            var result = await _customer_Service.Get_All_Customer(dto);
            return Ok(result);
        }

        /// <summary>
        /// 删除单个客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete_Customer([FromForm]string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("客户ID不能为空");
            }
            var result = await _customer_Service.Delete_Customer(id);
            return Ok(result);
        }

        /// <summary>
        /// 禁用客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> isBan_Customer(isBan_Customer_Request_Dto dto)
        {
            var result = await _customer_Service.isBan_Customer(dto);
            return Ok(result);
        }
    }
}
