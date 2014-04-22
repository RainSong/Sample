using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CGReportSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outData = GetJsonData();
            Console.WriteLine(outData);
            #region get a IReortData object

            //var result = GetAreaReportData(outData);
            //var items = result.Items.ConvertAll(o => (Area)o);
            //var total = (ReportOnlineTotal)result.Total;

            //var companyResult = GetCompanyReportData(outData);
            //var companyItems = companyResult.Items.ConvertAll(o => (Company)o);
            //var companytotal = (ReportOnlineTotal)companyResult.Total;
            #endregion

            var result = GetAreaReportData(outData).ConvertAll(o => (Area)o);
            var value = result[0];
            string[] arr = { "CityName", "RegionName","CarNum","OnlineNum","OfflineNum" };
            var type = typeof(Area);
            var list = new List<object>();
            for (int i = 0; i < result.Count; i++)
            {
                var ps = type.GetProperties();
                foreach (var a in arr)
                {
                    var p = ps.SingleOrDefault(o => o.CanRead && o.Name == a);
                    if (p == null) continue;
                    var v = p.GetValue(result[i]);
                    list.Add(v);
                }
            }
            var companyResult = GetCompanyReportData(outData).ConvertAll(o => (Company)o);
        }
        /// <summary>
        /// 模拟产生接口数据
        /// </summary>
        /// <returns></returns>
        private static string GetJsonData()
        {
            List<ReportOnlineOut> listOutData = new List<ReportOnlineOut>();
            ReportOnlineOut Online = new ReportOnlineOut();
            Online.Date = DateTime.Now;
            Online.CityID = "1";
            Online.CityName = "杭州";
            Online.RegionID = "1"; ;
            Online.RegionName = "西湖区";
            Online.CompanyID = "1";
            Online.CompanyName = "星软集团";
            Online.CarNum = 200;
            Online.OnlineNum = 100;
            Online.OfflineNum = 100;
            listOutData.Add(Online);


            ReportOnlineOut online2 = new ReportOnlineOut();
            online2.Date = DateTime.Now;
            online2.CityID = "1";
            online2.CityName = "杭州";
            online2.RegionID = "2"; ;
            online2.RegionName = "拱墅区";
            online2.CompanyID = "2";
            online2.CompanyName = "拱墅区政府";
            online2.CarNum = 400;
            online2.OnlineNum = 200;
            online2.OfflineNum = 200;
            listOutData.Add(online2);

            return MyJSON.ToJSON(listOutData);
            //List<ReportOnlineOut> listTempData = MyJSON.ToObject<List<ReportOnlineOut>>(json);
        }
        /// <summary>
        /// 生成报表数据
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        private static List<IReportData> GetAreaReportData(string jsonData)
        {
            //var inListData = MyJSON.ToObject<List<Company>>(jsonData);

            //var areaQuery = (from d in inListData
            //                 group new { d.OnlineNum, d.OfflineNum, d.CarNum } by new { d.RegionName, d.CityName }
            //                     into g
            //                     from c in g
            //                     select new
            //                     {
            //                         g.Key.CityName,
            //                         g.Key.RegionName,
            //                         Numbs = g.FirstOrDefault()
            //                     }).ToList();

            var inlistData = MyJSON.ToObject<List<ReportOnlineOut>>(jsonData);//MyJSON.ToObject<List<dynamic>>(jsonData);
            var areas = new List<dynamic>();
            inlistData.ForEach(o =>
            {
                dynamic area = areas.SingleOrDefault(a => a.RegionID == o.RegionID);
                if (area == null)
                {
                    area = new ExpandoObject();
                    area.CityName = o.CityName;
                    area.RegionID = o.RegionID;
                    area.ReionName = o.RegionName;
                    area.CarNum = o.CarNum;
                    area.OnlineNum = o.OnlineNum;
                    area.OfflineNum = o.OfflineNum;
                }
                else
                {
                    area.CarNum += o.CarNum;
                    area.OnlineNum += o.OnlineNum;
                    area.OfflineNum += o.OfflineNum;
                }
                areas.Add(area);
            });
            #region retrun a IReportData list
            var items = new List<IReportData>();

            inlistData.ForEach(o => items.Add(new Area()
            {
                CityName = o.CityName,
                RegionName = o.RegionName,
                CarNum = o.CarNum,
                OnlineNum = o.OnlineNum,
                OfflineNum = o.OfflineNum

            }));

            items.Add(new Area
            {
                CarNum = areas.Sum(o => o.CarNum),
                OnlineNum = areas.Sum(o => o.OnlineNum),
                OfflineNum = areas.Sum(o => o.OfflineNum)
            });

            return items;
            #endregion

            #region return a ReportResult object

            //var rd = new ReportResult();
            //var total = new ReportOnlineTotal();
            //total.CarNum = items.Sum(o => o.CarNum);
            //total.OnlineNum = items.Sum(o => o.OnlineNum);
            //total.OfflineNum = items.Sum(o => o.OfflineNum);
            //rd.Items = new List<IReportData>();
            //items.ForEach(o => rd.Items.Add(o));
            //rd.Total = total;

            //return rd;

            #endregion

        }

        private static List<IReportData> GetCompanyReportData(string jsonData)
        {
            var inListData = MyJSON.ToObject<List<ReportOnlineOut>>(jsonData);

            #region return a IReportData list
            var items = new List<IReportData>();
            inListData.ForEach(o => items.Add(new Company
            {
                CityName = o.CityName,
                RegionName = o.RegionName,
                CompanyName = o.CompanyName,
                CarNum = o.CarNum,
                OnlineNum = o.OnlineNum,
                OfflineNum = o.OfflineNum
            }));
            items.Add(new Company
            {
                CarNum = inListData.Sum(o => o.CarNum),
                OnlineNum = inListData.Sum(o => o.OnlineNum),
                OfflineNum = inListData.Sum(o => o.OfflineNum)
            });
            return items;
            #endregion

            #region return a ReportResult object

            //var rd = new ReportResult();
            //var total = new ReportOnlineTotal();


            //total.CarNum = inListData.Sum(o => o.CarNum);
            //total.OnlineNum = inListData.Sum(o => o.OnlineNum);
            //total.OfflineNum = inListData.Sum(o => o.OfflineNum);

            //var items = new List<IReportData>();
            //inListData.ForEach(o => rd.Items.Add(o));
            //rd.Total = total;

            //return rd;

            #endregion
        }
    }
}
