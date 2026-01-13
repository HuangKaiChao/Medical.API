using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Customer.isBan_Customer;
using Medical.Infrastructure.Dto.Response;

namespace Medical.Service.Interface.Admin.Service
{
    [Provider_]
    public interface I_Customer_Service
    {
        /// <summary>
        /// 获取全部客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Get_All_Customer(Get_All_Customer_Request_Dto dto);

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Delete_Customer(string id);

        /// <summary>
        /// 禁用客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> isBan_Customer(isBan_Customer_Request_Dto dto);


        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Api_Response_Dto> Add_Customer(Add_Customer_Request_Dto dto);
    }
}
