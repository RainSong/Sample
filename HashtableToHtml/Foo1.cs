
using System.Collections;
using System.Text;

namespace HashtableToHtml
{
    public static class Foo1 
    {
        
        public static Hashtable getTable()
        {
            Hashtable ht = new Hashtable();
            Hashtable ht1 = new Hashtable();
            Hashtable ht2 = new Hashtable();
            Hashtable ht3 = new Hashtable();
            ht.Add("北京市", ht1);

            ht1.Add("北京市,BB区", "");
            ht1.Add("北京市,AA区", "");

            //ht2.Add("北京市,BB区,北京AA公司4", new List<string> { "北京市","BB区",",北京AA公司4","1", "2" });
            //ht2.Add("北京市,BB区,北京AA公司3", new List<string> { "北京市","BB区","北京AA公司3","1", "2" });
            //ht2.Add("北京市,BB区,北京AA公司2", new List<string> {"北京市","BB区","北京AA公司2 ","1", "2" });
            //ht2.Add("北京市,BB区,北京AA公司1", new List<string> { "北京市","BB区","北京AA公司1","1", "2" });

            //ht3.Add("北京市,AA区,北京AA公司1", new List<string> { "北京市", "AA区", "北京AA公司1", "1", "2" });
            return ht;

        }


        public static void Getdata(Hashtable ht)
        {
            int rowCount = 0;
            string sb = "";
            StringBuilder strb = GetItemDatas(ht, ref rowCount, ref sb);

        }
        public static StringBuilder GetItemDatas(Hashtable ht, ref int rowcount, ref string sbtd)
        {
            StringBuilder sTable = new StringBuilder();
            int i = 1;
            foreach (string key in ht.Keys)
            {
                if (ht[key] is Hashtable)
                {
                    Hashtable htTemp = (Hashtable)ht[key];
                    sTable.Append("<td> rowspan=" + rowcount + ">" + key + "</td>");
                    sTable.Append(GetItemDatas(htTemp, ref rowcount, ref sbtd));
                    

                }
                else
                {
                    sTable.Append("<td> rowspan=" + i + ">" + key + "</td>");
                    //rowcount = ht.Count;
                    i += rowcount;
                    rowcount = i;
                }

            }
            return sTable;
        }
    }
}