using System.Collections.Generic;

namespace NUnit
{
    public class OrgBase
    {
        public string Name { get; set; }
        public string Id { get; set; }
        /// <summary>
        /// 人口
        /// </summary>
        public int Population { get; set; }
    }

    public class City : OrgBase
    {
        public List<County> Counties { get; set; }
    }

    public class County : OrgBase
    {
        public City City { get; set; }
        public List<Township> Townships { get; set; }
    }

    public class Township : OrgBase
    {
        public County County { get; set; }
    }
}
