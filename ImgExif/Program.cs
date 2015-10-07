using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ImgExif
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //string path = @"D:\imgs\00b9c60b701cd09447ccb4fe56a6c787\24a8209b3d133e9ebb37205da484f881.jpg";
            //int width = 0;
            //int height = 0;
            //int status = GetSizeFromExif(path, out width, out height);
            //if (status == 0)
            //{
            //    Console.WriteLine(string.Format("width:{0},heigth:{1}", width, height));
            //}
            //else
            //{
            //    Console.WriteLine("读取失败");
            //}
            //status = GetSize(path, out width, out height);
            //if (status == 0)
            //{
            //    Console.WriteLine(string.Format("width:{0},heigth:{1}", width, height));
            //}
            //else
            //{
            //    Console.WriteLine("读取失败");
            //}
            //Console.ReadKey();
            #endregion
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            bool hasData = true;
            int total = 0;
            int needUpCount = GetNeedUpCount(connectionString);
            while (hasData)
            {
                DataTable dt = GetData(connectionString);
                hasData = dt != null && dt.Rows.Count > 0;
                if (hasData)
                {
                    string sql = BuildSql(dt);
                    if (sql.Length > 0)
                    {
                        int rowNum = DBHelper.Execute(connectionString, sql, null);
                        total += rowNum;
                        Console.WriteLine("更新成功{0}条，共更新成功{1}条，共{2}条数据要更新",rowNum,total,needUpCount);
                    }
                }
            }
        }
        static int GetNeedUpCount(string connectionString)
        {
            string sql = "select count(1) from file_info where [exists] = 1 and (isnull(width,0)=0  or isnull(height,0)=0)";
            object objCount = DBHelper.ExecuteScalar(connectionString, sql, null);
            if (IsNull(objCount)) return 0;
            int count = 0;
            int.TryParse(objCount.ToString(), out count);
            return count;
        }
        static string BuildSql(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string sql = BuildSql(dr);
                sb.AppendLine(sql);
            }
            return sb.ToString();
        }
        static string BuildSql(DataRow dr)
        {
            object objId = dr["id"];
            object objPath = dr["path"];
            if (IsNull(objId) || IsNull(objPath)) return string.Empty;

            int id = Convert.ToInt32(objId);
            string path = GetPath(objPath);

            int status = 0;
            int width = 0;
            int height = 0;

            status = GetSize(path, out width, out height);

            return BuildSql(id, status, width, height);
        }
        static string BuildSql(int id, int status, int width, int height)
        {
            if (status == 1 || status == 3)
            {
                return string.Format("update file_info set edit_time = getdate() where id = {0};", id);
            }
            else if (status == 2)
            {
                return string.Format("update file_info set [exists] = 0 where id = {0};", id);
            }
            else
            {
                return string.Format("update file_info set [exists] = 1, width = {0},height = {1} where id = {2};", width, height, id);
            }
        }
        static string GetPath(object path)
        {
            return string.Format(@"D:\workspace\git\Photo\Photo.Web\imgs\{0}", path);
        }

        static bool IsNull(object value)
        {
            return value == null || System.DBNull.Value.Equals(value);
        }

        static DataTable GetData(string connectionString)
        {
            string sql = "select top 20  id,path from file_info where [exists] = 1 and (isnull(width,0)=0  or isnull(height,0)=0) order by edit_time";
            try
            {
                return DBHelper.GetTable(connectionString, sql, null);
            }
            catch (Exception ex)
            {
                throw new Exception("读取数据失败", ex);
            }
        }

        /// <summary>
        /// 获取图片尺寸
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns>0 获取成功，1 路径为空，2 文件不存在，3 获取尺寸失败</returns>
        static int GetSize(string path, out int width, out int height)
        {
            width = 0;
            height = 0;
            if (string.IsNullOrEmpty(path)) return 1;
            if (!System.IO.File.Exists(path)) return 2;
            try
            {
                using (System.Drawing.Image img = System.Drawing.Image.FromFile(path))
                {
                    width = img.Width;
                    height = img.Height;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 3;
            }
        }

        /// <summary>
        /// 获取图片尺寸
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns>0 获取成功，1 路径为空，2 文件不存在，3 获取尺寸失败</returns>
        static int GetSizeFromExif(string path, out int width, out int height)
        {
            width = 0;
            height = 0;
            if (string.IsNullOrEmpty(path)) return 1;
            if (!System.IO.File.Exists(path)) return 2;
            try
            {
                var metaData = GetExif(path);
                int tempW = 0;
                int tempH = 0;
                if (int.TryParse(metaData.ImageWidth.DisplayValue, out tempW)
                    && int.TryParse(metaData.ImageHeight.DisplayValue, out tempH))
                {
                    width = tempW;
                    height = tempH;
                    return 0;
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception ex)
            {
                return 3;
            }
        }
        static Metadata GetExif(string path)
        {
            var pe = new PicturExif();
            var metaData = pe.GetEXIFMetaData(path);
            return metaData;
        }
    }
    #region
    /// <summary> 
    /// 转换数据结构 
    /// </summary> 
    struct MetadataDetail
    {
        public string Hex;//十六进制字符串 
        public string RawValueAsString;//原始值串 
        public string DisplayValue;//显示值串 
    }

    struct Metadata
    {
        public MetadataDetail EquipmentMake;
        public MetadataDetail CameraModel;
        /// <summary>
        /// 曝光时间
        /// </summary>
        public MetadataDetail ExposureTime;
        public MetadataDetail Fstop;
        public MetadataDetail DatePictureTaken;
        /// <summary>
        /// 快门速度
        /// </summary>
        public MetadataDetail ShutterSpeed;
        /// <summary>
        /// 曝光模式
        /// </summary>
        public MetadataDetail MeteringMode;
        /// <summary>
        /// 闪光灯
        /// </summary>
        public MetadataDetail Flash;
        public MetadataDetail XResolution;
        public MetadataDetail YResolution;
        /// <summary>
        /// 照片宽度
        /// </summary>
        public MetadataDetail ImageWidth;
        /// <summary>
        /// 照片高度 
        /// </summary>
        public MetadataDetail ImageHeight;
        /// <summary>
        /// f值，光圈数
        /// </summary>
        public MetadataDetail FNumber;
        /// <summary>
        /// 曝光程序
        /// </summary>
        public MetadataDetail ExposureProg;
        public MetadataDetail SpectralSense;
        /// <summary>
        /// ISO感光度
        /// </summary>
        public MetadataDetail ISOSpeed;
        public MetadataDetail OECF;
        /// <summary>
        /// EXIF版本
        /// </summary>
        public MetadataDetail Ver;
        /// <summary>
        /// 色彩设置 
        /// </summary>
        public MetadataDetail CompConfig;
        /// <summary>
        /// 压缩比率
        /// </summary>
        public MetadataDetail CompBPP;
        /// <summary>
        /// 光圈值 
        /// </summary>
        public MetadataDetail Aperture;
        /// <summary>
        /// 亮度值Ev
        /// </summary>
        public MetadataDetail Brightness;
        /// <summary>
        /// 曝光补偿 
        /// </summary>
        public MetadataDetail ExposureBias;
        /// <summary>
        /// 最大光圈值 
        /// </summary>
        public MetadataDetail MaxAperture;
        /// <summary>
        /// 主体距离
        /// </summary>
        public MetadataDetail SubjectDist;
        /// <summary>
        /// 白平衡
        /// </summary>
        public MetadataDetail LightSource;
        /// <summary>
        /// 焦距
        /// </summary>
        public MetadataDetail FocalLength;
        /// <summary>
        /// FlashPix版本
        /// </summary>
        public MetadataDetail FPXVer;
        /// <summary>
        /// 色彩空间
        /// </summary>
        public MetadataDetail ColorSpace;
        public MetadataDetail Interop;
        public MetadataDetail FlashEnergy;
        public MetadataDetail SpatialFR;
        public MetadataDetail FocalXRes;
        public MetadataDetail FocalYRes;
        public MetadataDetail FocalResUnit;
        /// <summary>
        /// 曝光指数
        /// </summary>
        public MetadataDetail ExposureIndex;
        /// <summary>
        /// 感应方式 
        /// </summary>
        public MetadataDetail SensingMethod;
        public MetadataDetail SceneType;
        public MetadataDetail CfaPattern;
    }

    class PicturExif
    {

        public string LookupEXIFValue(string Description, string Value)
        {
            string DescriptionValue = null;

            switch (Description)
            {
                case "MeteringMode":

                    #region MeteringMode
                    {
                        switch (Value)
                        {
                            case "0":
                                DescriptionValue = "Unknown"; break;
                            case "1":
                                DescriptionValue = "Average"; break;
                            case "2":
                                DescriptionValue = "Center Weighted Average"; break;
                            case "3":
                                DescriptionValue = "Spot"; break;
                            case "4":
                                DescriptionValue = "Multi-spot"; break;
                            case "5":
                                DescriptionValue = "Multi-segment"; break;
                            case "6":
                                DescriptionValue = "Partial"; break;
                            case "255":
                                DescriptionValue = "Other"; break;
                        }
                    }
                    #endregion

                    break;
                case "ResolutionUnit":

                    #region ResolutionUnit
                    {
                        switch (Value)
                        {
                            case "1":
                                DescriptionValue = "No Units"; break;
                            case "2":
                                DescriptionValue = "Inch"; break;
                            case "3":
                                DescriptionValue = "Centimeter"; break;
                        }
                    }

                    #endregion

                    break;
                case "Flash":

                    #region Flash
                    {
                        switch (Value)
                        {
                            case "0":
                                DescriptionValue = "未使用"; break;
                            case "1":
                                DescriptionValue = "闪光"; break;
                            case "5":
                                DescriptionValue = "Flash fired but strobe return light not detected"; break;
                            case "7":
                                DescriptionValue = "Flash fired and strobe return light detected"; break;
                        }
                    }
                    #endregion

                    break;
                case "ExposureProg":

                    #region ExposureProg
                    {
                        switch (Value)
                        {
                            case "0":
                                DescriptionValue = "没有定义"; break;
                            case "1":
                                DescriptionValue = "手动控制"; break;
                            case "2":
                                DescriptionValue = "程序控制"; break;
                            case "3":
                                DescriptionValue = "光圈优先"; break;
                            case "4":
                                DescriptionValue = "快门优先"; break;
                            case "5":
                                DescriptionValue = "夜景模式"; break;
                            case "6":
                                DescriptionValue = "运动模式"; break;
                            case "7":
                                DescriptionValue = "肖像模式"; break;
                            case "8":
                                DescriptionValue = "风景模式"; break;
                            case "9":
                                DescriptionValue = "保留的"; break;
                        }
                    }

                    #endregion

                    break;
                case "CompConfig":

                    #region CompConfig
                    {
                        switch (Value)
                        {
                            case "513":
                                DescriptionValue = "YCbCr"; break;
                        }
                    }
                    #endregion

                    break;
                case "Aperture":

                    #region Aperture
                    DescriptionValue = Value;
                    #endregion

                    break;
                case "LightSource":

                    #region LightSource
                    {
                        switch (Value)
                        {
                            case "0":
                                DescriptionValue = "未知"; break;
                            case "1":
                                DescriptionValue = "日光"; break;
                            case "2":
                                DescriptionValue = "荧光灯"; break;
                            case "3":
                                DescriptionValue = "白炽灯"; break;
                            case "10":
                                DescriptionValue = "闪光灯"; break;
                            case "17":
                                DescriptionValue = "标准光A"; break;
                            case "18":
                                DescriptionValue = "标准光B"; break;
                            case "19":
                                DescriptionValue = "标准光C"; break;
                            case "20":
                                DescriptionValue = "标准光D55"; break;
                            case "21":
                                DescriptionValue = "标准光D65"; break;
                            case "22":
                                DescriptionValue = "标准光D75"; break;
                            case "255":
                                DescriptionValue = "其它"; break;
                        }
                    }


                    #endregion
                    break;

            }
            return DescriptionValue;
        }

        #region 取得图片的EXIF信息
        public Metadata GetEXIFMetaData(string imgPath)
        {
            // 创建一个图片的实例 
            System.Drawing.Image MyImage = System.Drawing.Image.FromFile(imgPath);
            // 创建一个整型数组来存储图像中属性数组的ID 
            int[] MyPropertyIdList = MyImage.PropertyIdList;
            //创建一个封闭图像属性数组的实例 
            PropertyItem[] MyPropertyItemList = new PropertyItem[MyPropertyIdList.Length];
            //创建一个图像EXIT信息的实例结构对象，并且赋初值 

            #region 创建一个图像EXIT信息的实例结构对象，并且赋初值
            Metadata MyMetadata = new Metadata();
            MyMetadata.EquipmentMake.Hex = "10f";
            MyMetadata.CameraModel.Hex = "110";
            MyMetadata.DatePictureTaken.Hex = "9003";
            MyMetadata.ExposureTime.Hex = "829a";
            MyMetadata.Fstop.Hex = "829d";
            MyMetadata.ShutterSpeed.Hex = "9201";
            MyMetadata.MeteringMode.Hex = "9207";
            MyMetadata.Flash.Hex = "9209";
            MyMetadata.FNumber.Hex = "829d";
            MyMetadata.ExposureProg.Hex = "";
            MyMetadata.SpectralSense.Hex = "8824";
            MyMetadata.ISOSpeed.Hex = "8827";
            MyMetadata.OECF.Hex = "8828";
            MyMetadata.Ver.Hex = "9000";
            MyMetadata.CompConfig.Hex = "9101";
            MyMetadata.CompBPP.Hex = "9102";
            MyMetadata.Aperture.Hex = "9202";
            MyMetadata.Brightness.Hex = "9203";
            MyMetadata.ExposureBias.Hex = "9204";
            MyMetadata.MaxAperture.Hex = "9205";
            MyMetadata.SubjectDist.Hex = "9206";
            MyMetadata.LightSource.Hex = "9208";
            MyMetadata.FocalLength.Hex = "920a";
            MyMetadata.FPXVer.Hex = "a000";
            MyMetadata.ColorSpace.Hex = "a001";
            MyMetadata.FocalXRes.Hex = "a20e";
            MyMetadata.FocalYRes.Hex = "a20f";
            MyMetadata.FocalResUnit.Hex = "a210";
            MyMetadata.ExposureIndex.Hex = "a215";
            MyMetadata.SensingMethod.Hex = "a217";
            MyMetadata.SceneType.Hex = "a301";
            MyMetadata.CfaPattern.Hex = "a302";
            #endregion

            // ASCII编码 
            System.Text.ASCIIEncoding Value = new System.Text.ASCIIEncoding();

            int index = 0;
            int MyPropertyIdListCount = MyPropertyIdList.Length;
            if (MyPropertyIdListCount != 0)
            {
                foreach (int MyPropertyId in MyPropertyIdList)
                {
                    string hexVal = "";
                    MyPropertyItemList[index] = MyImage.GetPropertyItem(MyPropertyId);

                    #region 初始化各属性值
                    string myPropertyIdString = MyImage.GetPropertyItem(MyPropertyId).Id.ToString("x");
                    switch (myPropertyIdString)
                    {
                        case "10f":
                            {
                                MyMetadata.EquipmentMake.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.EquipmentMake.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }

                        case "110":
                            {
                                MyMetadata.CameraModel.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.CameraModel.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;

                            }

                        case "9003":
                            {
                                MyMetadata.DatePictureTaken.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.DatePictureTaken.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }

                        case "9207":
                            {
                                MyMetadata.MeteringMode.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.MeteringMode.DisplayValue = LookupEXIFValue("MeteringMode", BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString());
                                break;
                            }

                        case "9209":
                            {
                                MyMetadata.Flash.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.Flash.DisplayValue = LookupEXIFValue("Flash", BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString());
                                break;
                            }

                        case "829a":
                            {
                                MyMetadata.ExposureTime.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                string StringValue = "";
                                for (int Offset = 0; Offset < MyImage.GetPropertyItem(MyPropertyId).Len; Offset = Offset + 4)
                                {
                                    StringValue += BitConverter.ToInt32(MyImage.GetPropertyItem(MyPropertyId).Value, Offset).ToString() + "/";
                                }
                                MyMetadata.ExposureTime.DisplayValue = StringValue.Substring(0, StringValue.Length - 1);
                                break;
                            }
                        case "829d":
                            {
                                MyMetadata.Fstop.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                int int1;
                                int int2;
                                int1 = BitConverter.ToInt32(MyImage.GetPropertyItem(MyPropertyId).Value, 0);
                                int2 = BitConverter.ToInt32(MyImage.GetPropertyItem(MyPropertyId).Value, 4);
                                MyMetadata.Fstop.DisplayValue = "F/" + (int1 / int2);

                                MyMetadata.FNumber.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.FNumber.DisplayValue = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();

                                break;
                            }
                        case "9201":
                            {
                                MyMetadata.ShutterSpeed.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                string StringValue = BitConverter.ToInt32(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                MyMetadata.ShutterSpeed.DisplayValue = "1/" + StringValue;
                                break;
                            }

                        case "8822":
                            {
                                MyMetadata.ExposureProg.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.ExposureProg.DisplayValue = LookupEXIFValue("ExposureProg", BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString());
                                break;
                            }

                        case "8824":
                            {
                                MyMetadata.SpectralSense.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.SpectralSense.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }
                        case "8827":
                            {
                                hexVal = "";
                                MyMetadata.ISOSpeed.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                hexVal = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value).Substring(0, 2);
                                MyMetadata.ISOSpeed.DisplayValue = Convert.ToInt32(hexVal, 16).ToString();//Value.GetString(MyPropertyItemList[index].Value); 
                                break;
                            }

                        case "8828":
                            {
                                MyMetadata.OECF.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.OECF.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }

                        case "9000":
                            {
                                MyMetadata.Ver.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.Ver.DisplayValue = Value.GetString(MyPropertyItemList[index].Value).Substring(1, 1) + "." + Value.GetString(MyPropertyItemList[index].Value).Substring(2, 2);
                                break;
                            }

                        case "9101":
                            {
                                MyMetadata.CompConfig.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.CompConfig.DisplayValue = LookupEXIFValue("CompConfig", BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString());
                                break;
                            }

                        case "9102":
                            {
                                MyMetadata.CompBPP.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.CompBPP.DisplayValue = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                break;
                            }

                        case "9202":
                            {
                                hexVal = "";
                                MyMetadata.Aperture.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                hexVal = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value).Substring(0, 2);
                                hexVal = Convert.ToInt32(hexVal, 16).ToString();
                                hexVal = hexVal + "00";
                                MyMetadata.Aperture.DisplayValue = hexVal.Substring(0, 1) + "." + hexVal.Substring(1, 2);
                                break;
                            }

                        case "9203":
                            {
                                hexVal = "";
                                MyMetadata.Brightness.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                hexVal = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value).Substring(0, 2);
                                hexVal = Convert.ToInt32(hexVal, 16).ToString();
                                hexVal = hexVal + "00";
                                MyMetadata.Brightness.DisplayValue = hexVal.Substring(0, 1) + "." + hexVal.Substring(1, 2);
                                break;
                            }

                        case "9204":
                            {
                                MyMetadata.ExposureBias.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.ExposureBias.DisplayValue = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                break;
                            }

                        case "9205":
                            {
                                hexVal = "";
                                MyMetadata.MaxAperture.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                hexVal = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value).Substring(0, 2);
                                hexVal = Convert.ToInt32(hexVal, 16).ToString();
                                hexVal = hexVal + "00";
                                MyMetadata.MaxAperture.DisplayValue = hexVal.Substring(0, 1) + "." + hexVal.Substring(1, 2);
                                break;
                            }

                        case "9206":
                            {
                                MyMetadata.SubjectDist.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.SubjectDist.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }

                        case "9208":
                            {
                                MyMetadata.LightSource.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.LightSource.DisplayValue = LookupEXIFValue("LightSource", BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString());
                                break;
                            }

                        case "920a":
                            {
                                hexVal = "";
                                MyMetadata.FocalLength.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                hexVal = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value).Substring(0, 2);
                                hexVal = Convert.ToInt32(hexVal, 16).ToString();
                                hexVal = hexVal + "00";
                                MyMetadata.FocalLength.DisplayValue = hexVal.Substring(0, 1) + "." + hexVal.Substring(1, 2);
                                break;
                            }

                        case "a000":
                            {
                                MyMetadata.FPXVer.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.FPXVer.DisplayValue = Value.GetString(MyPropertyItemList[index].Value).Substring(1, 1) + "." + Value.GetString(MyPropertyItemList[index].Value).Substring(2, 2);
                                break;
                            }

                        case "a001":
                            {
                                MyMetadata.ColorSpace.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                if (BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString() == "1")
                                    MyMetadata.ColorSpace.DisplayValue = "RGB";
                                if (BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString() == "65535")
                                    MyMetadata.ColorSpace.DisplayValue = "Uncalibrated";
                                break;
                            }

                        case "a20e":
                            {
                                MyMetadata.FocalXRes.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.FocalXRes.DisplayValue = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                break;
                            }

                        case "a20f":
                            {
                                MyMetadata.FocalYRes.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.FocalYRes.DisplayValue = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                break;
                            }

                        case "a210":
                            {
                                string aa;
                                MyMetadata.FocalResUnit.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                aa = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString(); ;
                                if (aa == "1") MyMetadata.FocalResUnit.DisplayValue = "没有单位";
                                if (aa == "2") MyMetadata.FocalResUnit.DisplayValue = "英尺";
                                if (aa == "3") MyMetadata.FocalResUnit.DisplayValue = "厘米";
                                break;
                            }

                        case "a215":
                            {
                                MyMetadata.ExposureIndex.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.ExposureIndex.DisplayValue = Value.GetString(MyPropertyItemList[index].Value);
                                break;
                            }

                        case "a217":
                            {
                                string aa;
                                aa = BitConverter.ToInt16(MyImage.GetPropertyItem(MyPropertyId).Value, 0).ToString();
                                MyMetadata.SensingMethod.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                if (aa == "2") MyMetadata.SensingMethod.DisplayValue = "1 chip color area sensor";
                                break;
                            }

                        case "a301":
                            {
                                MyMetadata.SceneType.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.SceneType.DisplayValue = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                break;
                            }

                        case "a302":
                            {
                                MyMetadata.CfaPattern.RawValueAsString = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                MyMetadata.CfaPattern.DisplayValue = BitConverter.ToString(MyImage.GetPropertyItem(MyPropertyId).Value);
                                break;
                            }



                    }
                    #endregion

                    index++;
                }
            }

            MyMetadata.XResolution.DisplayValue = MyImage.HorizontalResolution.ToString();
            MyMetadata.YResolution.DisplayValue = MyImage.VerticalResolution.ToString();
            MyMetadata.ImageHeight.DisplayValue = MyImage.Height.ToString();
            MyMetadata.ImageWidth.DisplayValue = MyImage.Width.ToString();
            MyImage.Dispose();
            return MyMetadata;
        }
        #endregion
    }
    #endregion
}
