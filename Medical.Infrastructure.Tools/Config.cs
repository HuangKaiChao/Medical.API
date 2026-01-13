using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Medical.Infrastructure.Tools
{
    public class LatLng
    {
        public LatLng(double x, double y)
        {
            latitude = x;
            longitude = y;
        }

        public double latitude;
        public double longitude;
    }

    /// <summary>
    /// 配置文件操作类
    /// </summary>
    public class Config
    {
        private readonly static Random rd = new();

        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);
            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;
            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                                                    Math.Cos(radLat1) * Math.Cos(radLat2) *
                                                    Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimestampSeconds()
        {
            // 计算当前时间与 Unix 起始时间的差值（秒）
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        /// <summary>
        /// 判断两个经纬度的距离
        /// </summary>
        /// <param name="j1">第一个经度</param>
        /// <param name="w1">第一个纬度</param>
        /// <param name="j2">第二个经度</param>
        /// <param name="w2">第二个纬度</param>
        /// <returns></returns>
        public static double GetGreatCircleDistance(double j1, double w1, double j2, double w2)
        {
            LatLng start = new(j1, w1);
            LatLng end = new(j2, w2);

            double lat1 = (Math.PI / 180) * start.latitude;
            double lat2 = (Math.PI / 180) * end.latitude;

            double lon1 = (Math.PI / 180) * start.longitude;
            double lon2 = (Math.PI / 180) * end.longitude;

            double r = 6371000; //地球半径(米)

            double dd = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) +
                                  Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * r;
            return dd;
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值 包含</param>
        /// <param name="max">最大值 不包含</param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            return rd.Next(min, max);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        /// <summary>
        /// 获取请求IP
        /// </summary>
        public static string GetIp()
        {
            //return "127.0.0.1";//正式环境请注释
            IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
            return _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(); //测试环境请注释
        }

        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static string GetBrowserInfo(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent)) return "未知浏览器";
            // 简单判断常见浏览器
            if (userAgent.Contains("MSIE") || userAgent.Contains("Trident")) return "Internet Explorer";
            if (userAgent.Contains("Edge")) return "Microsoft Edge";
            if (userAgent.Contains("Chrome")) return "Google Chrome";
            if (userAgent.Contains("Firefox")) return "Mozilla Firefox";
            if (userAgent.Contains("Safari")) return "Apple Safari";
            if (userAgent.Contains("Opera")) return "Opera";

            return "其他浏览器";
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static string GetDeviceInfo(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent)) return "未知设备";

            // 判断移动设备
            if (userAgent.Contains("Mobile") || userAgent.Contains("Android") || userAgent.Contains("iPhone"))
                return "0";

            // 判断平板设备
            if (userAgent.Contains("iPad") || userAgent.Contains("Tablet")) return "1";

            // 判断桌面设备
            if (userAgent.Contains("Windows NT") || userAgent.Contains("Macintosh")) return "2";

            return "3";
        }
        /// <summary>
        /// 获取操作系统信息
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static string GetOsInfo(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent)) return "未知操作系统";

            // 判断Windows系统
            if (userAgent.Contains("Windows NT 10.0")) return "Windows 10";
            if (userAgent.Contains("Windows NT 6.3")) return "Windows 8.1";
            if (userAgent.Contains("Windows NT 6.2")) return "Windows 8";
            if (userAgent.Contains("Windows NT 6.1")) return "Windows 7";
            if (userAgent.Contains("Windows NT 6.0")) return "Windows Vista";
            if (userAgent.Contains("Windows NT 5.1")) return "Windows XP";
            if (userAgent.Contains("Windows NT 5.0")) return "Windows 2000";

            // 判断Mac系统
            if (userAgent.Contains("Macintosh")) return "Mac OS";

            // 判断Linux系统
            if (userAgent.Contains("Linux")) return "Linux";

            // 判断Android系统
            if (userAgent.Contains("Android")) return "Android";

            // 判断iOS系统
            if (userAgent.Contains("iPhone") || userAgent.Contains("iPad")) return "iOS";

            return "其他操作系统";
        }
        /// <summary>
        /// 获取地区信息
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static async Task<string> GetRegionInfo(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress) || ipAddress == "::1" || ipAddress == "127.0.0.1")
                return "本地";

            try
            {
                using var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(3);
        
                // 使用更可靠的API，这里以ip-api.com为例
                var response = await httpClient.GetAsync($"http://ip-api.com/json/{ipAddress}?lang=zh-CN");
        
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //var ipInfo = JsonSerializer.Deserialize<Api_Ip_Result>(content);
            
                    //if (ipInfo != null && ipInfo.status == "success")
                    //{
                    //    return $"{ipInfo.country} {ipInfo.regionName} {ipInfo.city}";
                    //}
                }
            }
            catch (Exception ex)
            {
                // 可以记录更详细的日志
                Console.WriteLine($"IP查询失败: {ex.Message}");
        
                // 备用查询方案
                try 
                {
                    // 备用
                    return await GetRegionInfoBackup(ipAddress);
                }
                catch
                {
                    return "未知地区";
                }
            }

            return "未知地区";
        }

        // 备用IP查询方法
        private static async Task<string> GetRegionInfoBackup(string ipAddress)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"https://ip.900cha.com/{ipAddress}.json");
        
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //var ipInfo = JsonSerializer.Deserialize<Api_Ip_Result>(content);
                    //return ipInfo?.regionName ?? "未知地区";
                }
            }
            catch
            {
                return "未知地区";
            }
    
            return "未知地区";
        }

        /// <summary>
        /// 有序的GUID
        /// </summary>
        /// <returns></returns>
        public static string GUID()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            DateTime now = DateTime.UtcNow;

            bytes[3] = (byte)(now.Year - 2021); // 假设2021年为起点
            bytes[2] = (byte)now.Month;
            bytes[1] = (byte)now.Day;
            bytes[0] = (byte)now.Hour;
            Array.Copy(BitConverter.GetBytes(now.Millisecond), 0, bytes, 4, 2);
            Array.Copy(BitConverter.GetBytes(now.Second), 0, bytes, 6, 2);
            Array.Copy(Guid.NewGuid().ToByteArray(), 0, bytes, 8, 8);

            return new Guid(bytes).ToString().Replace("-", "");
        }

        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns></returns>
        public static string GUID2()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
    }
}