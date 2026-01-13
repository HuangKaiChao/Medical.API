using System.Linq.Expressions;

namespace Medical.Repository.Interface;

// ReSharper disable once InconsistentNaming
public interface I_Repository<T> where T : class, new()
{
    /// <summary>
    /// 单个新增
    /// </summary>
    /// <param name="t"></param>
    void Add(T t);
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="ie"></param>
    void AddRange(IEnumerable<T> ie);

    /// <summary>
    /// 异步单个新增
    /// </summary>
    /// <param name="t"></param>
    Task AddAsync(T t);
    /// <summary>
    /// 异步批量新增
    /// </summary>
    /// <param name="ie"></param>
    Task AddRangeAsync(IEnumerable<T> ie);
    /// <summary>
    /// 单个删除
    /// </summary>
    /// <param name="t"></param>
    void Delete(T t);
    /// <summary>
    /// 异步单个删除
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    Task DeleteAsync(T t);
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ie"></param>
    void DeleteRange(IEnumerable<T> ie);

    /// <summary>
    /// 异步批量删除
    /// </summary>
    /// <param name="ie"></param>
    Task DeleteRangeAsync(IEnumerable<T> ie);
    /// <summary>
    /// 单个修改
    /// </summary>
    /// <param name="t"></param>
    void Update(T t);

    /// <summary>
    /// 批量修改
    /// </summary>
    /// <param name="ie"></param>
    void UpdateRange(IEnumerable<T> ie);

    /// <summary>
    /// 异步单个更新
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    Task UpdateAsync(T t);
    /// <summary>
    /// 异步批量更新
    /// </summary>
    /// <param name="ie"></param>
    /// <returns></returns>
    Task UpdateRangeAsync(IEnumerable<T> ie);

    /// <summary>
    /// 保存
    /// </summary>
    /// <returns></returns>
    int SaveChanges();

    /// <summary>
    /// 异步保存
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
    /// <summary>
    /// 查询
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null);

    /// <summary>
    /// 查询并排序
    /// </summary>
    /// <typeparam name="t">排序类型</typeparam>
    /// <param name="isAsc">升序/降序</param>
    /// <param name="order">排序条件</param>
    /// <param name="where">查询条件</param>
    /// <returns></returns>
    IQueryable<T> QueryAll<t>(bool isAsc = true, Expression<Func<T, t>>? order = null, Expression<Func<T, bool>>? where = null);


    /// <summary>
    /// 查询排序并分页
    /// </summary>
    /// <typeparam name="t">排序类型</typeparam>
    /// <param name="total">总条数(输出)</param>
    /// <param name="skip">跳过的条数(0)</param>
    /// <param name="take">获取的条数(10)</param>
    /// <param name="isAsc">升序/降序</param>
    /// <param name="order">排序条件</param>
    /// <param name="where">查询条件</param>
    /// <returns></returns>
    IQueryable<T> QueryAll<t>(out int total, int skip = 0, int take = 10, bool isAsc = true, Expression<Func<T, t>>? order = null, Expression<Func<T, bool>>? where = null);
}