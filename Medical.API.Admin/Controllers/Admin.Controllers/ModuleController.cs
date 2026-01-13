using Medical.Api.Admin.Controllers;
using Medical.Infrastructure.Dto.Request.module;
using Medical.Infrastructure.Dto.Request.Module;
using Medical.Infrastructure.Dto.Response;
using Medical.Service.Instance.Admin.Service;
using Medical.Service.Interface.Admin.Service;
using Microsoft.AspNetCore.Mvc;

namespace Medical.API.Admin.Controllers.Admin.Controllers
{
    /// <summary>
    /// 模块管理控制器
    /// </summary>
    public class ModuleController : BaseController
    {
        private readonly I_Module_Service _module_Service;

        public ModuleController(I_Module_Service module_Service)
        {
            _module_Service = module_Service;
        }

        /// <summary>
        /// 获取管理端模块数据（树形结构）
        /// </summary>
        /// <param name="dto">请求参数（支持分页、搜索等）</param>
        /// <returns>统一API响应，包含树形模块数据</returns>
        [HttpGet]
        public async Task<IActionResult> GetModules([FromForm] Module_Request_Dto dto)
        {
           var result = await _module_Service.Get_Admin_Module(dto);
            return Ok(result);
        }

        /// <summary>
        /// 获取全部模块列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get_All_Modules()
        {
            var result = await _module_Service.Get_All_Module();
            return Ok(result);
        }

        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>Add_Module(Add_Module_Request_Dto dto)
        {
            var result = await _module_Service.Add_Module(dto);
            return Ok(result);
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete_Module([FromForm] int id)
        {
            var result = await _module_Service.Delete_Module(id);
            return Ok(result);
        }

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Revise_Module(int id, [FromBody]Add_Module_Request_Dto dto)
        {
            var result = await _module_Service.Revise_Module(id, dto);
            return Ok(result);
        }

        /// <summary>
        /// 批量添加模块
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add_in_bulk_Module(Add_in_bulk_Module_Request_Dto dto)
        {
            var result = await _module_Service.Add_in_bulk_Module(dto);
            return Ok(result);
        }
    }
}
