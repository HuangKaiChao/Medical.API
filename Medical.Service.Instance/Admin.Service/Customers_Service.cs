using Medical.Infrastructure.Attr;
using Medical.Infrastructure.Dto.Request.Customer.Admin_Customer;
using Medical.Infrastructure.Dto.Request.Customer.isBan_Customer;
using Medical.Infrastructure.Dto.Response;
using Medical.Infrastructure.Dto.Response.Customer.Admin_Customer;
using Medical.Infrastructure.EFCore.MySql.Models;
using Medical.Infrastructure.IOC;
using Medical.Infrastructure.Tools;
using Medical.Service.Interface.Admin.Service;
using Microsoft.EntityFrameworkCore;

namespace Medical.Service.Instance.Admin.Service
{
    [Inject_]
    public class Customers_Service:Base_Service,I_Customer_Service
    {
        private readonly Customer_IOC _customer_IOC;
        private readonly Org_IOC _org_IOC;

        public Customers_Service(Customer_IOC customer_IOC,
            Org_IOC org_IOC) 
        {
            _customer_IOC = customer_IOC;
            _org_IOC = org_IOC;
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Api_Response_Dto> Add_Customer(Add_Customer_Request_Dto dto)
        {
            if (string.IsNullOrEmpty(dto.name))
            {
                return Get_Result(-1, "客户名不能为空");
            }
            if (string.IsNullOrEmpty(dto.phone))
            {
                return Get_Result(-1, "账号不能为空");
            }
            var salt = Config.GUID();
            var pwd = EncryptUtil.LoginMd5("123456", salt);
            var csource = "";
            switch (dto.referral_type)
            {
                case 0:
                    csource = "自然流量";
                    break;
                case 1:
                    csource = "线上推广";
                    break;
                case 2:
                    csource = "客户推荐";
                    break;
                case 3:
                    csource = "线下活动";
                    break;
                case 4:
                    csource = "其他";
                    break;
            }

            var customer = new CusCustomer()
            {
                Cid = Config.GUID(),
                Cname = dto.name,
                Cphone = dto.phone,
                Cgender = dto.gender,
                Cpassword = pwd,
                Cwechat = "",
                Cavatar = "http://localhost:5123/Files/Mobile.Files/Customers_Image/kehu.png",
                ChealthConcerns = dto.health_concerns,
                CreferralType = dto.referral_type,
                Csource = csource,
                CassigneeId = dto.assignee_id,
                Cstatus = dto.status,
                Cbirthday = DateOnly.TryParse(dto.birthday, out var data) ? data : null,
                CcreateTime = DateTime.Now,
                CisPromoter = 0,
                CisBan = 0,
                Cbalance = 0,
                CtotalConsumption= 0,
                CcancelAmount = 0,
                CancelOrderCount= 0,
                CorderCount= 0,
            };

            await _customer_IOC._customers_EFCore.AddAsync(customer);
            await _customer_IOC._cusCustomerPools_EFCore.AddAsync(new CusCustomerPool()
            {
                Cpid = Config.GUID(),
                CpcustomerId = customer.Cid,
                CpenterType = 2,
                CptakeTime = null,
                CplockStatus = 0,
                CplockOperatorId = null,
                CplockExpireTime = null,
                CptakeOperatorId = null,
                CpenterTime = DateTime.Now,
            });

            var result =await _customer_IOC._customers_EFCore.TransactionsAsync(_customer_IOC._cusCustomerPools_EFCore);

            return Get_Result(result  ?1 :-1,result ? "ok" :"fail");
        }

        public async Task<Api_Response_Dto> Delete_Customer(string id)
        {
            if (string.IsNullOrEmpty(id)) return Get_Result(0, "参数错误");

            var customer = await _customer_IOC._customers_EFCore.QueryAll(d => d.Cid == id).FirstOrDefaultAsync();
            if (customer == null) return Get_Result(0, "未找到客户!");
            if (customer!.CisActive == 1)
            {
                return Get_Result(0, "该客户已激活，不能删除!");
            }
            await _customer_IOC._customers_EFCore.DeleteAsync(customer);
            var result = await _customer_IOC._customers_EFCore.SaveChangesAsync();
            return Get_Result(result > 0 ? 1 : -1, result > 0 ? "ok" : "fail");
        }

        public async Task<Api_Response_Dto> Get_All_Customer(Get_All_Customer_Request_Dto dto)
        {
            dto.keyword = dto.keyword ?? "";
            dto.keyword_time = dto.keyword_time ?? new List<string>();
            // 初始化时间范围变量
            DateTime? startTime = null;
            DateTime? endTime = null;

            // 处理时间范围参数（如果有）
            if (dto.keyword_time.Count >= 2)
            {
                // 尝试解析开始时间
                if (!DateTime.TryParse(dto.keyword_time[0], out var parsedStartTime))
                {
                    return Get_Result(0, "开始时间格式不正确");
                }

                // 尝试解析结束时间 
                if (!DateTime.TryParse(dto.keyword_time[1], out var parsedEndTime))
                {
                    return Get_Result(0, "结束时间格式不正确");
                }

                // 验证时间范围有效性
                if (parsedStartTime > parsedEndTime)
                {
                    return Get_Result(0, "开始时间不能大于结束时间");
                }

                startTime = parsedStartTime;
                endTime = parsedEndTime.Date.AddDays(1).AddSeconds(-1); // 调整为当天最后一秒
            }
            var data = await _customer_IOC._customers_EFCore.QueryAll(out int total, dto.page, dto.limit, false,
                    o => o.CcreateTime, d => (string.IsNullOrEmpty(dto.keyword) || d.Cname!.Contains(dto.keyword))
                                          && (dto.status == -1 || (dto.status == 0 && d.CisBan == 1) ||
                                              (dto.status == 1 && d.CisBan == 0))
                      && (startTime == null || (d.CcreateTime >= startTime && d.CcreateTime <= endTime)))
                .Select(d => new Get_All_Customer_Response_Dto
                {
                    id = d.Cid,
                    avatar = d.Cavatar,
                    name = d.Cname,
                    account = d.Cphone,
                    gender = d.Cgender,
                    health_concerns = d.ChealthConcerns,
                    source = d.Csource,
                    assignee_id = d.CassigneeId,
                    status = d.Cstatus,
                    create_time = d.CcreateTime!.Value.ToString("yyyy-MM-dd HH:mm:ss"),
                    isBan = d.CisBan,
                    isActive = d.CisActive,
                }).ToListAsync();
            var assignee = await _org_IOC._employeeLogin_EFCore.QueryAll().ToListAsync();
            var successCustomerIds = await _customer_IOC._cusFollowups_EFCore
                .QueryAll(e => e.CfollowResult == 4)
                .Select(e => e.CfcustomerId)
                .Distinct()
                .ToListAsync();

            data.ForEach(d =>
            {
                d.assignee_id = assignee.FirstOrDefault(e => e.Eid == d.assignee_id)?.Ename ?? "";

                // 如果客户有成功跟进记录(result=4)，则状态设为VIP(2)
                if (successCustomerIds.Contains(d.id))
                {
                    d.status = 2;
                }
            });

            return Get_Result(1, "ok", new
            {
                list = data,
                total
            });
        }


        /// <summary>
        /// 禁用客户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Api_Response_Dto> isBan_Customer(isBan_Customer_Request_Dto dto)
        {
            if (dto.cids == null || dto.cids.Count == 0) return Get_Result(-1, "未选择客户!");
            var customer = await _customer_IOC._customers_EFCore.QueryAll(d => dto.cids!.Contains(d.Cid)).ToListAsync();
            if (customer.Count == 0) return Get_Result(-1, "未找到客户!");
            foreach (var c in customer)
            {
                c.CisBan = dto.status;
            }
            var result = await _customer_IOC._customers_EFCore.SaveChangesAsync();
            return Get_Result(result > 0 ? 1 : -1, result > 0 ? "ok" : "fail");
        }
    }
}
  