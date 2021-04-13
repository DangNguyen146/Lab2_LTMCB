using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_NguyenKhaiDang
{
    public partial class Bai3 : Form
    {
        public Bai3()
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePtach = @"F:\UIT_HK2\LapTrinhMangCanBan\ThucHanh\19521317-NguyenKhaiDang-lab2\outputToan.txt";
            FileStream fs = new FileStream(filePtach, FileMode.Create);
            StreamWriter fw = new StreamWriter(fs, Encoding.UTF8);
            //string reg = @"\d+";
            using(StringReader reader = new StringReader(richTextBox1.Text.Trim()))
            {
                richTextBox1.Text = "".ToString();
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Double temp1, temp2;
                        Regex reg = new Regex(@"\d+");
                        Match result = reg.Match(line);
                        temp1= Double.Parse(result.ToString().Trim());
                        result = result.NextMatch();
                        temp2 = Double.Parse(result.ToString().Trim());
                        Regex dau = new Regex(@"\D");
                        Match temp3 = dau.Match(line);
                        
                        switch (temp3.ToString().Trim())
                        {
                            case "+":
                                {
                                    fw.Write(temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1+temp2).ToString()+"\n");
                                    richTextBox1.Text += (temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 + temp2).ToString() + "\n").ToString();
                                    break;
                                }
                            case "-":
                                {
                                    fw.Write(temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 - temp2).ToString() + "\n");
                                    richTextBox1.Text += (temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 - temp2).ToString() + "\n").ToString();
                                    break;
                                }
                            case "*":
                                {
                                    fw.Write(temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 * temp2).ToString() + "\n");
                                    richTextBox1.Text += (temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 * temp2).ToString() + "\n").ToString();
                                    break;
                                }
                            case "/":
                                {
                                    fw.Write(temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 / temp2).ToString() + "\n");
                                    richTextBox1.Text += (temp1.ToString() + temp3.ToString() + temp2.ToString() + "=" + (temp1 / temp2).ToString() + "\n").ToString();
                                    break;
                                }
                        }
                        Match temp = dau.Match(line);

                       
                    }
                } while (line != null);
            }
            fw.Flush();
            fw.Close();
            MessageBox.Show("Success");
        }
    }
}
