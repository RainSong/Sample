using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using fastJSON;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = BuildData.GetCarses();
            var json = ToJsongUseFastJson(data);
            var obj = ToObjectUseFastJson<List<CarInfo>>(json);
            var dt = ConvertObjectToTable(obj);

            var dt2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
        }
        #region 使用fastJson将json转换为DataTable
        private static string ToJsongUseFastJson(object data)
        {
            var para = new JSONParameters();
            para.EnableAnonymousTypes = true;//不输出$type
            para.UseUTCDateTime = false;//不转换为UTC时间            
            return fastJSON.JSON.Instance.ToJSON(data, para);
        }

        private static T ToObjectUseFastJson<T>(string json)
        {
            return fastJSON.JSON.Instance.ToObject<T>(json);
        }

        private static DataTable ConvertObjectToTable<T>(IEnumerable<T> data)
        {
            var type = data.GetType();
            if (type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];
            }
            else if (type.HasElementType)
            {
                type = type.GetElementType();
            }
            var properties = type.GetProperties();
            var dt = CareatTableByObject(properties);
            FileTable(dt, data, properties);
            return dt;
        }

        private static DataTable CareatTableByObject(IEnumerable<PropertyInfo> properties)
        {
            var dt = new DataTable();
            foreach (var perproty in properties)
            {
                if (perproty.CanRead)
                {
                    var dataType = perproty.PropertyType;
                    DataColumn dc;
                    if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() ==
                        typeof(Nullable<>))//如果是Nullable<>类型将列设置为可空
                    {
                        var baseTypes = dataType.GetGenericArguments();
                        if (baseTypes.Any())
                        {
                            dataType = baseTypes[0];
                        }
                        else
                        {
                            continue;
                        }
                        dc = new DataColumn(perproty.Name, dataType)
                        {
                            AllowDBNull = true
                        };
                    }
                    else
                    {
                        dc = new DataColumn(perproty.Name, dataType);
                    }
                    dt.Columns.Add(dc);
                }
            }
            return dt;
        }

        private static void FileTable<T>(DataTable dt,
            IEnumerable<T> datas,
            IEnumerable<PropertyInfo> properties)
        {
            foreach (T data in datas)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    var inProperty = properties.SingleOrDefault(o => o.CanRead &&
                        o.Name == col.ColumnName);
                    if (inProperty == null) continue;
                    object value = inProperty.GetValue(data, null);
                    if (value == null)
                    {
                        if (col.AllowDBNull)
                        {
                            dr[col.ColumnName] = DBNull.Value;
                            continue;
                        }
                        var dataType = inProperty.PropertyType;
                        //如果是Nullable<>类型将列设置为默认值
                        if (dataType.IsGenericType &&
                            dataType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            var baseTypes = dataType.GetGenericArguments();
                            if (baseTypes.Any())
                            {
                                dataType = baseTypes[0];
                            }
                            else
                            {
                                continue;
                            }
                        }
                        value = Activator.CreateInstance(dataType);
                    }
                    dr[col.ColumnName] = value;
                }
                dt.Rows.Add(dr);
            }
        }
        #endregion


    }
}
