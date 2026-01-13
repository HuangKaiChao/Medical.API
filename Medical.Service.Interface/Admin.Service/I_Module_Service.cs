using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.module;
using Medical.Infrastructure.Dto.Request.Module;
using Medical.Infrastructure.Dto.Response;

namespace Medical.Service.Interface.Admin.Service
{
    [Provider_]
    public interface I_Module_Service
    {
        /// <summary>
        /// 获取管理端模块数据
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto?> Get_Admin_Module(Module_Request_Dto dto);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Api_Response_Dto> Get_All_Module();


        Task<Api_Response_Dto>Add_Module(Add_Module_Request_Dto dto);


        Task<Api_Response_Dto> Delete_Module(int id);


        Task<Api_Response_Dto> Revise_Module(int id,Add_Module_Request_Dto dto);

        Task<Api_Response_Dto> Add_in_bulk_Module(Add_in_bulk_Module_Request_Dto dto);
    }   
}
