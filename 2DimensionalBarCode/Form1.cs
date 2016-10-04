using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace _2DimensionalBarCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            var strContent = this.txtContent.Text.Trim();
            if (string.IsNullOrEmpty(strContent))
            {
                MessageBox.Show("请输入要生成的内容", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MemoryStream ms;
            var path = "D:\\QrCode\\" + DateTime.Now.ToString("yyyyMMddssffff") + ".jpeg";
            if (GenCode(strContent, out ms))
            {

                SaveToFile(ms,path);
                RenderToPictureBox(path);
            }
            else
            {
                MessageBox.Show("生成失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ms.Close();
        }

        private bool GenCode(string content, out MemoryStream ms)
        {
            ms = new MemoryStream();
            ErrorCorrectionLevel ecl = ErrorCorrectionLevel.M;//误差水平
            QuietZoneModules qzm = QuietZoneModules.Two;
            int moduleSize = 12;
            QrEncoder encoder = new QrEncoder(ecl);
            QrCode qr;
            if (encoder.TryEncode(content, out qr))//对内容进行编码，并保存生成的矩阵  
            {
                var render = new GraphicsRenderer(new FixedModuleSize(moduleSize, qzm));
                render.WriteToStream(qr.Matrix, ImageFormat.Jpeg, ms);
                return true;
            }
            return false;
        }

        private void RenderToPictureBox(string path)
        {
            try
            {
                var img = Image.FromFile(path);
                this.pictureBox1.Image = img;

                //img.Save(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("图片加载失败，错误信息：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToFile(MemoryStream ms,string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytes, 0, bytes.Length);

                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件失败，信息：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
