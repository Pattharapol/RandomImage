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

namespace RandomImage
{
    public partial class Form1 : Form
    {
        private Random random;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private List<Image> img = new List<Image>();

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            DirectoryInfo fileList = new DirectoryInfo(path.Replace(@"\bin\Debug", @"\"));
            FileInfo[] files = fileList.GetFiles();

            foreach (var item in files)
            {
                if (item.Extension.ToUpper() == ".PNG" || item.Extension.ToUpper() == ".JPG" || item.Extension.ToUpper() == ".JPEG")
                {
                    string imgPath = path.Replace(@"\bin\Debug", @"\") + item;
                    Image im = Image.FromFile(imgPath);
                    img.Add(im);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            random = new Random();
            pictureBox1.Image = img[random.Next(img.Count)];
            lblImageCOunt.Text = "รูปที่ " + img.IndexOf(pictureBox1.Image).ToString();
        }
    }
}