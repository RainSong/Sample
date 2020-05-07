using System;
using System.Collections.Generic;
using System.Text;

namespace Expression
{
    public class Computer1
    {
        public static double Compute(string expression)
        {
            var exp = expression.Replace(" ", "");
            var cons = new List<string>();
            var sb = new StringBuilder();
            foreach (char c in exp)
            {

                if (c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')')
                {
                    if (sb.Length > 0)
                    {
                        cons.Add(sb.ToString());
                        sb.Clear();
                    }
                    cons.Add(c.ToString());

                }
                else
                {
                    sb.Append(c);
                }
            }
            if (sb.Length > 0)
            {
                cons.Add(sb.ToString());
            }
            cons.ForEach(Console.WriteLine);
            return 0D;
        }

        private static bool Check(List<string> cons, ref List<double> nums, ref List<string> opers)
        {
            string str = cons[0];
            double val = 0;
            if (str != "+" && str != "-" && str != "(" && !double.TryParse(str, out val))
            {
                return false;
            }
            str = cons[cons.Count - 1];
            if (str != ")" && !double.TryParse(str, out val))
            {
                return false;
            }
            return true;
        }

        private static double Compute(List<string> cons)
        {
            return 0D;
        }

        private static double Operator(double num1, double num2, string oper)
        {
            switch (oper)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
                default:
                    return 0;
            }
        }
    }
}
