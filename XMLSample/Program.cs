using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cols = ReportConfigReader.GetReportColumns("1");
        }
    }
}
