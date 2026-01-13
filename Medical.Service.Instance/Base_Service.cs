using Medical.Infrastructure.Dto.Response;

namespace Medical.Service.Instance
{
    public abstract class Base_Service
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Api_Response_Dto Get_Result(int code, string? message = "", object? data = null)
        {
            {
                Api_Response_Dto dto = new Api_Response_Dto()
                {
                    data = data
                };

                dto.code = code > 0 ? Api_Code.ok : Api_Code.fail;
                dto.message = string.IsNullOrEmpty(message)
                    ? (code > 0 ? "操作成功" : "操作失败") : message;

                return dto;
            }
        }

    }
}
