using Medical.Repository.Interface;
using Medical.Service.Interface;
using System.Linq.Expressions;
using System.Transactions;

namespace Medical.Service.EFCore;

public class Base_EFCore<T> : I_Base_EFCore<T> where T : class, new()
{

    private readonly I_Repository<T> _repository;

    public Base_EFCore(I_Repository<T> repository)
    {
        _repository = repository;
    }
    /// <summary>
    /// 单个新增
    /// </summary>
    /// <param name="t"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(T t)
    {
        _repository.Add(t);
    }
    /// <summary>
    /// 批量新增
    /// </summary>
    /// <param name="ie"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddRange(IEnumerable<T> ie)
    {
        _repository.AddRange(ie);
    }
    /// <summary>
    /// 异步单个新增
    /// </summary>
    public async Task AddAsync(T entity)
    {
        await _repository.AddAsync(entity);
    }

    /// <summary>
    /// 异步批量新增
    /// </summary>
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _repository.AddRangeAsync(entities);
    }
    /// <summary>
    /// 单个删除
    /// </summary>
    /// <param name="t"></param>
    public void Delete(T t)
    {
        _repository.Delete(t);
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="ie"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void DeleteRange(IEnumerable<T> ie)
    {
        _repository.DeleteRange(ie);
    }
    /// <summary>
    /// 异步单个删除
    /// </summary>
    /// <param name="t"></param>
    public async Task DeleteAsync(T t)
    {
        await _repository.DeleteAsync(t);
    }
    /// <summary>
    /// 异步批量删除
    /// </summary>
    /// <param name="ie"></param>
    public async Task DeleteRangeAsync(IEnumerable<T> ie)
    {
        await _repository.DeleteRangeAsync(ie);
    }
    /// <summary>
    /// 单个更新
    /// </summary>
    /// <param name="t"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(T t)
    {
        _repository.Update(t);
    }
    /// <summary>
    /// 批量更新
    /// </summary>
    /// <param name="ie"></param>
    public void UpdateRange(IEnumerable<T> ie)
    {
        _repository.UpdateRange(ie);
    }
    /// <summary>
    /// 异步单个更新
    /// </summary>
    public async Task UpdateAsync(T entity)
    {
        await _repository.UpdateAsync(entity);
    }

    /// <summary>
    /// 异步批量更新
    /// </summary>
    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        await _repository.UpdateRangeAsync(entities);
    }
    /// <summary>
    /// 保存更改
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int SaveChanges()
    {
        return _repository.SaveChanges();
    }

    /// <summary>
    ///  异步保存更改
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<int> SaveChangesAsync()
    {
        return _repository.SaveChangesAsync();
    }

    /// <summary>
    /// 查询所有
    /// </summary>
    /// <param name="where"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll(Expression<Func<T, bool>>? where = null)
    {
        return _repository.QueryAll(where);
    }
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="isAsc"></param>
    /// <param name="order"></param>
    /// <param name="where"></param>
    /// <typeparam name="t"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll<t>(bool isAsc = true, Expression<Func<T, t>>? order = null, Expression<Func<T, bool>>? where = null)
    {
        return _repository.QueryAll(isAsc, order, where);
    }
    /// <summary>
    /// 查询排序并分页
    /// </summary>
    /// <param name="total"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="isAsc"></param>
    /// <param name="order"></param>
    /// <param name="where"></param>
    /// <typeparam name="t"></typeparam>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IQueryable<T> QueryAll<t>(out int total, int page = 1, int limit = 10, bool isAsc = true, Expression<Func<T, t>>? order = null,
        Expression<Func<T, bool>>? where = null)
    {
        return _repository.QueryAll(out total, (page - 1) * limit, limit, isAsc, order, where);
    }

    #region 同步方法 (2-10张表)

    /// <summary>
    /// 分布式事务处理 同时处理2张表
    /// </summary>
    public bool Transactions<T1>(I_Base_EFCore<T1> bs)
        where T1 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            // 记录日志
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理3张表
    /// </summary>
    public bool Transactions<T1, T2>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2)
        where T1 : class, new()
        where T2 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理4张表
    /// </summary>
    public bool Transactions<T1, T2, T3>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理5张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理6张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4, T5>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                bs5.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理7张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4, T5, T6>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                bs5.SaveChanges();
                bs6.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理8张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4, T5, T6, T7>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                bs5.SaveChanges();
                bs6.SaveChanges();
                bs7.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理9张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4, T5, T6, T7, T8>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7, I_Base_EFCore<T8> bs8)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
        where T8 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                bs5.SaveChanges();
                bs6.SaveChanges();
                bs7.SaveChanges();
                bs8.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 分布式事务处理 同时处理10张表
    /// </summary>
    public bool Transactions<T1, T2, T3, T4, T5, T6, T7, T8, T9>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7, I_Base_EFCore<T8> bs8, I_Base_EFCore<T9> bs9)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
        where T8 : class, new()
        where T9 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                this.SaveChanges();
                bs.SaveChanges();
                bs2.SaveChanges();
                bs3.SaveChanges();
                bs4.SaveChanges();
                bs5.SaveChanges();
                bs6.SaveChanges();
                bs7.SaveChanges();
                bs8.SaveChanges();
                bs9.SaveChanges();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"事务处理失败: {ex.Message}");
            return false;
        }
    }

    #endregion

    #region 异步方法 (2-10张表)

    /// <summary>
    /// 异步分布式事务处理 同时处理2张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1>(I_Base_EFCore<T1> bs)
        where T1 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理3张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2)
        where T1 : class, new()
        where T2 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理4张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理5张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理6张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4, T5>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                await bs5.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理7张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4, T5, T6>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                await bs5.SaveChangesAsync();
                await bs6.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理8张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4, T5, T6, T7>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                await bs5.SaveChangesAsync();
                await bs6.SaveChangesAsync();
                await bs7.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理9张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4, T5, T6, T7, T8>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7, I_Base_EFCore<T8> bs8)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
        where T8 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                await bs5.SaveChangesAsync();
                await bs6.SaveChangesAsync();
                await bs7.SaveChangesAsync();
                await bs8.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 异步分布式事务处理 同时处理10张表
    /// </summary>
    public async Task<bool> TransactionsAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(I_Base_EFCore<T1> bs, I_Base_EFCore<T2> bs2, I_Base_EFCore<T3> bs3, I_Base_EFCore<T4> bs4, I_Base_EFCore<T5> bs5, I_Base_EFCore<T6> bs6, I_Base_EFCore<T7> bs7, I_Base_EFCore<T8> bs8, I_Base_EFCore<T9> bs9)
        where T1 : class, new()
        where T2 : class, new()
        where T3 : class, new()
        where T4 : class, new()
        where T5 : class, new()
        where T6 : class, new()
        where T7 : class, new()
        where T8 : class, new()
        where T9 : class, new()
    {
        try
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.SaveChangesAsync();
                await bs.SaveChangesAsync();
                await bs2.SaveChangesAsync();
                await bs3.SaveChangesAsync();
                await bs4.SaveChangesAsync();
                await bs5.SaveChangesAsync();
                await bs6.SaveChangesAsync();
                await bs7.SaveChangesAsync();
                await bs8.SaveChangesAsync();
                await bs9.SaveChangesAsync();
                transactionScope.Complete();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"异步事务处理失败: {ex.Message}");
            return false;
        }
    }

    #endregion
}