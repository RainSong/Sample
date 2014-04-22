using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CGReportSample
{

    #region UI端数据处理数据类型

    /// <summary>
    /// 报表数据
    /// </summary>
    public interface IReportData
    {
    }
    /// <summary>
    /// 报表数据统计
    /// </summary>
    public interface IReportTotal
    {
    }
    /// <summary>
    /// 保存在线、离线、统共车辆数、计算在线率
    /// </summary>
    public class OnlineNumComputer
    {
        public int CarNum { get; set; }
        public int OnlineNum { get; set; }
        public int OfflineNum { get; set; }
        public float OnlineRate
        {
            get
            {
                if (CarNum == 0) { return 0; }
                if (OfflineNum >= CarNum) { return 1; }
                return ((float)OnlineNum) / CarNum;
            }
        }
    }

    /// <summary>
    /// 区域
    /// </summary>
    public class Area : OnlineNumComputer, IReportData
    {
        /// <summary>
        /// 市
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { get; set; }
    }
    /// <summary>
    /// 企业
    /// </summary>
    public class Company : OnlineNumComputer, IReportData
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }
    }
    /// <summary>
    /// 合计信息
    /// </summary>
    public class ReportOnlineTotal : OnlineNumComputer, IReportTotal
    {
    }
    /// <summary>
    /// 统计结果
    /// </summary>
    public class ReportResult
    {
        public IReportTotal Total;
        public List<IReportData> Items;
    }
    #endregion

    #region 接口输出数据类型


    public class ReportOut
    {
        public DateTime Date { get; set; }
        public string CityID { get; set; }
        public string CityName { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
    public class ReportOnlineOut : ReportOut
    {
        public int CarNum { get; set; }
        public int OnlineNum { get; set; }
        public int OfflineNum { get; set; }
    }

    #endregion
}
