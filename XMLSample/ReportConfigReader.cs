using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace XMLSample
{
    public class ReportConfigReader
    {
        public static List<ReportColumn> GetReportColumns(string strReportId)
        {
            var columns = new List<ReportColumn>();
            var setting = new XmlReaderSettings {IgnoreComments = true};
            string path = @"D:\code\workspace\Sample\XMLSample\Report.xml";
            XmlReader reader = XmlReader.Create(path, setting);
            var doc = new XmlDocument();
            doc.Load(reader);
            XmlElement xe = doc.DocumentElement;
            string parentNodePath = string.Format("/ReportItem/Item[@ReportID={0}]/ColumnName", strReportId);
            var node = xe.SelectSingleNode(parentNodePath);
            string computNodePath = string.Format("/ReportItem/Item[@ReportID={0}]/ComputColumns/ComputColumn", strReportId);
            XmlNodeList exNodes = xe.SelectNodes(computNodePath);
            string columnNames = node.InnerText;
            string[] arrColNames = columnNames.Split(',');
            foreach (string colName in arrColNames)
            {
                var reportColumn = new ReportColumn();
                reportColumn.Name = colName.Split(':')[0];
                columns.Add(reportColumn);
            }
            foreach (XmlNode exNode in exNodes)
            {
                var exNodeName = exNode.Attributes[0].Value;
                var col = columns.SingleOrDefault(o => o.Name == exNodeName);
                if (col != null)
                {
                    col.Expression = exNode.InnerText;
                }
            }
            return columns;
        }
    }

    public class ReportColumn
    {
        public string Name { get; set; }
        public string Expression { get; set; }
    }
}