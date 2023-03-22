using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Code; 

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sachbll.hienThi(dataGridView1);
        }
        Sach sachDTO = new Sach();
        sachbll sachbll= new sachbll();

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Trim() != "")
            {
                sachDTO.title = textBox2.Text;
                sachDTO.author = textBox3.Text;
                sachDTO.year = textBox4.Text;
                sachDTO.price = textBox5.Text;

                sachbll.Them(sachDTO);

                sachbll.hienThi(dataGridView1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sachbll.hienThi(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                sachDTO.title = textBox2.Text;
                sachDTO.author = textBox3.Text;
                sachDTO.year = textBox4.Text;
                sachDTO.price = textBox5.Text;

                sachbll.Sua(sachDTO);

                sachbll.hienThi(dataGridView1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                sachDTO.title = textBox2.Text;

                sachbll.Xoa(sachDTO);

                sachbll.hienThi(dataGridView1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                sachDTO.title = textBox2.Text;

                sachbll.TimKiem(sachDTO,dataGridView1);
            }
        }
    }
}
