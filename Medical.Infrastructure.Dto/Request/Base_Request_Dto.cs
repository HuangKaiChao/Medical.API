namespace Medical.Infrastructure.Dto.Request
{
    /// <summary>
    /// 基础分页与模糊查询
    /// </summary>
    public class Base_Request_Dto
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 每页多少条数据
        /// </summary>
        public int limit { get; set; } = 10;

        /// <summary>
        /// 模糊查询
        /// </summary>
        public string? keyword { get; set; }

        /// <summary>
        /// 搜索-时间范围
        /// </summary>
        public List<string>? keyword_time { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? status { get; set; }
    }
}
