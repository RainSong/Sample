using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class BuildData
    {
        public static IEnumerable<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company
                {
                    Name = "公司1",
                    ID = "01",
                    Cars = new List<CarInfo>
                    {
                        new CarInfo
                        {
                            ID = "0101",
                            Carbrand = "浙A0101",
                            MaxLoad = 50
                        },
                        new CarInfo
                        {
                            ID = "0102",
                            Carbrand = "浙A0102",
                            MaxLoad = 60
                        },
                        new CarInfo
                        {
                            ID = "0103",
                            Carbrand = "浙A0103",
                            MaxLoad = 70
                        }
                    }
                },
                new Company
                {
                    Name = "公司2",
                    ID = "02",
                    Cars = new List<CarInfo>
                    {
                        new CarInfo
                        {
                            ID = "0201",
                            Carbrand = "浙A0201",
                            MaxLoad = 50
                        },
                        new CarInfo
                        {
                            ID = "0202",
                            Carbrand = "浙A0202",
                            MaxLoad = 60
                        },
                        new CarInfo
                        {
                            ID = "0203",
                            Carbrand = "浙A0203",
                            MaxLoad = 70
                        }
                    }
                }
            };
        }

        public static IEnumerable<CarInfo> GetCarses()
        {
            return new List<CarInfo>
            {
                new CarInfo
                {
                    ID = "0101",
                    Carbrand = "浙A0101",
                    MaxLoad = 50,
                    MaxPeopleNum = 5,
                    Remark = "这是备注",
                    BuyDate = new DateTime(2010,1,1)
                },
                new CarInfo
                {
                    ID = "0102",
                    Carbrand = "浙A0102",
                    MaxLoad = 60,
                    MaxPeopleNum = 4,
                    Remark = "这是备注",
                    BuyDate = new DateTime(2012,1,1)
                },
                new CarInfo
                {
                    ID = "0103",
                    Carbrand = "浙A0103",
                    MaxLoad = 70,
                    BuyDate = new DateTime(2013,1,1)
                },
                new CarInfo
                {
                    ID = "0201",
                    Carbrand = "浙A0201",
                    MaxLoad = 50,
                    BuyDate = new DateTime(2014,1,1)
                },
                new CarInfo
                {
                    ID = "0202",
                    Carbrand = "浙A0202",
                    MaxLoad = 60,
                    BuyDate = new DateTime(2000,1,1)
                },
                new CarInfo
                {
                    ID = "0203",
                    Carbrand = "浙A0203",
                    MaxLoad = 70,
                    BuyDate = new DateTime(2010,1,1)
                }
            };
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public IEnumerable<CarInfo> Cars { get; set; }
    }

    public class CarInfo
    {
        public string ID { get; set; }
        public string Carbrand { get; set; }
        public double MaxLoad { get; set; }
        public int? MaxPeopleNum { get; set; }
        public string Remark { get; set; }
        public DateTime? BuyDate { get; set; }
    }
}
