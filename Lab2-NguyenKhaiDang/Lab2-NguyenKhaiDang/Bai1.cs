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
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePtach = @"F:\UIT_HK2\LapTrinhMangCanBan\ThucHanh\19521317-NguyenKhaiDang-lab2\output.txt";
            FileStream fs = new FileStream(filePtach, FileMode.Create);
            StreamWriter fw = new StreamWriter(fs, Encoding.UTF8);
            richTextBox1.Text = richTextBox1.Text.ToUpper();
            fw.WriteLine(richTextBox1.Text.Trim());
            fw.Flush();
            fw.Close();
            MessageBox.Show("Success");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
