using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeImg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string path = txtImgPath.Text.Trim();
            string savepath = txtSavePath.Text.Trim();
            int num = 0;
            if (!System.IO.Directory.Exists(path))
            {
                return;
            }
            if (!System.IO.Directory.Exists(savepath))
            {
                System.IO.Directory.CreateDirectory(savepath);
            }
            string[] fileStrs = System.IO.Directory.GetFiles(path);
            foreach (string s in fileStrs)
            {
                System.IO.FileInfo info = new System.IO.FileInfo(s);
                if (info.Extension == ".png" || info.Extension == ".jpg")
                {
                    Image img = GetFile(s);
                    Bitmap bit = GetNewSizeBitmap(img);
                    SaveImage(bit, info.Name, info.Extension, savepath);
                }
                ++num;
            }
            lblResult.Text= "共处理：" + num + " 张图片";
        }
        public Image GetFile(string path)
        {
            FileStream stream = File.OpenRead(path);
            int fileLength = 0;
            fileLength = (int)stream.Length;
            Byte[] image = new Byte[fileLength];
            stream.Read(image, 0, fileLength);
            System.Drawing.Image result = System.Drawing.Image.FromStream(stream);
            stream.Close();
            return result;
        }
        public Bitmap GetNewSizeBitmap(Image img)
        {
            int newWidth = Convert.ToInt32(txtWith.Text.Trim());
            int newHeight = Convert.ToInt32(txtHeight.Text.Trim());
            Size s = new Size(newWidth, newHeight);
            Bitmap newBit = new Bitmap(img, s);
            return newBit;
        }
        public void SaveImage(Bitmap bit, string name, string ext, string savepath)
        {
            bit.Save(savepath + "/" + name);
            bit.Dispose();
        }
    }
}
