using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ReadWriteExcel
{
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
            this.openFileDialog1.Filter = "xls|*.xls|xlsx|*xlsx";
        }

        /// <summary>
        /// 使用NPOI读取EXCEL文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="sheetName">表格名称</param>
        /// <param name="isFirstRowCellName">第一行是否列标题</param>
        /// <param name="errMsg">读取文档是的促进哦呜信息</param>
        /// <returns></returns>
        public static bool ReadDataFromExcel(string fileName, string sheetName, bool isFirstRowCellName,ref DataTable dtData, ref string errMsg)
        {
            ISheet sheet = null;
            IWorkbook workbook = null;
            int startRow = 0;

            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);
            }
            if (workbook == null)
            {
                errMsg = "读取文档内容失败";
                return false;
            }
            if (!string.IsNullOrEmpty(sheetName))
            {
                sheet = workbook.GetSheet(sheetName);
                if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                {
                    sheet = workbook.GetSheetAt(0);
                }
            }
            else
            {
                sheet = workbook.GetSheetAt(0);
            }
            if (sheet == null)
            {
                errMsg = "未读取到Sheet内容";
                return false;
            }
            IRow firstRow = sheet.GetRow(0);
            int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

            if (isFirstRowCellName)
            {
                for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                {
                    ICell cell = firstRow.GetCell(i);
                    if (cell != null)
                    {
                        string cellValue = cell.StringCellValue;
                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            if (dtData.Columns.Contains(cellValue))
                            {
                                errMsg = "表格中有重复的列名：" + cellValue;
                                return false;
                            }
                            DataColumn column = new DataColumn(cellValue);
                            dtData.Columns.Add(column);
                        }
                    }
                }
                startRow = sheet.FirstRowNum + 1;
            }
            else
            {
                startRow = sheet.FirstRowNum;
            }

            //总列数
            int rowCount = sheet.LastRowNum;
            for (int i = startRow; i <= rowCount; ++i)
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue; //没有数据的行默认是null　　　　　　　

                DataRow dataRow = dtData.NewRow();
                for (int j = row.FirstCellNum; j < cellCount; ++j)
                {
                    if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dtData.Rows.Add(dataRow);
            }

            return true;

        }

        private void btnBrowser_Click(object sender, System.EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtFileName.Text = this.openFileDialog1.FileName;
                DataTable dtData = new DataTable();
                string errMsg = string.Empty;
                var blReadSuccess = ReadDataFromExcel(this.openFileDialog1.FileName, string.Empty, true, ref dtData, ref errMsg);
                if (!blReadSuccess)
                {
                    MessageBox.Show(errMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.dataGridView1.DataSource = dtData;
                }
            }
        }
    }
}
