namespace Medical.Infrastructure.Dto.Response;

public class Api_Response_Dto
{
    /// <summary>
    /// 执行结果的状态码
    /// </summary>
    public Api_Code code { get; set; }

    /// <summary>
    /// 执行结果的消息
    /// </summary>
    public string? message { get; set; }

    /// <summary>
    /// 执行结果的数据
    /// </summary>
    public object? data { get; set; }
}