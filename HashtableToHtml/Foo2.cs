using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashtableToHtml
{
    static class Foo2
    {
        private static Hashtable ConvertToHashtable<T>(List<T> items, List<string> colNames)
        where T : class
        {
            var hashTable = new Hashtable();
            if (items != null && items.Any())
            {
                int index = 1;
                CreateChildHashTable(hashTable, items, colNames, ref index);
            }
            return hashTable;
        }

        private static void CreateChildHashTable<T>(Hashtable ht,
            List<T> items,
            List<string> colNames,
            ref int index)
        where T : class
        {
            var colName = colNames[index - 1];
            var propertyInfo = typeof(T).GetProperty(colName);
            if (propertyInfo == null || !propertyInfo.CanRead) return;
            var values = SelectGroupValues(items, propertyInfo).ToList();
            foreach (string str in values)
            {
                var childItems = SelectItem(items, propertyInfo, str).ToList();
                if (index < colNames.Count)
                {
                    var childHashTable = new Hashtable();
                    ht.Add(str, childHashTable);
                    index++;
                    CreateChildHashTable(childHashTable, childItems, colNames, ref index);
                    index--;
                }
                else
                {
                    ht.Add(str, childItems);
                }
            }
        }

        private static IEnumerable<string> SelectGroupValues<T>(IEnumerable<T> items,
            PropertyInfo propertyInfo)
        {
            return items.Select(o =>
            {
                var value = propertyInfo.GetValue(o, null);
                if (value != null && !DBNull.Value.Equals(value))
                {
                    return value.ToString();
                }
                return string.Empty;
            }).Distinct().ToList();
        }

        private static IEnumerable<T> SelectItem<T>(IEnumerable<T> items,
            PropertyInfo propertyInfo,
            object properyValue)
        {
            return items.Where(o =>
            {
                var value = propertyInfo.GetValue(o, null);
                if (value == null || DBNull.Value.Equals(value))
                {
                    return false;
                }
                return value.Equals(properyValue);
            });
        }

        public static Hashtable BuildData()
        {
            var cars = new List<CarInfo>
            {
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "濮阳市",
                    DistrictName = "市区",
                    CarNO = "豫JAA001"
                },
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "濮阳市",
                    DistrictName = "市区",
                    CarNO = "豫JAA002"
                },
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "濮阳市",
                    DistrictName = "华龙区",
                    CarNO = "豫JAA003"
                },
                
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "郑州市",
                    DistrictName = "中原区",
                    CarNO = "豫JAA004"
                },
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "郑州市",
                    DistrictName = "中原区",
                    CarNO = "豫JAA005"
                },
                
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "郑州市",
                    DistrictName = "二七区",
                    CarNO = "豫JAA006"
                },
                new CarInfo
                {
                    RegionName = "华中地区",
                    ProvinceName =  "河南省",
                    CityName = "郑州市",
                    DistrictName = "二七区",
                    CarNO = "豫JAA007"
                }
                
            };
            var colNames = new List<string>
            {
                "RegionName",
                "ProvinceName",
                "CityName",
                "DistrictName"
            };
            var ht = ConvertToHashtable(cars, colNames);
            return ht;
        }

        public static int GetHtml(object value, ref bool isNewRow, ref string html)
        {

            int childCount = 0;
            if (value is Hashtable)
            {
                var ht = value as Hashtable;
                foreach (string key in ht.Keys)
                {
                    if (isNewRow)
                    {
                        html += "<tr>";
                        isNewRow = false;
                    }
                    string strTemp = string.Empty;
                    var v = ht[key];
                    int tempCount = GetHtml(v, ref isNewRow, ref strTemp);
                    childCount += tempCount;
                    if (v is IEnumerable)
                    {
                        html += string.Format("<td rowspan='{0}'>{1}</td>{2}", tempCount, key, strTemp);
                    }
                    else
                    {
                        html += string.Format("<td rowspan='{0}'>{1}</td>{2}", childCount, key, strTemp);
                    }


                }

            }
            else if (value is IEnumerable)
            {
                var list = value as IEnumerable<CarInfo>;
                foreach (var item in list)
                {
                    if (isNewRow)
                    {
                        html += "<tr>";
                    }
                    var type = item.GetType();
                    var p = type.GetProperty("CarNO");
                    html += "<td>" + p.GetValue(item, null) + "</td>";

                    html += "</tr>";
                    childCount++;
                    if (!isNewRow)
                    {
                        isNewRow = true;
                    }
                }

            }
            return childCount;
        }
    }

    internal class CarInfo
    {
        public string RegionName { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string CarNO { get; set; }
    }
}
