using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = BuildTable();
            //var value = table.Compute("carnum-onlinenum", string.Empty);
            var value = table.Compute("1+2", "");
            Console.WriteLine(value);
            Console.ReadKey();
        }

        private static DataTable BuildTable()
        {
            var dt = new DataTable();
            //var dc = new DataColumn("CarNum", typeof(double));
            //dt.Columns.Add(dc);
            //dc = new DataColumn("OnlineNum", typeof(double));
            //dt.Columns.Add(dc);
            //var dr = dt.NewRow();
            //dr["CarNum"] = 500;
            //dr["OnlineNum"] = 300;
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["CarNum"] = 400;
            //dr["OnlineNum"] = 200;
            //dt.Rows.Add(dr);
            return dt;
        }
    }
}
