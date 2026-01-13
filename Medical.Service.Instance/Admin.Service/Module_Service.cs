using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.module;
using Medical.Infrastructure.Dto.Request.Module;
using Medical.Infrastructure.Dto.Response;
using Medical.Infrastructure.Dto.Response.Module;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.IOC;
using Medical.Infrastructure.Tools;
using Medical.Service.Interface.Admin.Service;
using Microsoft.EntityFrameworkCore;

namespace Medical.Service.Instance.Admin.Service
{
    [Inject_]
    public class Module_Service : Base_Service, I_Module_Service
    {
        private readonly Module_IOC _module_IOC;

        public Module_Service(Module_IOC module_IOC)
        {
            _module_IOC = module_IOC;
        }

        public async Task<Api_Response_Dto> Add_in_bulk_Module(Add_in_bulk_Module_Request_Dto dto)
        {
            // 1. 参数验证
            if (dto == null || !dto.Modules.Any())
            {
                return Get_Result(-1 ,"参数不正确");
            }

            // 2. 提取请求中的模块ID用于重复检查
            var moduleIds = dto.Modules.Select(m => m.Name).ToList();
            if (moduleIds.Distinct().Count() != moduleIds.Count)
            {
                return Get_Result(-1,"模块名称不能重复");
            }

            var existingIds = await _module_IOC._sysModule_EFCore
                .QueryAll(m => moduleIds.Contains(m.Name))
                .Select(m => m.Id)
                .ToListAsync();

            if (existingIds.Any())
            {
                return Get_Result(-1,$"以下模块ID已存在：{string.Join(",", existingIds)}");
            }

            try
            {
                // 4. 转换DTO为实体对象
                var modulesToAdd = dto.Modules.Select(m => new SysModule
                {
                    Id = m.Id,
                    Name = m.Name,
                    Icon = m.Icon,
                    ParentId = m.ParentId,
                    Route = m.Route,
                    IsShow = m.IsShow, // 默认显示
                    OrderNum = m.OrderNum, // 默认排序号
                    Status = m.Status, // 默认启用
                    CreateTime = DateTime.Now // 自动填充当前时间
                }).ToList();

                // 5. 批量添加到数据库
                await _module_IOC._sysModule_EFCore.AddRangeAsync(modulesToAdd);
                await _module_IOC._sysModule_EFCore.SaveChangesAsync();

                return Get_Result(1,"批量添加模块成功", modulesToAdd.Count);
            }
            catch (DbUpdateException ex)
            {
                // 处理数据库更新异常（如外键约束错误）
                return Get_Result(-1,$"数据库操作失败：{ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                // 处理其他异常
                return Get_Result(-1,$"批量添加模块失败：{ex.Message}");
            }
        }

        public async Task<Api_Response_Dto> Add_Module(Add_Module_Request_Dto dto)
        {
            try
            {
                // 1. 对传入的 DTO 进行空值校验，增强代码健壮性
                if (dto == null)
                {
                    return Get_Result(-1, "传入的模块数据不能为空");
                }

                // 2. 检查模块名称是否已存在
                var isNameExists = await _module_IOC._sysModule_EFCore
                    .QueryAll()
                    .AnyAsync(m => m.Name == dto.Name);

                if (isNameExists)
                {
                    return Get_Result(-1, $"模块名称 '{dto.Name}' 已存在，无法添加");
                }

                // 3. 构建要新增的模块实体
                var newModule = new SysModule
                {
                    // 修正：确保 Config.GUID 是一个方法调用，用于生成唯一ID
                    Id = dto.Id,
                    Name = dto.Name,
                    Icon = dto.Icon,
                    ParentId = dto.ParentId!,
                    Route = dto.Route,
                    IsShow = dto.IsShow,
                    OrderNum = dto.OrderNum,
                    Status = dto.Status,
                    CreateTime = DateTime.Now
                };

                // 4. 执行单个新增操作
                await _module_IOC._sysModule_EFCore.AddAsync(newModule);
                var saveResult = await _module_IOC._sysModule_EFCore.SaveChangesAsync();

                // 5. 根据保存结果返回相应信息
                return saveResult > 0
                    ? Get_Result(1, "模块添加成功")
                    : Get_Result(-1, "模块添加失败，未对数据库造成任何更改");
            }
            catch (Exception ex)
            {
                // 捕获并返回异常信息，便于问题排查
                return Get_Result(-1, $"添加模块时发生异常：{ex.Message}");
            }
        }

        public async Task<Api_Response_Dto> Delete_Module(int id)   
        {
            try
            {
                Console.WriteLine($"尝试删除模块，接收的ID：{id}");

                var module = await _module_IOC._sysModule_EFCore.QueryAll()
                    .Where(m => m.Id == id) 
                    .FirstOrDefaultAsync();

                if (module == null)
                {
                    var allIds = await _module_IOC._sysModule_EFCore.QueryAll()
                        .Select(m => m.Id)
                        .ToListAsync();
                    Console.WriteLine($"未找到ID为{id}的模块，当前存在的ID：{string.Join(",", allIds)}");
                    return Get_Result(-1, $"模块不存在，无法删除（ID：{id}）");
                }

                var hasChildren = await _module_IOC._sysModule_EFCore.QueryAll()
                    .AnyAsync(m => m.ParentId == id); // ParentId为string类型
                if (hasChildren)
                {
                    return Get_Result(-1, "该模块存在子模块，无法删除");
                }

                await _module_IOC._sysModule_EFCore.DeleteAsync(module);
                var saveResult = await _module_IOC._sysModule_EFCore.SaveChangesAsync();

                return saveResult > 0
                    ? Get_Result(1, "删除成功")
                    : Get_Result(-1, "删除失败");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"删除模块异常：{ex.Message}，堆栈：{ex.StackTrace}");
                return Get_Result(-1, $"删除模块异常：{ex.Message}");
            }
        }

        public async Task<Api_Response_Dto?> Get_Admin_Module(Module_Request_Dto dto)
        {
            try
            {
                dto.keyword = dto.keyword ?? "";
                dto.page = dto.page < 1 ? 1 : dto.page;
                dto.limit = dto.limit < 1 ? 10 : dto.limit;

                var moduleBaseList = await _module_IOC._sysModule_EFCore.QueryAll(
                    out int total,
                    dto.page,
                    dto.limit,
                    false,
                    m => m.OrderNum,
                    m => (string.IsNullOrEmpty(dto.keyword) || m.Name.Contains(dto.keyword))
                         && (dto.status == -1 || m.Status == dto.status)
                )
                .Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Icon = m.Icon,
                    ParentId = m.ParentId,
                    Route = m.Route,
                    IsShow = m.IsShow,
                    OrderNum = m.OrderNum,
                    Status = m.Status,
                    CreateTime = m.CreateTime
                })
                .ToListAsync();

                var parentIds = moduleBaseList
                    .Select(m => m.ParentId)
                    .Distinct()
                    .ToList();

                var parentModuleDict = await _module_IOC._sysModule_EFCore.QueryAll()
                    .Where(p => parentIds.Contains(p.Id)) // 均为string类型，直接匹配
                    .ToDictionaryAsync(p => p.Id, p => p.Name);

                var resultList = moduleBaseList.Select(m => new Module_Response_Dto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Icon = m.Icon,
                    ParentId = m.ParentId,
                    ParentName = parentModuleDict.TryGetValue((int)m.ParentId, out var parentName) ? parentName : "顶级模块",
                    Route = m.Route,
                    IsShow = m.IsShow,
                    OrderNum = m.OrderNum,
                    Status = m.Status,
                    CreateTime = m.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                }).ToList();

                return Get_Result(1, "查询成功", new { list = resultList, total });
            }
            catch (Exception ex)
            {
                return Get_Result(-1, $"查询模块异常：{ex.Message}");
            }
        }

        public async Task<Api_Response_Dto> Get_All_Module()
        {
            try
            {
                // 增加空值检查
                if (_module_IOC == null)
                    return Get_Result(-1, "模块IOC容器未初始化");

                if (_module_IOC._sysModule_EFCore == null)
                    return Get_Result(-1, "SysModule_EFCore服务未初始化");

                var allModules = await _module_IOC._sysModule_EFCore.QueryAll()
                    .ToListAsync();

                // 关键修改：将int类型的0改为string类型的"0"，与ParentId的string类型匹配
                var treeDtos = BuildModuleTree(allModules, 0);
                return Get_Result(1, "获取成功", treeDtos);
            }
            catch (Exception ex)
            {
                // 记录详细错误日志
                // _logger.LogError(ex, "获取模块列表失败");
                return Get_Result(-1, $"获取失败：{ex.Message}");
            }
        }
        // 递归方法的parentId参数已改为string类型，与实体属性一致
        private List<ModuleTree_Response_Dto> BuildModuleTree(List<SysModule> allModules, int parentId)
        {
            return allModules
                .Where(m => m.ParentId == parentId) // string类型比较
                .OrderBy(m => m.OrderNum)
                .Select(m => new ModuleTree_Response_Dto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Icon = m.Icon,
                    ParentId = (int)m.ParentId,
                    Route = m.Route,
                    IsShow = m.IsShow,
                    OrderNum = m.OrderNum,
                    Status = m.Status,
                    CreateTime = m.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Children = BuildModuleTree(allModules, m.Id) // 传入string类型的Id作为子节点的parentId
                })
                .ToList();
        }


        public async Task<Api_Response_Dto> Revise_Module(int id, Add_Module_Request_Dto dto)
        {
            try
            {
                var module = await _module_IOC._sysModule_EFCore.QueryAll()
                    .FirstOrDefaultAsync(m => m.Id == id); // Id为string类型
                if (module == null)
                {
                    return Get_Result(-1, "模块不存在或者被删除");
                }

                var isNameExists = await _module_IOC._sysModule_EFCore.QueryAll()
                    .AnyAsync(m => m.Name == dto.Name && m.Id != id); // 均为string类型比较
                if (isNameExists)
                {
                    return Get_Result(-1, "模块名称已存在，不能修改");
                }

                module.Name = dto.Name;
                module.Icon = dto.Icon;
                module.ParentId = dto.ParentId; // 确保dto.ParentId是string类型
                module.Route = dto.Route;
                module.IsShow = dto.IsShow;
                module.OrderNum = dto.OrderNum;
                module.Status = dto.Status;

                _module_IOC._sysModule_EFCore.Update(module);
                await _module_IOC._sysModule_EFCore.SaveChangesAsync();

                return Get_Result(1, "修改成功");
            }
            catch (Exception ex)
            {
                return Get_Result(-1, $"修改模块异常：{ex.Message}");
            }
        }
    }
}