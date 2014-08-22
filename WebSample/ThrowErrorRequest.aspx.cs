using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSample
{
    public partial class ThrowErrorRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = 0;
            int.TryParse(Request["action"], out action);
            if (action == 1)
            {
                Response.Clear();
                try
                {
                    Foo1();
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    Response.Write(ex.ToString());
                }
                finally
                {
                    Response.End();
                }
            }
        }

        private void Foo1()
        {
            throw new Exception("new error in Foo1");
        }
    }
}