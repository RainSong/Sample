using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterWidthAttribute
{
    public class CustomAuthorizeAttribute : Attribute
    {
        public CustomAuthorizeAttribute()
        {
            var url = HttpContext.Current.Request.Url.PathAndQuery;
            if (url.StartsWith("/"))
            {
                url = url.Remove(0, 1);
            }
            if (!Permission.permission.Contains(url))
            {
                HttpContext.Current.Response.Redirect("NoPermission.html");
            }
        }
    }
}