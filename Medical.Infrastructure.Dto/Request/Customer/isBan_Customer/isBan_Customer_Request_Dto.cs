namespace Medical.Infrastructure.Dto.Request.Customer.isBan_Customer
{
    public class isBan_Customer_Request_Dto
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public List<string>? cids { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? status { get; set; }
    }
}
