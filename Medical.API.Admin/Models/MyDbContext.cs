using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Medical.API.Admin.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArtArticle> ArtArticles { get; set; }

    public virtual DbSet<ArtComment> ArtComments { get; set; }

    public virtual DbSet<ArtCommentLike> ArtCommentLikes { get; set; }

    public virtual DbSet<ArtLike> ArtLikes { get; set; }

    public virtual DbSet<ArtView> ArtViews { get; set; }

    public virtual DbSet<CusCustomer> CusCustomers { get; set; }

    public virtual DbSet<CusCustomerPool> CusCustomerPools { get; set; }

    public virtual DbSet<CusFollowup> CusFollowups { get; set; }

    public virtual DbSet<CusMember> CusMembers { get; set; }

    public virtual DbSet<FinCommission> FinCommissions { get; set; }

    public virtual DbSet<FinWithdrawal> FinWithdrawals { get; set; }

    public virtual DbSet<MktCommissionRule> MktCommissionRules { get; set; }

    public virtual DbSet<MktCustomerPromoter> MktCustomerPromoters { get; set; }

    public virtual DbSet<MktOrderRejection> MktOrderRejections { get; set; }

    public virtual DbSet<MktPromoter> MktPromoters { get; set; }

    public virtual DbSet<MktPromoterClick> MktPromoterClicks { get; set; }

    public virtual DbSet<MktPromoterLink> MktPromoterLinks { get; set; }

    public virtual DbSet<MktPromoterOrder> MktPromoterOrders { get; set; }

    public virtual DbSet<MktPromoterOrderDetail> MktPromoterOrderDetails { get; set; }

    public virtual DbSet<OrgDepartment> OrgDepartments { get; set; }

    public virtual DbSet<OrgDepartmentDuty> OrgDepartmentDutys { get; set; }

    public virtual DbSet<OrgDuty> OrgDutys { get; set; }

    public virtual DbSet<OrgEmployee> OrgEmployees { get; set; }

    public virtual DbSet<PayPayment> PayPayments { get; set; }

    public virtual DbSet<PayPaymentRecord> PayPaymentRecords { get; set; }

    public virtual DbSet<ProOrder> ProOrders { get; set; }

    public virtual DbSet<ProOrderDetail> ProOrderDetails { get; set; }

    public virtual DbSet<ProPackage> ProPackages { get; set; }

    public virtual DbSet<ProPackageDetail> ProPackageDetails { get; set; }

    public virtual DbSet<ProPackageProduct> ProPackageProducts { get; set; }

    public virtual DbSet<ProProduct> ProProducts { get; set; }

    public virtual DbSet<ProProductDetail> ProProductDetails { get; set; }

    public virtual DbSet<ProProductInventory> ProProductInventorys { get; set; }

    public virtual DbSet<ProProductPhoto> ProProductPhotos { get; set; }

    public virtual DbSet<ProProductSpec> ProProductSpecs { get; set; }

    public virtual DbSet<ProService> ProServices { get; set; }

    public virtual DbSet<SchAppointment> SchAppointments { get; set; }

    public virtual DbSet<SchAppointmentItem> SchAppointmentItems { get; set; }

    public virtual DbSet<SchHistory> SchHistorys { get; set; }

    public virtual DbSet<SchPlan> SchPlans { get; set; }

    public virtual DbSet<SchRoomAppointment> SchRoomAppointments { get; set; }

    public virtual DbSet<SchSchedule> SchSchedules { get; set; }

    public virtual DbSet<SchTherapyRoom> SchTherapyRooms { get; set; }

    public virtual DbSet<SysActionLog> SysActionLogs { get; set; }

    public virtual DbSet<SysAdmin> SysAdmins { get; set; }

    public virtual DbSet<SysAdminLoginLog> SysAdminLoginLogs { get; set; }

    public virtual DbSet<SysClientLoginLog> SysClientLoginLogs { get; set; }

    public virtual DbSet<SysDictionary> SysDictionarys { get; set; }

    public virtual DbSet<SysEmployeeLoginLog> SysEmployeeLoginLogs { get; set; }

    public virtual DbSet<SysEmployeeRight> SysEmployeeRights { get; set; }

    public virtual DbSet<SysEmployeeRole> SysEmployeeRoles { get; set; }

    public virtual DbSet<SysErrorLog> SysErrorLogs { get; set; }

    public virtual DbSet<SysModule> SysModules { get; set; }

    public virtual DbSet<SysNotification> SysNotifications { get; set; }

    public virtual DbSet<SysRight> SysRights { get; set; }

    public virtual DbSet<SysRole> SysRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=medicaldb;uid=root;pwd=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_bin")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<ArtArticle>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PRIMARY");

            entity
                .ToTable("art_articles", tb => tb.HasComment("文章主表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Aid)
                .HasMaxLength(32)
                .HasComment("文章id")
                .HasColumnName("AID");
            entity.Property(e => e.AauthorId)
                .HasMaxLength(32)
                .HasComment("作者id")
                .HasColumnName("AAuthorID");
            entity.Property(e => e.AcommentCount)
                .HasDefaultValueSql("'0'")
                .HasComment("评论数")
                .HasColumnName("ACommentCount");
            entity.Property(e => e.Acontent)
                .HasComment("文章内容")
                .HasColumnType("text")
                .HasColumnName("AContent");
            entity.Property(e => e.AcoverImage)
                .HasMaxLength(255)
                .HasComment("封面图片URL")
                .HasColumnName("ACoverImage");
            entity.Property(e => e.AcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ACreateTime");
            entity.Property(e => e.AisCommentAllowed)
                .HasDefaultValueSql("'1'")
                .HasComment("是否允许评论(0:否,1:是)")
                .HasColumnName("AIsCommentAllowed");
            entity.Property(e => e.AisTop)
                .HasDefaultValueSql("'0'")
                .HasComment("是否置顶(0:否,1:是)")
                .HasColumnName("AIsTop");
            entity.Property(e => e.AlikeCount)
                .HasDefaultValueSql("'0'")
                .HasComment("点赞数")
                .HasColumnName("ALikeCount");
            entity.Property(e => e.Astatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(1:发布,2:草稿)")
                .HasColumnName("AStatus");
            entity.Property(e => e.Atags)
                .HasMaxLength(255)
                .HasComment("标签，逗号分隔")
                .HasColumnName("ATags");
            entity.Property(e => e.Atitle)
                .HasMaxLength(255)
                .HasComment("文章标题")
                .HasColumnName("ATitle");
            entity.Property(e => e.Atype)
                .HasComment("分类1:服务,2:产品,3:套餐")
                .HasColumnName("AType");
            entity.Property(e => e.AupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("AUpdateTime");
            entity.Property(e => e.AviewCount)
                .HasDefaultValueSql("'0'")
                .HasComment("浏览量")
                .HasColumnName("AViewCount");
        });

        modelBuilder.Entity<ArtComment>(entity =>
        {
            entity.HasKey(e => e.Acid).HasName("PRIMARY");

            entity
                .ToTable("art_comments", tb => tb.HasComment("文章评论表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Acid)
                .HasMaxLength(32)
                .HasComment("评论id")
                .HasColumnName("ACID");
            entity.Property(e => e.AcarticleId)
                .HasMaxLength(32)
                .HasComment("文章id")
                .HasColumnName("ACArticleID");
            entity.Property(e => e.Accontent)
                .HasComment("评论内容")
                .HasColumnType("text")
                .HasColumnName("ACContent");
            entity.Property(e => e.AccreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ACCreateTime");
            entity.Property(e => e.AccustomerId)
                .HasMaxLength(32)
                .HasComment("评论用户id/客户id")
                .HasColumnName("ACCustomerID");
            entity.Property(e => e.AclikeCount)
                .HasDefaultValueSql("'0'")
                .HasComment("点赞数")
                .HasColumnName("ACLikeCount");
            entity.Property(e => e.AcparentId)
                .HasMaxLength(32)
                .HasComment("父评论id")
                .HasColumnName("ACParentID");
            entity.Property(e => e.AcupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("ACUpdateTime");
        });

        modelBuilder.Entity<ArtCommentLike>(entity =>
        {
            entity.HasKey(e => e.Aclid).HasName("PRIMARY");

            entity
                .ToTable("art_comment_likes", tb => tb.HasComment("评论点赞表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Aclid)
                .HasMaxLength(32)
                .HasComment("评论点赞id")
                .HasColumnName("ACLID");
            entity.Property(e => e.AclcommentId)
                .HasMaxLength(32)
                .HasComment("评论id")
                .HasColumnName("ACLCommentID");
            entity.Property(e => e.AclcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("点赞时间")
                .HasColumnType("datetime")
                .HasColumnName("ACLCreateTime");
            entity.Property(e => e.AclcustomerId)
                .HasMaxLength(32)
                .HasComment("点赞用户/客户id")
                .HasColumnName("ACLCustomerID");
        });

        modelBuilder.Entity<ArtLike>(entity =>
        {
            entity.HasKey(e => e.Alid).HasName("PRIMARY");

            entity
                .ToTable("art_likes", tb => tb.HasComment("文章点赞表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => new { e.AlarticleId, e.AlcustomerId }, "ALArticleID").IsUnique();

            entity.Property(e => e.Alid)
                .HasMaxLength(32)
                .HasComment("点赞id")
                .HasColumnName("ALID");
            entity.Property(e => e.AlarticleId)
                .HasMaxLength(32)
                .HasComment("文章id")
                .HasColumnName("ALArticleID");
            entity.Property(e => e.AlcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("点赞时间")
                .HasColumnType("datetime")
                .HasColumnName("ALCreateTime");
            entity.Property(e => e.AlcustomerId)
                .HasMaxLength(32)
                .HasComment("点赞用户/客户id")
                .HasColumnName("ALCustomerID");
        });

        modelBuilder.Entity<ArtView>(entity =>
        {
            entity.HasKey(e => e.Avid).HasName("PRIMARY");

            entity
                .ToTable("art_views", tb => tb.HasComment("文章浏览记录表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Avid)
                .HasMaxLength(32)
                .HasComment("浏览记录id")
                .HasColumnName("AVID");
            entity.Property(e => e.AvarticleId)
                .HasMaxLength(32)
                .HasComment("文章id")
                .HasColumnName("AVArticleID");
            entity.Property(e => e.AvcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("浏览时间")
                .HasColumnType("datetime")
                .HasColumnName("AVCreateTime");
            entity.Property(e => e.AvcustomerId)
                .HasMaxLength(32)
                .HasComment("浏览用户id")
                .HasColumnName("AVCustomerID");
            entity.Property(e => e.AvdeviceInfo)
                .HasMaxLength(255)
                .HasComment("设备信息")
                .HasColumnName("AVDeviceInfo");
            entity.Property(e => e.Avipaddress)
                .HasMaxLength(50)
                .HasComment("IP地址")
                .HasColumnName("AVIPAddress");
            entity.Property(e => e.Avregion)
                .HasMaxLength(999)
                .HasComment("地区")
                .HasColumnName("AVRegion");
        });

        modelBuilder.Entity<CusCustomer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PRIMARY");

            entity
                .ToTable("cus_customers", tb => tb.HasComment("客户表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Cphone, "CPhone").IsUnique();

            entity.Property(e => e.Cid)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("CID");
            entity.Property(e => e.CancelOrderCount).HasComment("累计取消订单数量");
            entity.Property(e => e.CassigneeId)
                .HasMaxLength(32)
                .HasComment("负责人id")
                .HasColumnName("CAssigneeID");
            entity.Property(e => e.Cavatar)
                .HasMaxLength(999)
                .HasComment("头像")
                .HasColumnName("CAvatar");
            entity.Property(e => e.Cbalance)
                .HasPrecision(18, 2)
                .HasComment("账户余额")
                .HasColumnName("CBalance");
            entity.Property(e => e.Cbirthday)
                .HasComment("生日")
                .HasColumnName("CBirthday");
            entity.Property(e => e.CcancelAmount)
                .HasPrecision(18, 2)
                .HasComment("累计取消订单金额")
                .HasColumnName("CCancelAmount");
            entity.Property(e => e.CcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("CCreateTime");
            entity.Property(e => e.Cgender)
                .HasComment("性别(0:男,1:女)")
                .HasColumnName("CGender");
            entity.Property(e => e.ChealthConcerns)
                .HasComment("健康主诉")
                .HasColumnType("text")
                .HasColumnName("CHealthConcerns");
            entity.Property(e => e.CisActive)
                .HasComment("是否激活")
                .HasColumnName("CIsActive");
            entity.Property(e => e.CisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("CIsBan");
            entity.Property(e => e.CisPromoter)
                .HasComment("是否是推广员(0-否,1-是)")
                .HasColumnName("CIsPromoter");
            entity.Property(e => e.Cname)
                .HasMaxLength(100)
                .HasComment("客户姓名")
                .HasColumnName("CName");
            entity.Property(e => e.CorderCount)
                .HasComment("累计下单数量")
                .HasColumnName("COrderCount");
            entity.Property(e => e.Cpassword)
                .HasMaxLength(32)
                .HasComment("密码")
                .HasColumnName("CPassword");
            entity.Property(e => e.Cphone)
                .HasMaxLength(11)
                .HasComment("账号/手机号码")
                .HasColumnName("CPhone");
            entity.Property(e => e.CreferralType)
                .HasComment("推荐类型:0-自然流量,1-线上推广,2-客户推荐 3-线下活动 4-其他")
                .HasColumnName("CReferralType");
            entity.Property(e => e.Csalt)
                .HasMaxLength(32)
                .HasComment("盐")
                .HasColumnName("CSalt");
            entity.Property(e => e.Csource)
                .HasMaxLength(100)
                .HasComment("客户来源")
                .HasColumnName("CSource");
            entity.Property(e => e.Cstatus)
                .HasDefaultValueSql("'0'")
                .HasComment("状态(0:公海,1:跟进中,2:VIP)")
                .HasColumnName("CStatus");
            entity.Property(e => e.CtotalConsumption)
                .HasPrecision(18, 2)
                .HasComment("总消费")
                .HasColumnName("CTotalConsumption");
            entity.Property(e => e.Cwechat)
                .HasMaxLength(100)
                .HasComment("微信号")
                .HasColumnName("CWechat");
        });

        modelBuilder.Entity<CusCustomerPool>(entity =>
        {
            entity.HasKey(e => new { e.Cpid, e.CpenterTime })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("cus_customer_pools", tb => tb.HasComment("客户公海管理表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Cpid)
                .HasMaxLength(32)
                .HasComment("公海记录id")
                .HasColumnName("CPID");
            entity.Property(e => e.CpenterTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("进入公海时间")
                .HasColumnType("datetime")
                .HasColumnName("CPEnterTime");
            entity.Property(e => e.CpcustomerId)
                .HasMaxLength(32)
                .HasComment("关联客户id")
                .HasColumnName("CPCustomerID");
            entity.Property(e => e.CpenterType)
                .HasComment("进入公海类型：1-新客户未分配,2-新客户已分配,3-跟进超时退回,4-客户无响应退回 ,5-员工主动退回")
                .HasColumnName("CPEnterType");
            entity.Property(e => e.CplockExpireTime)
                .HasComment("锁定过期时间(锁定后30分钟自动解锁，防止占而不领)")
                .HasColumnType("datetime")
                .HasColumnName("CPLockExpireTime");
            entity.Property(e => e.CplockOperatorId)
                .HasMaxLength(32)
                .HasComment("锁定人id(LockStatus=1时必填)")
                .HasColumnName("CPLockOperatorID");
            entity.Property(e => e.CplockStatus)
                .HasComment("锁定状态:0-未锁定 1-已锁定(领取时锁定,防止并发)")
                .HasColumnName("CPLockStatus");
            entity.Property(e => e.CpreturnReason)
                .HasMaxLength(500)
                .HasComment("退回公海原因（仅EnterType=2/3/4时必填）")
                .HasColumnName("CPReturnReason");
            entity.Property(e => e.CptakeOperatorId)
                .HasMaxLength(32)
                .HasComment("领取人id")
                .HasColumnName("CPTakeOperatorID");
            entity.Property(e => e.CptakeTime)
                .HasComment("领取时间")
                .HasColumnType("datetime")
                .HasColumnName("CPTakeTime");
        });

        modelBuilder.Entity<CusFollowup>(entity =>
        {
            entity.HasKey(e => e.Cfid).HasName("PRIMARY");

            entity
                .ToTable("cus_followups", tb => tb.HasComment("客户跟进表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Cfid)
                .HasMaxLength(32)
                .HasComment("跟进id")
                .HasColumnName("CFID");
            entity.Property(e => e.Cfcontent)
                .HasComment("跟进内容")
                .HasColumnType("text")
                .HasColumnName("CFContent");
            entity.Property(e => e.CfcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("CFCreateTime");
            entity.Property(e => e.CfcustomerId)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("CFCustomerID");
            entity.Property(e => e.CfnextTime)
                .HasComment("下次跟进时间")
                .HasColumnType("datetime")
                .HasColumnName("CFNextTime");
            entity.Property(e => e.CfollowResult)
                .HasDefaultValueSql("'0'")
                .HasComment("结果：0-首次跟进 1-客户咨询 2-初次沟通 \r\n  3-需求确认 4-已成交 5-已流失")
                .HasColumnName("CFollowResult");
            entity.Property(e => e.CfollowType)
                .HasDefaultValueSql("'1'")
                .HasComment("跟进方式:1-电话 2-微信 3-到店 4-其他")
                .HasColumnName("CFollowType");
            entity.Property(e => e.CfoperatorId)
                .HasMaxLength(32)
                .HasComment("操作人id")
                .HasColumnName("CFOperatorID");
        });

        modelBuilder.Entity<CusMember>(entity =>
        {
            entity.HasKey(e => e.Cmid).HasName("PRIMARY");

            entity
                .ToTable("cus_members", tb => tb.HasComment("客户会员信息表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Cmid)
                .HasMaxLength(32)
                .HasComment("会员id")
                .HasColumnName("CMID");
            entity.Property(e => e.CmcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("CMCreateTime");
            entity.Property(e => e.CmcustomerId)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("CMCustomerID");
            entity.Property(e => e.CmdiscountRate)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'100.00'")
                .HasComment("折扣率(%)")
                .HasColumnName("CMDiscountRate");
            entity.Property(e => e.CmendTime)
                .HasComment("会员到期日期")
                .HasColumnType("datetime")
                .HasColumnName("CMEndTime");
            entity.Property(e => e.Cmlevel)
                .HasDefaultValueSql("'1'")
                .HasComment("会员等级(1-普通,2-银卡,3-金卡,4-钻石)")
                .HasColumnName("CMLevel");
            entity.Property(e => e.CmmembershipFee)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("会员费")
                .HasColumnName("CMMembershipFee");
            entity.Property(e => e.CmstartTime)
                .HasComment("会员开始日期")
                .HasColumnType("datetime")
                .HasColumnName("CMStartTime");
            entity.Property(e => e.Cmstatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(0-已过期,1-有效,2-冻结)")
                .HasColumnName("CMStatus");
            entity.Property(e => e.CmtotalSpend)
                .HasPrecision(12, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("累计消费金额")
                .HasColumnName("CMTotalSpend");
            entity.Property(e => e.CmupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("CMUpdateTime");
        });

        modelBuilder.Entity<FinCommission>(entity =>
        {
            entity.HasKey(e => e.Fcid).HasName("PRIMARY");

            entity
                .ToTable("fin_commissions", tb => tb.HasComment("佣金结算记录"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Fcid)
                .HasMaxLength(32)
                .HasComment("结算id")
                .HasColumnName("FCID");
            entity.Property(e => e.Fcaccount)
                .HasMaxLength(32)
                .HasComment("推广员账号")
                .HasColumnName("FCAccount");
            entity.Property(e => e.Fcamount)
                .HasPrecision(10, 2)
                .HasComment("结算金额")
                .HasColumnName("FCAmount");
            entity.Property(e => e.FccreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("FCCreateTime");
            entity.Property(e => e.FcpromoterId)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("FCPromoterID");
        });

        modelBuilder.Entity<FinWithdrawal>(entity =>
        {
            entity.HasKey(e => e.Fwid).HasName("PRIMARY");

            entity
                .ToTable("fin_withdrawals", tb => tb.HasComment("提现申请"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Fwid)
                .HasMaxLength(32)
                .HasComment("提现id")
                .HasColumnName("FWID");
            entity.Property(e => e.Fwamount)
                .HasPrecision(10, 2)
                .HasComment("提现金额")
                .HasColumnName("FWAmount");
            entity.Property(e => e.FwbankAccount)
                .HasMaxLength(100)
                .HasComment("银行账号")
                .HasColumnName("FWBankAccount");
            entity.Property(e => e.FwcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("FWCreateTime");
            entity.Property(e => e.FwpromoterId)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("FWPromoterID");
            entity.Property(e => e.Fwremark)
                .HasMaxLength(255)
                .HasComment("备注")
                .HasColumnName("FWRemark");
            entity.Property(e => e.Fwstatus)
                .HasDefaultValueSql("'0'")
                .HasComment("状态:0-申请中,1-已打款,2-已驳回")
                .HasColumnName("FWStatus");
        });

        modelBuilder.Entity<MktCommissionRule>(entity =>
        {
            entity.HasKey(e => e.Mcrid).HasName("PRIMARY");

            entity
                .ToTable("mkt_commission_rules", tb => tb.HasComment("佣金规则表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Mcrid)
                .HasMaxLength(32)
                .HasComment("规则id")
                .HasColumnName("MCRID");
            entity.Property(e => e.Mcpublish)
                .HasDefaultValueSql("'0'")
                .HasComment("是否发布(0:否,1:是)")
                .HasColumnName("MCPublish");
            entity.Property(e => e.McrcommissionRate)
                .HasPrecision(5, 2)
                .HasComment("佣金比例")
                .HasColumnName("MCRCommissionRate");
            entity.Property(e => e.McrcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MCRCreateTime");
            entity.Property(e => e.Mcrexplain)
                .HasComment("规则描述")
                .HasColumnType("text")
                .HasColumnName("MCRExplain");
            entity.Property(e => e.McrisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("MCRIsBan");
            entity.Property(e => e.McrmaxAmount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("最高金额限制")
                .HasColumnName("MCRMaxAmount");
            entity.Property(e => e.McrminAmount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("最低金额限制")
                .HasColumnName("MCRMinAmount");
            entity.Property(e => e.McrproductId)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("MCRProductID");
            entity.Property(e => e.McrproductType)
                .HasComment("产品类型:1-服务,2-产品,3-套餐")
                .HasColumnName("MCRProductType");
            entity.Property(e => e.McruseCount)
                .HasComment("使用次数")
                .HasColumnName("MCRUseCount");
        });

        modelBuilder.Entity<MktCustomerPromoter>(entity =>
        {
            entity.HasKey(e => e.Cpid).HasName("PRIMARY");

            entity
                .ToTable("mkt_customer_promoter", tb => tb.HasComment("客户与推广员关联表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.CpcustomerId, "CPCustomerID").IsUnique();

            entity.Property(e => e.Cpid)
                .HasMaxLength(32)
                .HasComment("关联id")
                .HasColumnName("CPID");
            entity.Property(e => e.CpcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("CPCreateTime");
            entity.Property(e => e.CpcustomerId)
                .HasMaxLength(32)
                .HasComment("被推广客户id")
                .HasColumnName("CPCustomerID");
            entity.Property(e => e.CppromoterId)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("CPPromoterID");
            entity.Property(e => e.CppromoterType)
                .HasComment("推广员类型:1-员工,2-客户")
                .HasColumnName("CPPromoterType");
            entity.Property(e => e.Cptype)
                .HasDefaultValueSql("'1'")
                .HasComment("关联类型(1-注册,2-购买)")
                .HasColumnName("CPType");
        });

        modelBuilder.Entity<MktOrderRejection>(entity =>
        {
            entity.HasKey(e => e.Morid).HasName("PRIMARY");

            entity
                .ToTable("mkt_order_rejections", tb => tb.HasComment("订单拒绝记录表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Morid)
                .HasMaxLength(32)
                .HasComment("拒绝记录id")
                .HasColumnName("MORID");
            entity.Property(e => e.MorcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MORCreateTime");
            entity.Property(e => e.MororderId)
                .HasMaxLength(32)
                .HasComment("关联订单id")
                .HasColumnName("MOROrderID");
            entity.Property(e => e.Morreason)
                .HasComment("拒绝原因")
                .HasColumnType("text")
                .HasColumnName("MORReason");
            entity.Property(e => e.MorrejecterId)
                .HasMaxLength(32)
                .HasComment("拒绝人(员工id)")
                .HasColumnName("MORRejecterID");
        });

        modelBuilder.Entity<MktPromoter>(entity =>
        {
            entity.HasKey(e => e.Mpid).HasName("PRIMARY");

            entity
                .ToTable("mkt_promoters", tb => tb.HasComment("推广员信息表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.MppromoCode, "MPPromoCode").IsUnique();

            entity.HasIndex(e => e.MpuserId, "uk_mpuserid").IsUnique();

            entity.Property(e => e.Mpid)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("MPID");
            entity.Property(e => e.MpcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MPCreateTime");
            entity.Property(e => e.MpisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("MPIsBan");
            entity.Property(e => e.MpmonthIncome)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("本月收益")
                .HasColumnName("MPMonthIncome");
            entity.Property(e => e.MporderCount)
                .HasDefaultValueSql("'0'")
                .HasComment("推广订单数")
                .HasColumnName("MPOrderCount");
            entity.Property(e => e.MppendingAmount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("待结算金额")
                .HasColumnName("MPPendingAmount");
            entity.Property(e => e.MppromoCode)
                .HasMaxLength(12)
                .HasComment("专属推广码")
                .HasColumnName("MPPromoCode");
            entity.Property(e => e.MptotalIncome)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("累计收益")
                .HasColumnName("MPTotalIncome");
            entity.Property(e => e.MpupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("MPUpdateTime");
            entity.Property(e => e.MpuserId)
                .HasMaxLength(32)
                .HasComment("关联用户id/客户id")
                .HasColumnName("MPUserID");
        });

        modelBuilder.Entity<MktPromoterClick>(entity =>
        {
            entity.HasKey(e => e.Pcid).HasName("PRIMARY");

            entity
                .ToTable("mkt_promoter_clicks", tb => tb.HasComment("推广点击记录表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Pcid)
                .HasMaxLength(32)
                .HasComment("点击id")
                .HasColumnName("PCID");
            entity.Property(e => e.Pcbrowser)
                .HasMaxLength(50)
                .HasComment("浏览器")
                .HasColumnName("PCBrowser");
            entity.Property(e => e.PccreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("点击时间")
                .HasColumnType("datetime")
                .HasColumnName("PCCreateTime");
            entity.Property(e => e.Pcdevice)
                .HasMaxLength(50)
                .HasComment("设备类型")
                .HasColumnName("PCDevice");
            entity.Property(e => e.Pcip)
                .HasMaxLength(50)
                .HasComment("ip地址")
                .HasColumnName("PCIP");
            entity.Property(e => e.PclinkId)
                .HasMaxLength(32)
                .HasComment("推广链接id")
                .HasColumnName("PCLinkID");
            entity.Property(e => e.Pcregion)
                .HasMaxLength(100)
                .HasComment("地区")
                .HasColumnName("PCRegion");
        });

        modelBuilder.Entity<MktPromoterLink>(entity =>
        {
            entity.HasKey(e => e.Mplid).HasName("PRIMARY");

            entity
                .ToTable("mkt_promoter_links", tb => tb.HasComment("推广链接表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Mplid)
                .HasMaxLength(32)
                .HasComment("链接id")
                .HasColumnName("MPLID");
            entity.Property(e => e.MplbaseUrl)
                .HasMaxLength(255)
                .HasComment("基础URL")
                .HasColumnName("MPLBaseUrl");
            entity.Property(e => e.MplchannelId)
                .HasMaxLength(32)
                .HasComment("渠道id")
                .HasColumnName("MPLChannelID");
            entity.Property(e => e.MplclickCount)
                .HasDefaultValueSql("'0'")
                .HasComment("点击次数")
                .HasColumnName("MPLClickCount");
            entity.Property(e => e.MplconversionCount)
                .HasDefaultValueSql("'0'")
                .HasComment("转化次数")
                .HasColumnName("MPLConversionCount");
            entity.Property(e => e.MplcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MPLCreateTime");
            entity.Property(e => e.MplfullUrl)
                .HasMaxLength(500)
                .HasComment("完整推广URL")
                .HasColumnName("MPLFullUrl");
            entity.Property(e => e.MplisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("MPLIsBan");
            entity.Property(e => e.MplpromoterId)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("MPLPromoterID");
            entity.Property(e => e.MplqrcodeUrl)
                .HasMaxLength(255)
                .HasComment("二维码URL")
                .HasColumnName("MPLQRCodeUrl");
            entity.Property(e => e.Mplstatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(1:有效,0:无效)")
                .HasColumnName("MPLStatus");
        });

        modelBuilder.Entity<MktPromoterOrder>(entity =>
        {
            entity.HasKey(e => e.Mpoid).HasName("PRIMARY");

            entity
                .ToTable("mkt_promoter_orders", tb => tb.HasComment("推广订单表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Mpoid)
                .HasMaxLength(32)
                .HasComment("订单id")
                .HasColumnName("MPOID");
            entity.Property(e => e.MpochannelId)
                .HasMaxLength(32)
                .HasComment("推广渠道")
                .HasColumnName("MPOChannelID");
            entity.Property(e => e.MpocommissionAmount)
                .HasPrecision(10, 2)
                .HasComment("总佣金金额")
                .HasColumnName("MPOCommissionAmount");
            entity.Property(e => e.MpocreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MPOCreateTime");
            entity.Property(e => e.MpocustomerId)
                .HasMaxLength(32)
                .HasComment("被推荐的客户id")
                .HasColumnName("MPOCustomerID");
            entity.Property(e => e.MpoisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("MPOIsBan");
            entity.Property(e => e.MpoorderAmount)
                .HasPrecision(10, 2)
                .HasComment("订单总金额")
                .HasColumnName("MPOOrderAmount");
            entity.Property(e => e.MpoorderId)
                .HasMaxLength(32)
                .HasComment("关联下单订单id")
                .HasColumnName("MPOOrderID");
            entity.Property(e => e.MpopromoterId)
                .HasMaxLength(32)
                .HasComment("推广员id")
                .HasColumnName("MPOPromoterID");
            entity.Property(e => e.MposettlementStatus)
                .HasDefaultValueSql("'0'")
                .HasComment("结算状态(0:待结算,1:已结算,2:已拒绝)")
                .HasColumnName("MPOSettlementStatus");
            entity.Property(e => e.MposettlementTime)
                .HasComment("结算时间")
                .HasColumnType("datetime")
                .HasColumnName("MPOSettlementTime");
        });

        modelBuilder.Entity<MktPromoterOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Mpodid).HasName("PRIMARY");

            entity
                .ToTable("mkt_promoter_order_details", tb => tb.HasComment("推广订单详情表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Mpodid)
                .HasMaxLength(32)
                .HasComment("详情id")
                .HasColumnName("MPODID");
            entity.Property(e => e.MpodcommissionAmount)
                .HasPrecision(10, 2)
                .HasComment("佣金金额")
                .HasColumnName("MPODCommissionAmount");
            entity.Property(e => e.MpodcommissionRate)
                .HasPrecision(5, 2)
                .HasComment("佣金比例(%)")
                .HasColumnName("MPODCommissionRate");
            entity.Property(e => e.MpodcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("MPODCreateTime");
            entity.Property(e => e.MpodlinkId)
                .HasMaxLength(32)
                .HasComment("推广链接id")
                .HasColumnName("MPODLinkID");
            entity.Property(e => e.MpodorderId)
                .HasMaxLength(32)
                .HasComment("关联推广订单id")
                .HasColumnName("MPODOrderID");
            entity.Property(e => e.Mpodprice)
                .HasPrecision(10, 2)
                .HasComment("单价")
                .HasColumnName("MPODPrice");
            entity.Property(e => e.MpodproductId)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("MPODProductID");
            entity.Property(e => e.MpodproductType)
                .HasComment("1-服务,2-产品,3-套餐")
                .HasColumnName("MPODProductType");
            entity.Property(e => e.Mpodquantity)
                .HasDefaultValueSql("'1'")
                .HasComment("数量")
                .HasColumnName("MPODQuantity");
            entity.Property(e => e.MpodspecId)
                .HasMaxLength(32)
                .HasComment("规格id")
                .HasColumnName("MPODSpecID");
            entity.Property(e => e.Mpodsubtotal)
                .HasPrecision(10, 2)
                .HasComment("小计金额")
                .HasColumnName("MPODSubtotal");
        });

        modelBuilder.Entity<OrgDepartment>(entity =>
        {
            entity.HasKey(e => e.Did).HasName("PRIMARY");

            entity
                .ToTable("org_departments", tb => tb.HasComment("部门表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Did)
                .HasMaxLength(32)
                .HasComment("部门id")
                .HasColumnName("DID");
            entity.Property(e => e.DcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("DCreateTime");
            entity.Property(e => e.Ddescription)
                .HasMaxLength(500)
                .HasComment("部门描述")
                .HasColumnName("DDescription");
            entity.Property(e => e.Dicon)
                .HasMaxLength(199)
                .HasComment("部门图标")
                .HasColumnName("DIcon");
            entity.Property(e => e.DisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用")
                .HasColumnName("DIsBan");
            entity.Property(e => e.Dname)
                .HasMaxLength(100)
                .HasComment("部门名称")
                .HasColumnName("DName");
            entity.Property(e => e.DparentId)
                .HasMaxLength(32)
                .HasComment("父部门id")
                .HasColumnName("DParentID");
            entity.Property(e => e.DsortOrder)
                .HasDefaultValueSql("'0'")
                .HasComment("排序号")
                .HasColumnName("DSortOrder");
        });

        modelBuilder.Entity<OrgDepartmentDuty>(entity =>
        {
            entity.HasKey(e => e.Ddid).HasName("PRIMARY");

            entity
                .ToTable("org_department_dutys", tb => tb.HasComment("部门岗位表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Ddid)
                .HasMaxLength(32)
                .HasComment("主键id")
                .HasColumnName("DDID");
            entity.Property(e => e.DdcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("DDCreateTime");
            entity.Property(e => e.DddeptId)
                .HasMaxLength(32)
                .HasComment("部门id")
                .HasColumnName("DDDeptID");
            entity.Property(e => e.DddutyId)
                .HasMaxLength(32)
                .HasComment("岗位id")
                .HasColumnName("DDDutyID");
        });

        modelBuilder.Entity<OrgDuty>(entity =>
        {
            entity.HasKey(e => e.Did).HasName("PRIMARY");

            entity
                .ToTable("org_dutys", tb => tb.HasComment("岗位表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Did)
                .HasMaxLength(32)
                .HasComment("岗位id")
                .HasColumnName("DID");
            entity.Property(e => e.Dcount)
                .HasDefaultValueSql("'0'")
                .HasComment("数量")
                .HasColumnName("DCount");
            entity.Property(e => e.DcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("DCreateTime");
            entity.Property(e => e.Ddescription)
                .HasMaxLength(500)
                .HasComment("岗位描述")
                .HasColumnName("DDescription");
            entity.Property(e => e.DisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用")
                .HasColumnName("DIsBan");
            entity.Property(e => e.Dlevel)
                .HasDefaultValueSql("'0'")
                .HasComment("等级");
            entity.Property(e => e.Dname)
                .HasMaxLength(100)
                .HasComment("岗位名称")
                .HasColumnName("DName");
        });

        modelBuilder.Entity<OrgEmployee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PRIMARY");

            entity
                .ToTable("org_employees", tb => tb.HasComment("员工表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Eaccount, "EAccount").IsUnique();

            entity.Property(e => e.Eid)
                .HasMaxLength(32)
                .HasComment("员工id")
                .HasColumnName("EID");
            entity.Property(e => e.Eaccount)
                .HasMaxLength(11)
                .HasComment("账号/手机号")
                .HasColumnName("EAccount");
            entity.Property(e => e.Eavatar)
                .HasMaxLength(999)
                .HasComment("头像")
                .HasColumnName("EAvatar");
            entity.Property(e => e.EcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ECreateTime");
            entity.Property(e => e.EdeptId)
                .HasMaxLength(32)
                .HasComment("所属部门id")
                .HasColumnName("EDeptID");
            entity.Property(e => e.EdutyId)
                .HasMaxLength(32)
                .HasComment("岗位id")
                .HasColumnName("EDutyID");
            entity.Property(e => e.Eemail)
                .HasMaxLength(50)
                .HasComment("邮箱")
                .HasColumnName("EEmail");
            entity.Property(e => e.EentryDate)
                .HasComment("入职日期")
                .HasColumnType("datetime")
                .HasColumnName("EEntryDate");
            entity.Property(e => e.Eexplain)
                .HasMaxLength(255)
                .HasComment("员工描述")
                .HasColumnName("EExplain");
            entity.Property(e => e.Egender)
                .HasComment("性别(0:男-1:女)")
                .HasColumnName("EGender");
            entity.Property(e => e.EisActive)
                .HasDefaultValueSql("'0'")
                .HasComment("账号是否激活")
                .HasColumnName("EIsActive");
            entity.Property(e => e.EisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用")
                .HasColumnName("EIsBan");
            entity.Property(e => e.EisOnline)
                .HasDefaultValueSql("'0'")
                .HasComment("是否在线")
                .HasColumnName("EIsOnline");
            entity.Property(e => e.Ename)
                .HasMaxLength(100)
                .HasComment("员工姓名")
                .HasColumnName("EName");
            entity.Property(e => e.Enick)
                .HasMaxLength(100)
                .HasComment("员工呢称")
                .HasColumnName("ENick");
            entity.Property(e => e.Epassword)
                .HasMaxLength(32)
                .HasComment("密码")
                .HasColumnName("EPassword");
            entity.Property(e => e.ErolesId)
                .HasMaxLength(32)
                .HasComment("角色")
                .HasColumnName("ERolesID");
            entity.Property(e => e.Esalt)
                .HasMaxLength(32)
                .HasComment("盐")
                .HasColumnName("ESalt");
            entity.Property(e => e.Especialty)
                .HasMaxLength(500)
                .HasComment("专业技能/职称")
                .HasColumnName("ESpecialty");
            entity.Property(e => e.Estatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(0:离职,1:在职)")
                .HasColumnName("EStatus");
        });

        modelBuilder.Entity<PayPayment>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PRIMARY");

            entity
                .ToTable("pay_payments", tb => tb.HasComment("支付主表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pid)
                .HasMaxLength(32)
                .HasComment("支付id")
                .HasColumnName("PID");
            entity.Property(e => e.PactualAmount)
                .HasPrecision(10, 2)
                .HasComment("实际支付金额")
                .HasColumnName("PActualAmount");
            entity.Property(e => e.Pamount)
                .HasPrecision(10, 2)
                .HasComment("支付金额")
                .HasColumnName("PAmount");
            entity.Property(e => e.PcompleteTime)
                .HasComment("完成时间")
                .HasColumnType("datetime")
                .HasColumnName("PCompleteTime");
            entity.Property(e => e.PcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PCreateTime");
            entity.Property(e => e.PorderId)
                .HasMaxLength(32)
                .HasComment("订单id")
                .HasColumnName("POrderID");
            entity.Property(e => e.PpayTime)
                .HasComment("支付时间")
                .HasColumnType("datetime")
                .HasColumnName("PPayTime");
            entity.Property(e => e.PrefundTime)
                .HasComment("退款时间")
                .HasColumnType("datetime")
                .HasColumnName("PRefundTime");
            entity.Property(e => e.Pstatus)
                .HasComment("支付状态(0-未支付,1-支付成功,3-支付失败,4-已退款)")
                .HasColumnName("PStatus");
            entity.Property(e => e.Ptype)
                .HasComment("支付类型(1-支付宝,2-微信,3-银联,4-余额,5-现金)")
                .HasColumnName("PType");
        });

        modelBuilder.Entity<PayPaymentRecord>(entity =>
        {
            entity.HasKey(e => e.Prid).HasName("PRIMARY");

            entity
                .ToTable("pay_payment_records", tb => tb.HasComment("支付记录表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Prid)
                .HasMaxLength(32)
                .HasComment("记录id")
                .HasColumnName("PRID");
            entity.Property(e => e.Pramount)
                .HasPrecision(10, 2)
                .HasComment("金额")
                .HasColumnName("PRAmount");
            entity.Property(e => e.PrcompleteTime)
                .HasComment("完成时间")
                .HasColumnType("datetime")
                .HasColumnName("PRCompleteTime");
            entity.Property(e => e.PrcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PRCreateTime");
            entity.Property(e => e.PrpaymentId)
                .HasMaxLength(32)
                .HasComment("支付id")
                .HasColumnName("PRPaymentID");
            entity.Property(e => e.Prstatus)
                .HasComment("状态(0-处理中,1-成功,2-失败)")
                .HasColumnName("PRStatus");
            entity.Property(e => e.Prtype)
                .HasComment("记录类型(1-支付,2-退款)")
                .HasColumnName("PRType");
        });

        modelBuilder.Entity<ProOrder>(entity =>
        {
            entity.HasKey(e => e.Oid).HasName("PRIMARY");

            entity
                .ToTable("pro_orders", tb => tb.HasComment("订单表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Oid)
                .HasMaxLength(32)
                .HasComment("订单id")
                .HasColumnName("OID");
            entity.Property(e => e.OcancelTime)
                .HasComment("取消时间")
                .HasColumnType("datetime")
                .HasColumnName("OCancelTime");
            entity.Property(e => e.OcompleteTime)
                .HasComment("完成时间")
                .HasColumnType("datetime")
                .HasColumnName("OCompleteTime");
            entity.Property(e => e.OcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("OCreateTime");
            entity.Property(e => e.OcustomerId)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("OCustomerID");
            entity.Property(e => e.OemployeeId)
                .HasMaxLength(32)
                .HasComment("操作人/员工id")
                .HasColumnName("OEmployeeID");
            entity.Property(e => e.OisComplete)
                .HasDefaultValueSql("'0'")
                .HasComment("是否完成")
                .HasColumnName("OIsComplete");
            entity.Property(e => e.OpaidAmount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasComment("已付金额")
                .HasColumnName("OPaidAmount");
            entity.Property(e => e.OpaymentMethod)
                .HasMaxLength(50)
                .HasComment("支付方式")
                .HasColumnName("OPaymentMethod");
            entity.Property(e => e.OpaymentStatus)
                .HasComment("支付状态(0:未支付,1:已支付,2:已退款)")
                .HasColumnName("OPaymentStatus");
            entity.Property(e => e.OpaymentTime)
                .HasComment("支付时间")
                .HasColumnType("datetime")
                .HasColumnName("OPaymentTime");
            entity.Property(e => e.OroomId)
                .HasMaxLength(32)
                .HasComment("理疗室id")
                .HasColumnName("ORoomID");
            entity.Property(e => e.Ostatus)
                .HasComment("订单状态:1-处理中,2-已完成 3-已取消")
                .HasColumnName("OStatus");
            entity.Property(e => e.Ototal)
                .HasComment("产品数量")
                .HasColumnName("OTotal");
            entity.Property(e => e.OtotalAmount)
                .HasPrecision(10, 2)
                .HasComment("总金额")
                .HasColumnName("OTotalAmount");
            entity.Property(e => e.Otype)
                .HasComment("订单类型(1:服务,2:产品,3:套餐,4:混合项目)")
                .HasColumnName("OType");
        });

        modelBuilder.Entity<ProOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Odid).HasName("PRIMARY");

            entity
                .ToTable("pro_order_details", tb => tb.HasComment("订单明细表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Odid)
                .HasMaxLength(32)
                .HasComment("明细id")
                .HasColumnName("ODID");
            entity.Property(e => e.OdcancelTime)
                .HasComment("取消时间")
                .HasColumnType("datetime")
                .HasColumnName("ODCancelTime");
            entity.Property(e => e.OdcompleteTime)
                .HasComment("完成时间")
                .HasColumnType("datetime")
                .HasColumnName("ODCompleteTime");
            entity.Property(e => e.OdcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ODCreateTime");
            entity.Property(e => e.OditemId)
                .HasMaxLength(32)
                .HasComment("项目id")
                .HasColumnName("ODItemID");
            entity.Property(e => e.OditemType)
                .HasComment("项目类型(1:服务,2:产品,3:套餐)")
                .HasColumnName("ODItemType");
            entity.Property(e => e.OdorderId)
                .HasMaxLength(32)
                .HasComment("订单id")
                .HasColumnName("ODOrderID");
            entity.Property(e => e.Odprice)
                .HasPrecision(10, 2)
                .HasComment("价格")
                .HasColumnName("ODPrice");
            entity.Property(e => e.Odquantity)
                .HasDefaultValueSql("'1'")
                .HasComment("数量")
                .HasColumnName("ODQuantity");
            entity.Property(e => e.OdserviceEndTime)
                .HasComment("服务结束时间")
                .HasColumnType("datetime")
                .HasColumnName("ODServiceEndTime");
            entity.Property(e => e.OdserviceTime)
                .HasComment("服务时间")
                .HasColumnType("datetime")
                .HasColumnName("ODServiceTime");
            entity.Property(e => e.OdspecId)
                .HasMaxLength(32)
                .HasComment("规格id")
                .HasColumnName("ODSpecID");
            entity.Property(e => e.OdspecName)
                .HasMaxLength(100)
                .HasComment("规格名称")
                .HasColumnName("ODSpecName");
            entity.Property(e => e.Odstatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(1:服务中,2:已完成3:已取消)")
                .HasColumnName("ODstatus");
            entity.Property(e => e.Odsubtotal)
                .HasPrecision(10, 2)
                .HasComment("小计金额(单价*数量)")
                .HasColumnName("ODSubtotal");
            entity.Property(e => e.OdtherapistId)
                .HasMaxLength(32)
                .HasComment("理疗师id")
                .HasColumnName("ODTherapistID");
        });

        modelBuilder.Entity<ProPackage>(entity =>
        {
            entity.HasKey(e => e.Pkid).HasName("PRIMARY");

            entity
                .ToTable("pro_packages", tb => tb.HasComment("服务套餐表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pkid)
                .HasMaxLength(32)
                .HasComment("套餐id")
                .HasColumnName("PKID");
            entity.Property(e => e.PkcategoryId)
                .HasMaxLength(32)
                .HasComment("套餐类型")
                .HasColumnName("PKCategoryID");
            entity.Property(e => e.PkcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PKCreateTime");
            entity.Property(e => e.Pkexplain)
                .HasComment("套餐描述")
                .HasColumnType("text")
                .HasColumnName("PKExplain");
            entity.Property(e => e.PkisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("PKIsBan");
            entity.Property(e => e.Pkname)
                .HasMaxLength(100)
                .HasComment("套餐名称")
                .HasColumnName("PKName");
            entity.Property(e => e.Pkphoto)
                .HasMaxLength(999)
                .HasComment("套餐图片")
                .HasColumnName("PKPhoto");
            entity.Property(e => e.Pkprice)
                .HasPrecision(10, 2)
                .HasComment("套餐价格")
                .HasColumnName("PKPrice");
            entity.Property(e => e.Pkpublish)
                .HasComment("是否发布(0:否,1:是)")
                .HasColumnName("PKPublish");
            entity.Property(e => e.Pksales)
                .HasComment("销量")
                .HasColumnName("PKSales");
            entity.Property(e => e.PkvalidityDays)
                .HasComment("套餐有效期(天)")
                .HasColumnName("PKValidityDays");
        });

        modelBuilder.Entity<ProPackageDetail>(entity =>
        {
            entity.HasKey(e => e.Pdid).HasName("PRIMARY");

            entity
                .ToTable("pro_package_details", tb => tb.HasComment("套餐服务项关联表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pdid)
                .HasMaxLength(32)
                .HasComment("关联id")
                .HasColumnName("PDID");
            entity.Property(e => e.PdcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PDCreateTime");
            entity.Property(e => e.Pdquantity)
                .HasDefaultValueSql("'1'")
                .HasComment("服务次数")
                .HasColumnName("PDQuantity");
            entity.Property(e => e.PpackageId)
                .HasMaxLength(32)
                .HasComment("套餐id")
                .HasColumnName("PPackageID");
            entity.Property(e => e.PserviceId)
                .HasMaxLength(32)
                .HasComment("服务id")
                .HasColumnName("PServiceID");
        });

        modelBuilder.Entity<ProPackageProduct>(entity =>
        {
            entity.HasKey(e => e.Ppid).HasName("PRIMARY");

            entity
                .ToTable("pro_package_products", tb => tb.HasComment("套餐产品项关联表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Ppid)
                .HasMaxLength(32)
                .HasComment("关联id")
                .HasColumnName("PPID");
            entity.Property(e => e.PpackageId)
                .HasMaxLength(32)
                .HasComment("套餐id")
                .HasColumnName("PPackageID");
            entity.Property(e => e.PppcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PPPCreateTime");
            entity.Property(e => e.Ppquantity)
                .HasDefaultValueSql("'1'")
                .HasComment("产品数量")
                .HasColumnName("PPQuantity");
            entity.Property(e => e.PproductId)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("PProductID");
            entity.Property(e => e.PspecId)
                .HasMaxLength(32)
                .HasComment("规格id")
                .HasColumnName("PSpecID");
        });

        modelBuilder.Entity<ProProduct>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PRIMARY");

            entity
                .ToTable("pro_products", tb => tb.HasComment("产品表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pid)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("PID");
            entity.Property(e => e.PcategoryId)
                .HasMaxLength(32)
                .HasComment("分类id")
                .HasColumnName("PCategoryID");
            entity.Property(e => e.PcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PCreateTime");
            entity.Property(e => e.Pexplain)
                .HasComment("产品描述")
                .HasColumnType("text")
                .HasColumnName("PExplain");
            entity.Property(e => e.PhasSpecs)
                .HasDefaultValueSql("'0'")
                .HasComment("是否有规格(0-否,1-是)")
                .HasColumnName("PHasSpecs");
            entity.Property(e => e.Pinventory)
                .HasDefaultValueSql("'0'")
                .HasComment("库存")
                .HasColumnName("PInventory");
            entity.Property(e => e.PisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("PIsBan");
            entity.Property(e => e.PisShelve)
                .HasComment("是否上架")
                .HasColumnName("PIsShelve");
            entity.Property(e => e.PlimitPurchase)
                .HasDefaultValueSql("'0'")
                .HasComment("是否限购(0-不限购,1-限购)")
                .HasColumnName("PLimitPurchase");
            entity.Property(e => e.PlimitQuantity)
                .HasDefaultValueSql("'0'")
                .HasComment("限购数量")
                .HasColumnName("PLimitQuantity");
            entity.Property(e => e.PminPurchase)
                .HasDefaultValueSql("'1'")
                .HasComment("起购数量")
                .HasColumnName("PMinPurchase");
            entity.Property(e => e.Pname)
                .HasMaxLength(100)
                .HasComment("产品名称")
                .HasColumnName("PName");
            entity.Property(e => e.Pphoto)
                .HasMaxLength(999)
                .HasComment("产品图片")
                .HasColumnName("PPhoto");
            entity.Property(e => e.Pprice)
                .HasPrecision(10, 2)
                .HasComment("商品售价")
                .HasColumnName("PPrice");
            entity.Property(e => e.Psales)
                .HasComment("销量")
                .HasColumnName("PSales");
            entity.Property(e => e.PshelveTime)
                .HasComment("上架时间")
                .HasColumnType("datetime")
                .HasColumnName("PShelveTime");
            entity.Property(e => e.Pspecs)
                .HasMaxLength(255)
                .HasComment("基础规格")
                .HasColumnName("PSpecs");
        });

        modelBuilder.Entity<ProProductDetail>(entity =>
        {
            entity.HasKey(e => e.Pdid).HasName("PRIMARY");

            entity
                .ToTable("pro_product_details", tb => tb.HasComment("产品详情表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pdid)
                .HasMaxLength(32)
                .HasComment("详情id")
                .HasColumnName("PDID");
            entity.Property(e => e.PdcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PDCreateTime");
            entity.Property(e => e.Pdpid)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("PDPID");
            entity.Property(e => e.Pdpphoto)
                .HasMaxLength(999)
                .HasComment("产品图片")
                .HasColumnName("PDPPhoto");
            entity.Property(e => e.Pdsort)
                .HasDefaultValueSql("'0'")
                .HasComment("排序")
                .HasColumnName("PDSort");
        });

        modelBuilder.Entity<ProProductInventory>(entity =>
        {
            entity.HasKey(e => e.Siid).HasName("PRIMARY");

            entity
                .ToTable("pro_product_inventorys", tb => tb.HasComment("产品库存表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Siid)
                .HasMaxLength(32)
                .HasComment("库存记录id")
                .HasColumnName("SIID");
            entity.Property(e => e.SilastUpdateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("最后更新时间")
                .HasColumnType("datetime")
                .HasColumnName("SILastUpdateTime");
            entity.Property(e => e.SiproductId)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("SIProductID");
            entity.Property(e => e.SispecId)
                .HasMaxLength(32)
                .HasComment("规格id(为空表示产品总库存)")
                .HasColumnName("SISpecID");
            entity.Property(e => e.SistockQuantity)
                .HasDefaultValueSql("'0'")
                .HasComment("库存数量")
                .HasColumnName("SIStockQuantity");
        });

        modelBuilder.Entity<ProProductPhoto>(entity =>
        {
            entity.HasKey(e => e.Pdid).HasName("PRIMARY");

            entity
                .ToTable("pro_product_photos")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Pdid)
                .HasMaxLength(32)
                .HasComment("详情id")
                .HasColumnName("PDID");
            entity.Property(e => e.PdcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PDCreateTime");
            entity.Property(e => e.PdisMain)
                .HasDefaultValueSql("'0'")
                .HasComment("是否主图(0-否,1-是)")
                .HasColumnName("PDIsMain");
            entity.Property(e => e.Pdpid)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("PDPID");
            entity.Property(e => e.Pdpphoto)
                .HasMaxLength(999)
                .HasComment("产品图片")
                .HasColumnName("PDPPhoto");
            entity.Property(e => e.Pdsort)
                .HasDefaultValueSql("'0'")
                .HasComment("排序")
                .HasColumnName("PDSort");
        });

        modelBuilder.Entity<ProProductSpec>(entity =>
        {
            entity.HasKey(e => e.Psid).HasName("PRIMARY");

            entity
                .ToTable("pro_product_specs", tb => tb.HasComment("产品规格表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Psid)
                .HasMaxLength(32)
                .HasComment("规格id")
                .HasColumnName("PSID");
            entity.Property(e => e.PproductId)
                .HasMaxLength(32)
                .HasComment("产品id")
                .HasColumnName("PProductID");
            entity.Property(e => e.PscreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("PSCreateTime");
            entity.Property(e => e.Psiban)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("PSIBan");
            entity.Property(e => e.Psphoto)
                .HasMaxLength(999)
                .HasComment("规格图片")
                .HasColumnName("PSPhoto");
            entity.Property(e => e.Psprice)
                .HasPrecision(10, 2)
                .HasComment("规格价格")
                .HasColumnName("PSPrice");
            entity.Property(e => e.PssortOrder)
                .HasDefaultValueSql("'0'")
                .HasComment("排序号")
                .HasColumnName("PSSortOrder");
            entity.Property(e => e.PsspecName)
                .HasMaxLength(100)
                .HasComment("规格名称")
                .HasColumnName("PSSpecName");
            entity.Property(e => e.PsspecValue)
                .HasMaxLength(100)
                .HasComment("规格值(如:一瓶,一箱)")
                .HasColumnName("PSSpecValue");
        });

        modelBuilder.Entity<ProService>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PRIMARY");

            entity
                .ToTable("pro_services", tb => tb.HasComment("服务表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Sid)
                .HasMaxLength(32)
                .HasComment("服务id")
                .HasColumnName("SID");
            entity.Property(e => e.ScategoryId)
                .HasMaxLength(32)
                .HasComment("分类id")
                .HasColumnName("SCategoryID");
            entity.Property(e => e.ScreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("SCreateTime");
            entity.Property(e => e.Sduration)
                .HasMaxLength(225)
                .HasComment("时长(分钟)")
                .HasColumnName("SDuration");
            entity.Property(e => e.Sexplain)
                .HasComment("服务描述")
                .HasColumnType("text")
                .HasColumnName("SExplain");
            entity.Property(e => e.SisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用(0:否,1:是)")
                .HasColumnName("SIsBan");
            entity.Property(e => e.Sname)
                .HasMaxLength(100)
                .HasComment("服务名称")
                .HasColumnName("SName");
            entity.Property(e => e.Sphoto)
                .HasMaxLength(999)
                .HasComment("服务图片")
                .HasColumnName("SPhoto");
            entity.Property(e => e.Sprice)
                .HasPrecision(10, 2)
                .HasComment("价格")
                .HasColumnName("SPrice");
            entity.Property(e => e.Ssales)
                .HasComment("服务销量")
                .HasColumnName("SSales");
            entity.Property(e => e.SuseCount).HasComment("使用次数");
        });

        modelBuilder.Entity<SchAppointment>(entity =>
        {
            entity.HasKey(e => e.Said).HasName("PRIMARY");

            entity
                .ToTable("sch_appointments", tb => tb.HasComment("预约表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Said)
                .HasMaxLength(32)
                .HasComment("预约id")
                .HasColumnName("SAID");
            entity.Property(e => e.SacreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("SACreateTime");
            entity.Property(e => e.SacustomerId)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("SACustomerID");
            entity.Property(e => e.Sadate)
                .HasComment("预约日期")
                .HasColumnName("SADate");
            entity.Property(e => e.SaendTime)
                .HasComment("结束时间")
                .HasColumnType("datetime")
                .HasColumnName("SAEndTime");
            entity.Property(e => e.SaisReminded)
                .HasDefaultValueSql("'0'")
                .HasComment("是否已提醒(0:否,1:是)")
                .HasColumnName("SAIsReminded");
            entity.Property(e => e.Sanote)
                .HasComment("备注")
                .HasColumnType("text")
                .HasColumnName("SANote");
            entity.Property(e => e.SastartTime)
                .HasComment("开始时间")
                .HasColumnType("datetime")
                .HasColumnName("SAStartTime");
            entity.Property(e => e.Sastatus)
                .HasDefaultValueSql("'0'")
                .HasComment("状态(0:待确认,1:已预约,2:已完成,3:已取消,4:已转订单)")
                .HasColumnName("SAStatus");
            entity.Property(e => e.SatherapistId)
                .HasMaxLength(32)
                .HasComment("理疗师id")
                .HasColumnName("SATherapistID");
            entity.Property(e => e.SaupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("SAUpdateTime");
        });

        modelBuilder.Entity<SchAppointmentItem>(entity =>
        {
            entity.HasKey(e => e.Saiid).HasName("PRIMARY");

            entity
                .ToTable("sch_appointment_items", tb => tb.HasComment("预约项目明细表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Saiid)
                .HasMaxLength(32)
                .HasComment("预约项目id")
                .HasColumnName("SAIID");
            entity.Property(e => e.SaiappointmentId)
                .HasMaxLength(32)
                .HasComment("关联预约id")
                .HasColumnName("SAIAppointmentID");
            entity.Property(e => e.SaicreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("SAICreateTime");
            entity.Property(e => e.SaiitemId)
                .HasMaxLength(32)
                .HasComment("服务/套餐id")
                .HasColumnName("SAIItemID");
            entity.Property(e => e.Saiprice)
                .HasPrecision(10, 2)
                .HasComment("单价")
                .HasColumnName("SAIPrice");
            entity.Property(e => e.Saiquantity)
                .HasDefaultValueSql("'1'")
                .HasComment("数量")
                .HasColumnName("SAIQuantity");
            entity.Property(e => e.Saitype)
                .HasComment("项目类型(1:服务,2:套餐)")
                .HasColumnName("SAIType");
        });

        modelBuilder.Entity<SchHistory>(entity =>
        {
            entity.HasKey(e => e.Shid).HasName("PRIMARY");

            entity
                .ToTable("sch_historys", tb => tb.HasComment("排班历史记录表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Shid)
                .HasMaxLength(32)
                .HasComment("历史id")
                .HasColumnName("SHID");
            entity.Property(e => e.ShchangeDetails)
                .HasComment("变更详情")
                .HasColumnType("text")
                .HasColumnName("SHChangeDetails");
            entity.Property(e => e.ShchangeTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("变更时间")
                .HasColumnType("datetime")
                .HasColumnName("SHChangeTime");
            entity.Property(e => e.ShchangeType)
                .HasComment("变更类型:0-人员变更,1-班次交换,2-替班安排,3-状态变更,4-时间调整")
                .HasColumnName("SHChangeType");
            entity.Property(e => e.ShchangedById)
                .HasMaxLength(32)
                .HasComment("变更人id")
                .HasColumnName("SHChangedByID");
            entity.Property(e => e.ShscheduleId)
                .HasMaxLength(32)
                .HasComment("排班id")
                .HasColumnName("SHScheduleID");
        });

        modelBuilder.Entity<SchPlan>(entity =>
        {
            entity.HasKey(e => e.Spid).HasName("PRIMARY");

            entity
                .ToTable("sch_plans", tb => tb.HasComment("排班计划表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Spid)
                .HasMaxLength(32)
                .HasComment("计划id")
                .HasColumnName("SPID");
            entity.Property(e => e.SpcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("SPCreateTime");
            entity.Property(e => e.SpendDate)
                .HasComment("结束日期")
                .HasColumnName("SPEndDate");
            entity.Property(e => e.Spexplain)
                .HasComment("描述")
                .HasColumnType("text")
                .HasColumnName("SPExplain");
            entity.Property(e => e.SpisPublish)
                .HasDefaultValueSql("'0'")
                .HasComment("是否发布")
                .HasColumnName("SPIsPublish");
            entity.Property(e => e.Spname)
                .HasMaxLength(100)
                .HasComment("计划名称")
                .HasColumnName("SPName");
            entity.Property(e => e.SpstartDate)
                .HasComment("开始日期")
                .HasColumnName("SPStartDate");
            entity.Property(e => e.SpupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("SPUpdateTime");
        });

        modelBuilder.Entity<SchRoomAppointment>(entity =>
        {
            entity.HasKey(e => e.Raid).HasName("PRIMARY");

            entity
                .ToTable("sch_room_appointments", tb => tb.HasComment("理疗室排班表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Raid)
                .HasMaxLength(32)
                .HasComment("疗室预约id")
                .HasColumnName("RAID");
            entity.Property(e => e.RaappointmentId)
                .HasMaxLength(32)
                .HasComment("关联预约id")
                .HasColumnName("RAAppointmentID");
            entity.Property(e => e.RacancelTime)
                .HasComment("取消时间")
                .HasColumnType("datetime")
                .HasColumnName("RACancelTime");
            entity.Property(e => e.RacompleteTime)
                .HasComment("完成时间")
                .HasColumnType("datetime")
                .HasColumnName("RACompleteTime");
            entity.Property(e => e.RaconfirmTime)
                .HasComment("确认时间")
                .HasColumnType("datetime")
                .HasColumnName("RAConfirmTime");
            entity.Property(e => e.RacreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("RACreateTime");
            entity.Property(e => e.RaemployeeId)
                .HasMaxLength(32)
                .HasComment("员工/负责人id")
                .HasColumnName("RAEmployeeID");
            entity.Property(e => e.RaendTime)
                .HasComment("预约结束时间")
                .HasColumnType("datetime")
                .HasColumnName("RAEndTime");
            entity.Property(e => e.RapeopleCount)
                .HasComment("预约人数")
                .HasColumnName("RApeople_count");
            entity.Property(e => e.RaroomId)
                .HasMaxLength(32)
                .HasComment("理疗室id")
                .HasColumnName("RARoomID");
            entity.Property(e => e.RascheduleId)
                .HasMaxLength(32)
                .HasComment("排班id")
                .HasColumnName("RAScheduleID");
            entity.Property(e => e.RastartTime)
                .HasComment("预约开始时间")
                .HasColumnType("datetime")
                .HasColumnName("RAStartTime");
            entity.Property(e => e.Rastatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(0-待确认, 1-已预约, 2-使用中, 3-已完成, 4-已取消)")
                .HasColumnName("RAStatus");
        });

        modelBuilder.Entity<SchSchedule>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PRIMARY");

            entity
                .ToTable("sch_schedules", tb => tb.HasComment("排班表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Sid)
                .HasMaxLength(32)
                .HasComment("排班id")
                .HasColumnName("SID");
            entity.Property(e => e.ScreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("SCreateTime");
            entity.Property(e => e.Sdate)
                .HasComment("排班日期")
                .HasColumnName("SDate");
            entity.Property(e => e.SemployeeId)
                .HasMaxLength(32)
                .HasComment("员工id")
                .HasColumnName("SEmployeeID");
            entity.Property(e => e.SendTime)
                .HasComment("结束时间")
                .HasColumnType("time")
                .HasColumnName("SEndTime");
            entity.Property(e => e.Snote)
                .HasMaxLength(255)
                .HasComment("备注")
                .HasColumnName("SNote");
            entity.Property(e => e.SplanId)
                .HasMaxLength(32)
                .HasComment("计划id")
                .HasColumnName("SPlanID");
            entity.Property(e => e.SstartTime)
                .HasComment("开始时间")
                .HasColumnType("time")
                .HasColumnName("SStartTime");
            entity.Property(e => e.Sstatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态(1:值班,2:休息,3:请假)")
                .HasColumnName("SStatus");
            entity.Property(e => e.SupdateTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("SUpdateTime");
        });

        modelBuilder.Entity<SchTherapyRoom>(entity =>
        {
            entity.HasKey(e => e.Trid).HasName("PRIMARY");

            entity
                .ToTable("sch_therapy_rooms", tb => tb.HasComment("理疗室信息表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Trcode, "TRCode").IsUnique();

            entity.Property(e => e.Trid)
                .HasMaxLength(32)
                .HasComment("理疗室id")
                .HasColumnName("TRID");
            entity.Property(e => e.Trcapacity)
                .HasDefaultValueSql("'1'")
                .HasComment("容纳人数")
                .HasColumnName("TRCapacity");
            entity.Property(e => e.Trcode)
                .HasMaxLength(50)
                .HasComment("理疗室编号")
                .HasColumnName("TRCode");
            entity.Property(e => e.TrcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("TRCreateTime");
            entity.Property(e => e.Trdescription)
                .HasComment("描述")
                .HasColumnType("text")
                .HasColumnName("TRDescription");
            entity.Property(e => e.Trfloor)
                .HasComment("所在楼层")
                .HasColumnName("TRFloor");
            entity.Property(e => e.TrisEquipmentReady)
                .HasDefaultValueSql("'1'")
                .HasComment("设备是否就位(0:否,1:是)")
                .HasColumnName("TRIsEquipmentReady");
            entity.Property(e => e.Trname)
                .HasMaxLength(100)
                .HasComment("理疗室名称")
                .HasColumnName("TRName");
            entity.Property(e => e.Trstatus)
                .HasDefaultValueSql("'1'")
                .HasComment("1:可用,2:维护中,3:停用,4已满")
                .HasColumnName("TRStatus");
            entity.Property(e => e.Trtype)
                .HasComment("类型(1:单人,2:双人)")
                .HasColumnName("TRType");
            entity.Property(e => e.TrupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("TRUpdateTime");
        });

        modelBuilder.Entity<SysActionLog>(entity =>
        {
            entity.HasKey(e => e.Alid).HasName("PRIMARY");

            entity
                .ToTable("sys_action_logs", tb => tb.HasComment("操作日志表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Alid)
                .HasMaxLength(32)
                .HasComment("日志id")
                .HasColumnName("ALID");
            entity.Property(e => e.AlAction)
                .HasMaxLength(99)
                .HasComment("操作行为/动作");
            entity.Property(e => e.AlCreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime");
            entity.Property(e => e.AlGroup)
                .HasMaxLength(99)
                .HasComment("操作分组/模块");
            entity.Property(e => e.AlIp)
                .HasMaxLength(255)
                .HasComment("操作IP地址");
            entity.Property(e => e.AlMethod)
                .HasMaxLength(99)
                .HasComment("HTTP请求方法");
            entity.Property(e => e.AlParams)
                .HasMaxLength(999)
                .HasComment("参数");
            entity.Property(e => e.AlUid)
                .HasMaxLength(32)
                .HasComment("操作人")
                .HasColumnName("AlUID");
            entity.Property(e => e.AlUrl)
                .HasMaxLength(99)
                .HasComment("操作URL地址");
            entity.Property(e => e.Alresult)
                .HasComment("结果")
                .HasColumnName("ALResult");
        });

        modelBuilder.Entity<SysAdmin>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PRIMARY");

            entity
                .ToTable("sys_admins", tb => tb.HasComment("系统管理员表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Ausername, "uk_ausername").IsUnique();

            entity.Property(e => e.Aid)
                .HasMaxLength(32)
                .HasComment("管理员ID（主键）")
                .HasColumnName("AID");
            entity.Property(e => e.Aavatar)
                .HasMaxLength(999)
                .HasComment("头像");
            entity.Property(e => e.AcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ACreateTime");
            entity.Property(e => e.Aemail)
                .HasMaxLength(100)
                .HasComment("邮箱")
                .HasColumnName("AEmail");
            entity.Property(e => e.AisActive)
                .HasComment("是否激活")
                .HasColumnName("AIsActive");
            entity.Property(e => e.AlastLoginIp)
                .HasMaxLength(32)
                .HasComment("最后登录IP")
                .HasColumnName("ALastLoginIP");
            entity.Property(e => e.AlastLoginTime)
                .HasComment("最后登录时间")
                .HasColumnType("datetime")
                .HasColumnName("ALastLoginTime");
            entity.Property(e => e.Apassword)
                .HasMaxLength(32)
                .HasComment("密码")
                .HasColumnName("APassword");
            entity.Property(e => e.Aphone)
                .HasMaxLength(20)
                .HasComment("手机号")
                .HasColumnName("APhone");
            entity.Property(e => e.AroleId)
                .HasMaxLength(32)
                .HasComment("角色ID")
                .HasColumnName("ARoleID");
            entity.Property(e => e.Asalt)
                .HasMaxLength(32)
                .HasComment("盐值")
                .HasColumnName("ASalt");
            entity.Property(e => e.Astatus)
                .HasDefaultValueSql("'1'")
                .HasComment("状态（0-禁用，1-正常）")
                .HasColumnName("AStatus");
            entity.Property(e => e.AupdateTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("AUpdateTime");
            entity.Property(e => e.Ausername)
                .HasMaxLength(50)
                .HasComment("登录姓名")
                .HasColumnName("AUsername");
        });

        modelBuilder.Entity<SysAdminLoginLog>(entity =>
        {
            entity.HasKey(e => e.Lid).HasName("PRIMARY");

            entity
                .ToTable("sys_admin_login_logs", tb => tb.HasComment("管理员登录日志表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Laid, "idx_laid");

            entity.HasIndex(e => e.LloginTime, "idx_logintime");

            entity.Property(e => e.Lid)
                .HasMaxLength(32)
                .HasComment("日志ID（主键）")
                .HasColumnName("LID");
            entity.Property(e => e.Laid)
                .HasMaxLength(32)
                .HasComment("管理员ID（关联sys_admins表AID）")
                .HasColumnName("LAID");
            entity.Property(e => e.Lausername)
                .HasMaxLength(50)
                .HasComment("登录用户名")
                .HasColumnName("LAUsername");
            entity.Property(e => e.Lbrowser)
                .HasMaxLength(500)
                .HasComment("浏览器")
                .HasColumnName("LBrowser");
            entity.Property(e => e.LexpireTime)
                .HasComment("登录状态过期时间")
                .HasColumnType("datetime")
                .HasColumnName("LExpireTime");
            entity.Property(e => e.LfailReason)
                .HasMaxLength(255)
                .HasComment("失败原因")
                .HasColumnName("LFailReason");
            entity.Property(e => e.Llcode)
                .HasMaxLength(32)
                .HasComment("账号")
                .HasColumnName("LLCode");
            entity.Property(e => e.Llocation)
                .HasMaxLength(255)
                .HasComment("登录地点")
                .HasColumnName("LLocation");
            entity.Property(e => e.LloginIp)
                .HasMaxLength(32)
                .HasComment("登录IP地址")
                .HasColumnName("LLoginIP");
            entity.Property(e => e.LloginResult)
                .HasComment("登录结果（0-失败，1-成功）")
                .HasColumnName("LLoginResult");
            entity.Property(e => e.LloginTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("登录时间")
                .HasColumnType("datetime")
                .HasColumnName("LLoginTime");
            entity.Property(e => e.LoperatingSystem)
                .HasMaxLength(100)
                .HasComment("操作系统")
                .HasColumnName("LOperatingSystem");
        });

        modelBuilder.Entity<SysClientLoginLog>(entity =>
        {
            entity.HasKey(e => e.Llid).HasName("PRIMARY");

            entity
                .ToTable("sys_client_login_logs", tb => tb.HasComment("客户登录日志表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Llid)
                .HasMaxLength(32)
                .HasComment("日志id")
                .HasColumnName("LLID");
            entity.Property(e => e.Llaccount)
                .HasMaxLength(11)
                .HasComment("账号")
                .HasColumnName("LLAccount");
            entity.Property(e => e.Llapex)
                .HasMaxLength(100)
                .HasComment("设备")
                .HasColumnName("LLApex");
            entity.Property(e => e.Llbrowser)
                .HasMaxLength(100)
                .HasComment("浏览器")
                .HasColumnName("LLBrowser");
            entity.Property(e => e.Llcid)
                .HasMaxLength(32)
                .HasComment("客户id")
                .HasColumnName("LLCID");
            entity.Property(e => e.Llcode)
                .HasMaxLength(32)
                .HasComment("生成的凭据")
                .HasColumnName("LLCode");
            entity.Property(e => e.LlcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("LLCreateTime");
            entity.Property(e => e.Llip)
                .HasMaxLength(32)
                .HasComment("IP地址")
                .HasColumnName("LLIP");
            entity.Property(e => e.Llox)
                .HasMaxLength(255)
                .HasComment("登录系统")
                .HasColumnName("LLOx");
            entity.Property(e => e.Llregion)
                .HasMaxLength(999)
                .HasComment("地区")
                .HasColumnName("LLRegion");
            entity.Property(e => e.Lltake)
                .HasComment("耗时")
                .HasColumnName("LLTake");
            entity.Property(e => e.LltimeOut)
                .HasComment("登录状态保持时间")
                .HasColumnType("datetime")
                .HasColumnName("LLTimeOut");
        });

        modelBuilder.Entity<SysDictionary>(entity =>
        {
            entity.HasKey(e => e.Did).HasName("PRIMARY");

            entity
                .ToTable("sys_dictionarys", tb => tb.HasComment("字典表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Dname, "DName").IsUnique();

            entity.Property(e => e.Did)
                .HasMaxLength(32)
                .HasComment("类型id")
                .HasColumnName("DID");
            entity.Property(e => e.Dcount)
                .HasComment("使用次数")
                .HasColumnName("DCount");
            entity.Property(e => e.DcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("DCreateTime");
            entity.Property(e => e.Dexplain)
                .HasMaxLength(999)
                .HasComment("类型描述")
                .HasColumnName("DExplain");
            entity.Property(e => e.Dicon)
                .HasMaxLength(255)
                .HasComment("类型图标")
                .HasColumnName("DIcon");
            entity.Property(e => e.DisBan)
                .HasComment("是否禁用")
                .HasColumnName("DIsBan");
            entity.Property(e => e.DisTop)
                .HasComment("是否置顶")
                .HasColumnName("DIsTop");
            entity.Property(e => e.DisType)
                .HasDefaultValueSql("'0'")
                .HasComment("是否是类型")
                .HasColumnName("DIsType");
            entity.Property(e => e.Dname)
                .HasMaxLength(99)
                .HasComment("类型名称")
                .HasColumnName("DName");
            entity.Property(e => e.DparentId)
                .HasMaxLength(32)
                .HasComment("上级")
                .HasColumnName("DParent_id");
            entity.Property(e => e.Dphoto)
                .HasMaxLength(999)
                .HasComment("类型图片")
                .HasColumnName("DPhoto");
            entity.Property(e => e.Dvalue)
                .HasMaxLength(255)
                .HasComment("类型值")
                .HasColumnName("DValue");
        });

        modelBuilder.Entity<SysEmployeeLoginLog>(entity =>
        {
            entity.HasKey(e => e.Llid).HasName("PRIMARY");

            entity
                .ToTable("sys_employee_login_logs", tb => tb.HasComment("员工登录日志表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Llid)
                .HasMaxLength(32)
                .HasComment("日志id")
                .HasColumnName("LLID");
            entity.Property(e => e.Llaccount)
                .HasMaxLength(11)
                .HasComment("账号")
                .HasColumnName("LLAccount");
            entity.Property(e => e.Llapex)
                .HasMaxLength(100)
                .HasComment("设备")
                .HasColumnName("LLApex");
            entity.Property(e => e.Llbrowser)
                .HasMaxLength(100)
                .HasComment("浏览器")
                .HasColumnName("LLBrowser");
            entity.Property(e => e.Llcode)
                .HasMaxLength(32)
                .HasComment("生成的凭据")
                .HasColumnName("LLCode");
            entity.Property(e => e.LlcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("LLCreateTime");
            entity.Property(e => e.Lleid)
                .HasMaxLength(32)
                .HasComment("员工id")
                .HasColumnName("LLEID");
            entity.Property(e => e.Llip)
                .HasMaxLength(32)
                .HasComment("IP地址")
                .HasColumnName("LLIP");
            entity.Property(e => e.Llox)
                .HasMaxLength(255)
                .HasComment("登录系统")
                .HasColumnName("LLOx");
            entity.Property(e => e.Llregion)
                .HasMaxLength(999)
                .HasComment("地区")
                .HasColumnName("LLRegion");
            entity.Property(e => e.Lltake)
                .HasComment("耗时")
                .HasColumnName("LLTake");
            entity.Property(e => e.LltimeOut)
                .HasComment("登录状态保持时间")
                .HasColumnType("datetime")
                .HasColumnName("LLTimeOut");
        });

        modelBuilder.Entity<SysEmployeeRight>(entity =>
        {
            entity.HasKey(e => e.Ermid).HasName("PRIMARY");

            entity
                .ToTable("sys_employee_rights", tb => tb.HasComment("角色菜单关联表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Ermid)
                .HasMaxLength(32)
                .HasComment("关联id")
                .HasColumnName("ERMID");
            entity.Property(e => e.Errid)
                .HasMaxLength(32)
                .HasComment("权限id")
                .HasColumnName("ERRID");
            entity.Property(e => e.ErroleId)
                .HasMaxLength(32)
                .HasComment("角色id")
                .HasColumnName("ERRoleID");
            entity.Property(e => e.RcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("RCreateTime");
        });

        modelBuilder.Entity<SysEmployeeRole>(entity =>
        {
            entity.HasKey(e => e.Erid).HasName("PRIMARY");

            entity
                .ToTable("sys_employee_roles", tb => tb.HasComment("员工角色关联表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Erid)
                .HasMaxLength(32)
                .HasComment("关联id")
                .HasColumnName("ERID");
            entity.Property(e => e.ErcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ERCreateTime");
            entity.Property(e => e.Ereid)
                .HasMaxLength(32)
                .HasComment("员工id")
                .HasColumnName("EREID");
            entity.Property(e => e.Errid)
                .HasMaxLength(32)
                .HasComment("角色id")
                .HasColumnName("ERRID");
        });

        modelBuilder.Entity<SysErrorLog>(entity =>
        {
            entity.HasKey(e => e.Elid).HasName("PRIMARY");

            entity
                .ToTable("sys_error_logs", tb => tb.HasComment("错误日志表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Elid)
                .HasMaxLength(32)
                .HasComment("日志id")
                .HasColumnName("ELID");
            entity.Property(e => e.ElIp)
                .HasMaxLength(255)
                .HasComment("操作IP地址");
            entity.Property(e => e.ElMethod)
                .HasMaxLength(99)
                .HasComment("HTTP请求方法");
            entity.Property(e => e.ElParams)
                .HasMaxLength(999)
                .HasComment("参数");
            entity.Property(e => e.ElUrl)
                .HasMaxLength(99)
                .HasComment("操作URL地址");
            entity.Property(e => e.ElcreateTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("ELCreateTime");
            entity.Property(e => e.Elmessage)
                .HasMaxLength(999)
                .HasComment("操作信息")
                .HasColumnName("ELMessage");
            entity.Property(e => e.Eluid)
                .HasMaxLength(32)
                .HasComment("操作用户")
                .HasColumnName("ELUID");
        });

        modelBuilder.Entity<SysModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("sys_modules", tb => tb.HasComment("管理端系统模块表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.ParentId, "idx_parent_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("create_time");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("图标标识")
                .HasColumnName("icon");
            entity.Property(e => e.IsShow)
                .HasDefaultValueSql("'1'")
                .HasComment("是否显示（1=显示，0=隐藏）")
                .HasColumnName("is_show");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("模块名称")
                .HasColumnName("name");
            entity.Property(e => e.OrderNum)
                .HasComment("排序序号")
                .HasColumnName("order_num");
            entity.Property(e => e.ParentId).HasColumnName("Parent_id");
            entity.Property(e => e.Route)
                .HasMaxLength(100)
                .HasDefaultValueSql("''")
                .HasComment("路由地址")
                .HasColumnName("route");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("状态（1=启用，0=禁用）")
                .HasColumnName("status");
        });

        modelBuilder.Entity<SysNotification>(entity =>
        {
            entity.HasKey(e => e.Nid).HasName("PRIMARY");

            entity
                .ToTable("sys_notifications", tb => tb.HasComment("系统消息通知表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Nid)
                .HasMaxLength(32)
                .HasComment("消息id")
                .HasColumnName("NID");
            entity.Property(e => e.Ncontent)
                .HasComment("消息内容")
                .HasColumnType("text")
                .HasColumnName("NContent");
            entity.Property(e => e.NcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("NCreateTime");
            entity.Property(e => e.NisDeleted)
                .HasDefaultValueSql("'0'")
                .HasComment("是否删除")
                .HasColumnName("NIsDeleted");
            entity.Property(e => e.NreadTime)
                .HasComment("阅读时间")
                .HasColumnType("datetime")
                .HasColumnName("NReadTime");
            entity.Property(e => e.NreceiverId)
                .HasMaxLength(32)
                .HasComment("接收人id")
                .HasColumnName("NReceiverID");
            entity.Property(e => e.NreceiverType)
                .HasDefaultValueSql("'1'")
                .HasComment("接收人类型:1-员工,2-客户")
                .HasColumnName("NReceiverType");
            entity.Property(e => e.NrelatedId)
                .HasMaxLength(32)
                .HasComment("关联业务id")
                .HasColumnName("NRelatedID");
            entity.Property(e => e.Nstatus)
                .HasDefaultValueSql("'0'")
                .HasComment("状态:0-未读,1-已读")
                .HasColumnName("NStatus");
            entity.Property(e => e.Ntitle)
                .HasMaxLength(100)
                .HasComment("消息标题")
                .HasColumnName("NTitle");
            entity.Property(e => e.Ntype)
                .HasComment("消息类型:0-订单,1-预约,2-佣金,3-跟进,4-支付,5-系统")
                .HasColumnName("NType");
        });

        modelBuilder.Entity<SysRight>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PRIMARY");

            entity
                .ToTable("sys_rights", tb => tb.HasComment("菜单表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Rid)
                .HasMaxLength(32)
                .HasComment("菜单id")
                .HasColumnName("RID");
            entity.Property(e => e.Rcode)
                .HasMaxLength(100)
                .HasComment("权限编码(唯一标识:employee:add_dept)")
                .HasColumnName("RCode");
            entity.Property(e => e.RcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("RCreateTime");
            entity.Property(e => e.Ricon)
                .HasMaxLength(100)
                .HasComment("菜单图标")
                .HasColumnName("RIcon");
            entity.Property(e => e.RisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用")
                .HasColumnName("RIsBan");
            entity.Property(e => e.RisPublish)
                .HasDefaultValueSql("'0'")
                .HasComment("是否发布")
                .HasColumnName("RIsPublish");
            entity.Property(e => e.Rname)
                .HasMaxLength(100)
                .HasComment("菜单名称")
                .HasColumnName("RName");
            entity.Property(e => e.RparentId)
                .HasMaxLength(32)
                .HasComment("父菜单id")
                .HasColumnName("RParentID");
            entity.Property(e => e.RsortOrder)
                .HasDefaultValueSql("'0'")
                .HasComment("排序号")
                .HasColumnName("RSortOrder");
            entity.Property(e => e.Rtype)
                .HasDefaultValueSql("'0'")
                .HasComment("权限类型(1:菜单 2:按钮 3:Api)")
                .HasColumnName("RType");
            entity.Property(e => e.Rurl)
                .HasMaxLength(255)
                .HasComment("菜单路径")
                .HasColumnName("RUrl");
        });

        modelBuilder.Entity<SysRole>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("PRIMARY");

            entity
                .ToTable("sys_roles", tb => tb.HasComment("角色表"))
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Rname, "RName").IsUnique();

            entity.Property(e => e.Rid)
                .HasMaxLength(32)
                .HasComment("角色id")
                .HasColumnName("RID");
            entity.Property(e => e.Rcode)
                .HasMaxLength(100)
                .HasComment("编码/唯一标识")
                .HasColumnName("RCode");
            entity.Property(e => e.RcreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("RCreateTime");
            entity.Property(e => e.Rdescription)
                .HasMaxLength(500)
                .HasComment("角色描述")
                .HasColumnName("RDescription");
            entity.Property(e => e.RisBan)
                .HasDefaultValueSql("'0'")
                .HasComment("是否禁用")
                .HasColumnName("RIsBan");
            entity.Property(e => e.Rname)
                .HasMaxLength(100)
                .HasComment("角色名称")
                .HasColumnName("RName");
            entity.Property(e => e.RsortOrder)
                .HasComment("排序")
                .HasColumnName("RSortOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
