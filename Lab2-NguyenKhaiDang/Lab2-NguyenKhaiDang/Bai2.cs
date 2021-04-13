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

namespace Lab2_NguyenKhaiDang
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            richTextBox1.Text = content;
            fs.Close();
            textBox1.Text = ofd.SafeFileName.ToString();
            textBox2.Text = ofd.FileName.ToString();
            //textBox3.Text = content.Length;
            textBox3.Text = richTextBox1.Lines.Count().ToString();
            content = content.Replace("\r\n", "\r");
            content = content.Replace('\r', ' ');
            string[] source = content.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            textBox4.Text = source.Count().ToString();
            textBox5.Text = richTextBox1.Text.Count().ToString();
        }
    }
}
