using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Lab2_NguyenKhaiDang
{
    public partial class Bai4 : Form
    {
        Student student = new Student();
        [Serializable]
        public class Student
        {
            public string MSSV{get;set;}= "";
            public string HoTen { get; set; } = "";
            public string DienThoai { get; set; } = "";
            public float DiemToan { get; set; } = 0;
            public float DiemVan { get; set; } = 0;

        }
        [Serializable]
        public class StudentB:Student
        {
            public float DTB { get; set; } = 0;
            public StudentB(Student st)
            {
                this.MSSV = st.MSSV;
                this.HoTen = st.HoTen;
                this.DienThoai = st.DienThoai;
                this.DiemToan = st.DiemToan;
                this.DiemVan = st.DiemVan;
            }

        }
        public Bai4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open);

            

            using (StreamReader reader = new StreamReader(fs))
            {
                student.MSSV = reader.ReadLine();
                student.HoTen = reader.ReadLine();
                student.DienThoai = reader.ReadLine();
                student.DiemToan = float.Parse(reader.ReadLine());
                student.DiemVan = float.Parse(reader.ReadLine());
            }
            fs.Close();
            richTextBox1.Text += student.ToString();

           


            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filePtach = @"F:\UIT_HK2\LapTrinhMangCanBan\ThucHanh\19521317-NguyenKhaiDang-lab2\outputDTB.txt";
            FileStream fs = new FileStream(filePtach, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            var newStd = new StudentB(student);
            newStd.DTB = (student.DiemToan + student.DiemVan) / 2;
            bf.Serialize(fs, newStd);



            fs.Position = 0;
            var student2 = (StudentB)bf.Deserialize(fs);
            var txt = JsonConvert.SerializeObject(student2);
            richTextBox1.Text += txt;
            fs.Close();
            MessageBox.Show("Success");
        }
    }
}
