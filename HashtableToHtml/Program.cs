
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashtableToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ht2 = Foo2.BuildData();
            //bool isNewRow = true;

            //string html = string.Empty;
            //Foo2.GetHtml(ht2, ref isNewRow, ref html);

            Hashtable ht = new Hashtable();
            ht.Add("1百","  ");
            ht.Add("3a","  ");
            ht.Add("2a","  ");

            foreach (string a in ht.Keys)
            {
                Console.WriteLine(a);
                
            }
            Console.ReadKey();
            string temp = "";
            for (var i = 1; i <= 10; i++) {
                var id =Guid.NewGuid().ToString();
                if(i%3==0)
                {
                    temp = "区1";
                }
                else if(i%3==2)
                {
                    temp = "区1";
                }
                else
                {
                    temp = "区1";
                }
                var key = string.Format("{0}{1}",i,temp);
                ht.Add(key, id);
            }

        }
    }
}
