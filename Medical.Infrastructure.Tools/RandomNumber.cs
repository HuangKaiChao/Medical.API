namespace Medical.Infrastructure.Tools
{
    public static class RandomNumber
    {
        // 线程锁确保并发安全
        private static readonly object _lock = new object();
        
        // 推广订单主单号相关字段
        private static string _currentMonthForMPO = string.Empty;
        private static int _monthlyCountForMPO = 1;
        
        // 推广订单详情单号相关字段
        private static string _currentMonthForMPOD = string.Empty;
        private static int _monthlyCountForMPOD = 1;

        /// <summary>
        /// 生成推广订单主单号(MPO前缀)
        /// 格式：MPO + 年月(6位) + 序号(4位)，如：MPO2024050001
        /// </summary>
        public static string GenerateMarketingOrderNumber()
        {
            lock (_lock)
            {
                string currentYearMonth = DateTime.Now.ToString("yyyyMM");
                
                // 跨月重置
                if (currentYearMonth != _currentMonthForMPO)
                {
                    _currentMonthForMPO = currentYearMonth;
                    _monthlyCountForMPO = 1;
                }
                
                string orderNumber = $"MPO{currentYearMonth}{_monthlyCountForMPO.ToString("D4")}";
                
                // 序号自增，最大9999
                _monthlyCountForMPO = _monthlyCountForMPO >= 9999 ? 1 : _monthlyCountForMPO + 1;
                
                return orderNumber;
            }
        }

        /// <summary>
        /// 生成推广订单详情单号(MPOD前缀)
        /// 格式：MPOD + 年月(6位) + 序号(4位)，如：MPOD2024050001
        /// </summary>
        public static string GenerateMarketingOrderDetailNumber()
        {
            lock (_lock)
            {
                string currentYearMonth = DateTime.Now.ToString("yyyyMM");
                
                // 跨月重置
                if (currentYearMonth != _currentMonthForMPOD)
                {
                    _currentMonthForMPOD = currentYearMonth;
                    _monthlyCountForMPOD = 1;
                }
                
                string detailNumber = $"MPOD{currentYearMonth}{_monthlyCountForMPOD.ToString("D4")}";
                
                // 序号自增，最大9999
                _monthlyCountForMPOD = _monthlyCountForMPOD >= 9999 ? 1 : _monthlyCountForMPOD + 1;
                
                return detailNumber;
            }
        }

        /// <summary>
        /// 生成普通订单号(P前缀)
        /// 格式：P + 年月日时分秒(12位) + 序号(4位)，如：P2024051514300001
        /// </summary>
        public static string GeneraOrderNumber()
        {
            lock (_lock)
            {
                return $"P{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
            }
        }

        /// <summary>
        /// 生成唯一ID(T前缀)
        /// 格式：T + 时间戳，如：T638389728473671250
        /// </summary>
        public static string GenerateUniqueId()
        {
            lock (_lock)
            {
                return $"T{DateTime.Now.Ticks}";
            }
        }
    }
}