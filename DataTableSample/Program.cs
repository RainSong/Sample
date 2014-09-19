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

            value = Comput();

            Console.ReadKey();
        }

        private static DataTable BuildTable()
        {
            var dt = new DataTable();
            var dc = new DataColumn("CarNum", typeof(double));
            dt.Columns.Add(dc);
            dc = new DataColumn("OnlineNum", typeof(double));
            dt.Columns.Add(dc);
            var dr = dt.NewRow();
            dr["CarNum"] = 500;
            dr["OnlineNum"] = 300;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["CarNum"] = 400;
            dr["OnlineNum"] = 200;
            dt.Rows.Add(dr);
            return dt;
        }

        private static object Comput()
        {
            var table = new DataTable();

            var colId = new DataColumn("id", typeof(System.String));
            table.Columns.Add(colId);

            var colPrice = new DataColumn("price", typeof(System.Decimal));
            table.Columns.Add(colPrice);

            var colQuantity = new DataColumn("quantity", typeof(System.Int32));
            table.Columns.Add(colQuantity);

            var tr = table.NewRow();

            tr["id"] = "n001";
            tr["price"] = 1.5M;
            tr["quantity"] = 2;
            table.Rows.Add(tr);
            Object value = null;
            try
            {
                value = table.Compute("Max(price)", "id='n001'");
            }
            catch (Exception ex)
            {

            }
            return value;
        }
    }
}
