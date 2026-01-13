using System.Linq.Expressions;
using Medical.Repository.Interface;
using Microsoft.EntityFrameworkCore;
namespace Medical.Repository.Instance;

public class MySql_Repository<T> : I_Repository<T> where T : class, new()
{
    private readonly DbContext _dbContext;

    public MySql_Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 单个新增
    /// </summary>
    /// <param name="t"></param>
    public void Add(T t)
    {
        _dbContext.Set<T>().Add(t);
    }
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="ie"></param>
    public void AddRange(IEnumerable<T> ie)
    {
        _dbContext.Set<T>().AddRange(ie);
    }

    /// <summary>
    /// 异步单个新增
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public async Task AddAsync(T t)
    {
        await _dbContext.Set<T>().AddAsync(t);
    }

    /// <summary>
    /// 异步批量新增
    /// </summary>
    /// <param name="ie"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddRangeAsync(IEnumerable<T> ie)
    {
        await _dbContext.Set<T>().AddRangeAsync(ie);
    }

    /// <summary>
    /// 单个删除
    /// </summary>
    /// <param name="t"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Delete(T t)
    {
        _dbContext.Set<T>().Remove(t);
    }
    /// <summary>
    /// 异步单个删除
    /// </summary>
    /// <param name="t"></param>
    public Task DeleteAsync(T t)
    {
        _dbContext.Set<T>().Remove(t);
        return Task.CompletedTask;
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ie"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void DeleteRange(IEnumerable<T> ie)
    {
        _dbContext.Set<T>().RemoveRange(ie);
    }

    /// <summary>
    /// 异步批量删除
    /// </summary>
    /// <param name="ie"></param>
    public Task DeleteRangeAsync(IEnumerable<T> ie)
    {
        _dbContext.Set<T>().RemoveRange(ie);
        return Task.CompletedTask;
    }
    /// <summary>
    /// 单个修改
    /// </summary>
    public void Update(T t)
    {
        _dbContext.Set<T>().Update(t);
    }
    /// <summary>
    /// 批量修改
    /// </summary>
    /// <param name="ie"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void UpdateRange(IEnumerable<T> ie)
    {
        _dbContext.Set<T>().UpdateRange(ie);
    }

    /// <summary>
    /// 异步单个修改
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public Task UpdateAsync(T t)
    {
        _dbContext.Set<T>().Update(t);
        return Task.CompletedTask;
    }

    /// <summary>
    /// 异步批量修改
    /// </summary>
    /// <param name="ie"></param>
    /// <returns></returns>
    public Task UpdateRangeAsync(IEnumerable<T> ie)
    {
        _dbContext.Set<T>().UpdateRange(ie);
        return Task.CompletedTask;
    }

    /// <summary>
    /// 保存更改
    /// </summary>
    /// <returns></returns>
    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    /// <summary>
    /// 异步保存更改
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// 查询所有
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null)
    {
        var iq = (IQueryable<T>)_dbContext.Set<T>();
        return where == null ? iq : iq.Where(where);
    }
    /// <summary>
    /// 查询并排序
    /// </summary>
    /// <param name="isAsc"></param>
    /// <param name="order"></param>
    /// <param name="where"></param>
    /// <typeparam name="t"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll<t>(bool isAsc = true, Expression<Func<T, t>>? order = null, Expression<Func<T, bool>>? where = null)
    {
        var iq = QueryAll(where);
        return isAsc ? iq.OrderBy(order!) : iq.OrderByDescending(order!);
    }
    /// <summary>
    /// 查询排序并分页
    /// </summary>
    /// <param name="total"></param>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <param name="isAsc"></param>
    /// <param name="order"></param>
    /// <param name="where"></param>
    /// <typeparam name="t"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll<t>(out int total, int skip = 0, int take = 10, bool isAsc = true, Expression<Func<T, t>>? order = null, Expression<Func<T, bool>>? where = null)
    {
        var iq = QueryAll(isAsc, order, where);
        total = iq.Count();
        return iq.Skip(skip).Take(take);
    }
}