using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilterWidthAttribute
{
    public static class Permission
    {
        public static string[] permission { private set; get; }
        static Permission()
        {
            permission = new string[]
            {
                "Default.aspx"
            };
        }

    }
}