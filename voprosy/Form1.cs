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

namespace voprosy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("вопросы1.txt");
            int i = 0;
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                //MessageBox.Show(s);
                dataGridView1.Rows.Add();
                i++;
                dataGridView1[0, i-1].Value = s;
            }
            f.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
