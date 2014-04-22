using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class Compute
    {
        public static IEnumerable<ComputInfo> GetComputInfos()
        {
            return new List<ComputInfo>
            {
                new ComputInfo
                {
                    FieldName = "MaxLoad",
                    ComputerType = "Max"
                },
                new ComputInfo
                {
                    FieldName = "MaxLoad",
                    ComputerType = "Sum"
                },
                new ComputInfo
                {
                    FieldName = "MaxLoad",
                    ComputerType = "Avg"
                },
                new ComputInfo
                {
                    FieldName = "MaxPeopleNum",
                    ComputerType = "Sum"
                },
                new ComputInfo
                {
                    FieldName = "MaxPeopleNum",
                    ComputerType = "Avg"
                },
                new ComputInfo
                {
                    FieldName = "MaxPeopleNum",
                    ComputerType = "Max"
                },
            };
        }
    }

    public class ComputInfo
    {
        public string FieldName { get; set; }
        public string ComputerType { get; set; }
    }
}
