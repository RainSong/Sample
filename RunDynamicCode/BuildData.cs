using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunDynamicCode
{
    public class BuildData
    {
        public static CustomNameSpace BuildNewType()
        {
            var ctype = new CustomTypeInfo("ReportBase")
            {
                FieldInfos = new List<CustomFieldInfo>
                {
                    new CustomFieldInfo
                    {
                        Name = "Time",
                        DataType = "Nullable",
                        Description = "时间"
                    },
                    new CustomFieldInfo
                    {
                        Name = "RegionName",
                        DataType = "string",
                        Description = "地区名"
                    },
                    new CustomFieldInfo
                    {
                        Name = "CityName",
                        DataType = "string",
                        Description = "地市名"
                    },
                    new CustomFieldInfo
                    {
                        Name = "DistrictName",
                        DataType = "string",
                        Description = "县区名"
                    },
                    new CustomFieldInfo
                    {
                        Name = "OperatorName",
                        DataType = "string",
                        Description = "运营商名称"
                    },
                    new CustomFieldInfo
                    {
                        Name = "CompanyName",
                        DataType = "string",
                        Description = "企业名称"
                    },
                    new CustomFieldInfo
                    {
                        Name = "CarNum",
                        DataType = "int",
                        Description = "车辆总数"
                    },
                    new CustomFieldInfo
                    {
                        Name = "OnlineNum",
                        DataType = "int",
                        Description = "在线车辆总数"
                    },
                    new CustomFieldInfo
                    {
                        Name = "OfflineNum",
                        DataType = "int",
                        Description = "离线车辆总数"
                    },
                    new CustomFieldInfo
                    {
                        Name = "OnlineRate",
                        DataType = "double",
                        Description = "上线率"
                    }
                }
            };
            return new CustomNameSpace
            {
                UsingNameSpaces = new List<string>
                {
                    "System"
                },
                CustomTypes = new List<CustomTypeInfo>
                {
                    ctype
                },
                Name = "DynamicNamespace"
            };
        }

        public static DataTable GetServiceData()
        {
            var dt=new DataTable();
            var datas = new List<dynamic>();

            #region

            dynamic data = new ExpandoObject();
            data.Time = DateTime.Now;
            data.RegionID = 1;
            data.RegionName = "华中地区";
            data.ProvinceID = 1;
            data.ProvinceName = "河南省";
            data.CityID = 1;
            data.CityName = "郑州市";
            data.DistrictID = 1;
            data.DistrictName = "二七区";
            data.CompanyID = 1;
            data.CompanyName = "公司1";
            data.OperatorID = 1;
            data.OperatorName = "运营商1";
            #endregion

            return dt;
        }

        
    }
}
