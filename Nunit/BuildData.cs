using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;

namespace Nunit
{
    public class BuildData
    {
        public static List<City> GetTestData()
        {
            var list = new List<City>();
            var anyang = new City
            {
                Name = "安阳市",
                Id = "01",
                Population = 5000000
            };
            var anyangCounties = new List<County>
            {
                new County
                {
                    Name = "内黄县",
                    Id = "0101",
                    Population = 500000,
                    City = anyang
                }
            };
            anyang.Counties = anyangCounties;
           var puyang = new City
            {
                Name = "濮阳市",
                Id = "02",
                Population = 4000000,
                Counties = anyangCounties
            };
            var puYangShiQu = new County
            {
                Name = "市区",
                Id = "0201",
                City = puyang,
                Population = 400000
            };
            var shiQuTownShips = new List<Township>
            {
                new Township
                {
                    Name = "胡村乡",
                    Id = "020101",
                    Population = 500000,
                    County = puYangShiQu
                },
                new Township
                {
                    Name = "孟轲乡",
                    Id = "020102",
                    Population = 600000,
                    County = puYangShiQu
                }
            };
            puYangShiQu.Townships = shiQuTownShips;

            var taiQian = new County
            {
                Name = "台前县",
                Id = "0202",
                City = puyang,
                Population = 400000
            };

            var taiQianTownShips = new List<Township>
            {
                new Township
                {
                    Name = "城关镇",
                    Id = "020201",
                    Population = 70000,
                    County = taiQian
                    
                },
                new Township
                {
                    Name = "侯庙镇",
                    Id = "020202",
                    Population = 70000,
                    County = taiQian
                },
                new Township
                {
                    Name = "后方乡",
                    Id = "020203",
                    Population = 30000,
                    County = taiQian
                }
            };
            taiQian.Townships = taiQianTownShips;
           var puyangCounties = new List<County>
            {
                new County
                {
                    Name = "市区",
                    Id = "0201",
                    City = puyang,
                    Population = 500000
                }
            };
            list.Add(anyang);

            return list;
        }

    }
}
