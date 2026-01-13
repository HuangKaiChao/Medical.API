namespace Medical.Infrastructure.Attr;

/// <summary>
/// 操作行为属性
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class Action_Attribute:Attribute
{
    /// <summary>
    /// 模块名称
    /// </summary>
    public string? Group { get; set; }
    
    /// <summary>
    /// 操作行为
    /// </summary>
    public string? Action { get; set; }
}