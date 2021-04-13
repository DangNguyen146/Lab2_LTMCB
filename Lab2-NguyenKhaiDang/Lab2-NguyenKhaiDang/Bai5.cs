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
    public partial class Bai5 : Form
    {
        public Bai5()
        {
            InitializeComponent();
            DirectoryInfo di = new DirectoryInfo(@"F:\UIT_HK2\LapTrinhMangCanBan\ThucHanh\19521317-NguyenKhaiDang-lab2");
            FileInfo[] fiArr = di.GetFiles();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Tên file", 100);
            listView1.Columns.Add("Kích thước", 70);
            listView1.Columns.Add("Đuôi mở rộng", 70);
            listView1.Columns.Add("Ngày tạo", 70);
            
            string[] arr = new string[4];
            ListViewItem itm;
            foreach (FileInfo temp in fiArr)
            {
                arr[0]= temp.FullName;
                arr[1] = temp.Length.ToString().Trim();
                arr[2] = temp.Extension.ToString();
                arr[3] = temp.CreationTime.ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }
    }
}
