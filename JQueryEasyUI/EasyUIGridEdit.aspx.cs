using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Dynamic;

namespace JQueryEasyUI
{
    public partial class EasyUIGridEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request["action"];
            if (action != null && action.ToUpper().Equals("GETDATA"))
            {
                Response.Clear();
                try
                {
                    var json = GetData();
                    Response.Write(json);
                    Common.LogManager.LogInfo("读取学生数据！");
                }
                catch (Exception ex)
                {
                    Common.LogManager.LogError("获取数据失败！", ex);
                    Response.StatusCode = 500;
                }
                finally
                {
                    Response.End();
                }
            }
        }

        protected string GetData()
        {
            #region
            dynamic stu1 = new ExpandoObject();
            stu1.sid = "STU2014082201";
            stu1.name = "STU1";
            stu1.sex = "0";
            stu1.grade = "初一";
            stu1.className = "一(1)班";
            stu1.brithday = new DateTime(2000, 1, 1);
            stu1.remark = "";

            dynamic stu2 = new ExpandoObject();
            stu2.sid = "STU2014082202";
            stu2.name = "STU2";
            stu2.sex = "1";
            stu2.grade = "初一";
            stu2.className = "一(1)班";
            stu2.brithday = new DateTime(1999, 6, 7);
            stu2.remark = "";

            dynamic stu3 = new ExpandoObject();
            stu3.sid = "STU2014082203";
            stu3.name = "STU3";
            stu3.sex = "0";
            stu3.grade = "初一";
            stu3.className = "一(1)班";
            stu3.brithday = new DateTime(2001, 2, 10);
            stu3.remark = "";

            dynamic stu4 = new ExpandoObject();
            stu4.sid = "STU2014082204";
            stu4.name = "STU4";
            stu4.sex = "1";
            stu4.grade = "初一";
            stu4.className = "一(2)班";
            stu4.brithday = new DateTime(1998, 7, 7);
            stu4.remark = "";

            dynamic stu5 = new ExpandoObject();
            stu5.sid = "STU2014082206";
            stu5.name = "STU6";
            stu5.sex = "1";
            stu5.grade = "初二";
            stu5.className = "二(1)班";
            stu5.brithday = new DateTime(2000, 5, 1);
            stu5.remark = "";
            #endregion

            dynamic stu6 = new ExpandoObject();
            stu6.sid = "STU2014082206";
            stu6.name = "STU6";
            stu6.sex = "0";
            stu6.grade = "初二";
            stu6.className = "二(1)班";
            stu6.brithday = new DateTime(2000, 6, 12);
            stu6.remark = "";

            dynamic stu7 = new ExpandoObject();
            stu7.sid = "STU2014082207";
            stu7.name = "STU7";
            stu7.sex = "1";
            stu7.grade = "初二";
            stu7.className = "二(1)班";
            stu7.brithday = new DateTime(1999, 7, 8);
            stu7.remark = "";

            dynamic stu8 = new ExpandoObject();
            stu8.sid = "STU2014082208";
            stu8.name = "STU8";
            stu8.sex = "0";
            stu8.grade = "初二";
            stu8.className = "二(2)班";
            stu8.brithday = new DateTime(2001, 10, 15);
            stu8.remark = "";

            dynamic stu9 = new ExpandoObject();
            stu9.sid = "STU2014082209";
            stu9.name = "STU9";
            stu9.sex = "0";
            stu9.grade = "初二";
            stu9.className = "二(2)班";
            stu9.brithday = new DateTime(2002, 8, 8);
            stu9.remark = "";

            dynamic stu10 = new ExpandoObject();
            stu10.sid = "STU2014082210";
            stu10.name = "STU10";
            stu10.sex = "0";
            stu10.grade = "初三";
            stu10.className = "三(1)班";
            stu10.brithday = new DateTime(2000, 12, 1);
            stu10.remark = "";

            dynamic stu11 = new ExpandoObject();
            stu11.sid = "STU2014082211";
            stu11.name = "STU11";
            stu11.sex = "0";
            stu11.grade = "初三";
            stu11.className = "三(1)班";
            stu11.brithday = new DateTime(1998, 7, 7);
            stu11.remark = "";

            dynamic stu12 = new ExpandoObject();
            stu12.sid = "STU2014082212";
            stu12.name = "STU12";
            stu12.sex = "1";
            stu12.grade = "初三";
            stu12.className = "三(1)班";
            stu12.brithday = new DateTime(1999, 7, 8);
            stu12.remark = "";

            dynamic stu13 = new ExpandoObject();
            stu13.sid = "STU2014082213";
            stu13.name = "STU13";
            stu13.sex = "0";
            stu13.grade = "初三";
            stu13.className = "三(1)班";
            stu13.brithday = new DateTime(1998, 7, 7);
            stu13.remark = "";

            dynamic stu14 = new ExpandoObject();
            stu14.sid = "STU2014082214";
            stu14.name = "STU114";
            stu14.sex = "1";
            stu14.grade = "初三";
            stu14.className = "三(2)班";
            stu14.brithday = new DateTime(2000, 3, 5);
            stu14.remark = "";

            dynamic stu15 = new ExpandoObject();
            stu15.sid = "STU2014082215";
            stu15.name = "STU15";
            stu15.sex = "1";
            stu1.grade = "初三";
            stu15.className = "三(2)班";
            stu15.brithday = new DateTime(1999, 12, 1);
            stu15.remark = "";



            dynamic reslut = new ExpandoObject();
            reslut.total = 100;
            reslut.rows = new[]
            {
                stu1,stu2,stu3,stu4,stu5,
                stu6,stu7,stu8,stu9,stu10,
                stu11,stu12,stu13,stu14,stu15
            };

            var timeConvert = new Newtonsoft.Json.Converters.IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy-MM-dd"
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(reslut, timeConvert);
        }
    }
}