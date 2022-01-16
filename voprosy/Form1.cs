using ClosedXML.Excel;
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
        public static List<string> arr = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("вопросы1.txt");
            int i = 0;
            int number = 0;
            string vopros = "";
            string otvet = "";
            while (!f.EndOfStream) //добавляем строки в массив
            {
                //if(f.ReadLine() != "")
                //{
                    arr.Add(f.ReadLine());
                //}
            }
            f.Close();
            try
            {

                for (int z = 0; z < arr.Count - 5; z++)
                {
                    if (arr[z].StartsWith("Вопрос"))//Ищем строку с текстом вопрос
                    {
                        z++;
                        //MessageBox.Show(arr[z]);
                        vopros = arr[z];
                        number++;
                        //z++; z++; z++;

                        while (!arr[z].StartsWith("N")) //пролистываем строки до вариантов ответа
                        {
                            z++;
                        }
                        z++;
                        while (arr[z].StartsWith("1.") || arr[z].StartsWith("2.") || arr[z].StartsWith("3.") || arr[z].StartsWith("4.") || arr[z].ToString()=="")
                        {
                            //MessageBox.Show(vopros + "////" + arr[z]);
                            otvet = arr[z];
                            //if (arr[z+1].StartsWith("-"))
                            //{
                            //    
                            //}
                                dataGridView1.Rows.Add();
                                dataGridView1[0, i].Value = @vopros;
                                dataGridView1[1, i].Value = @otvet;
                                dataGridView1[3, i].Value = @number.ToString();
                                i++;
                                z++;
                        }
                        z--;
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException saoore)
            {

            }
            catch(SystemException se)
            {
                MessageBox.Show(se.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = (Application.StartupPath) + @"otvet.xlsx";
            XLWorkbook xLWorkbook = new XLWorkbook();
            var excelworksheet = xLWorkbook.Worksheets.Add(1);
            for (int z = 0; z < dataGridView1.RowCount - 2; z++)
            {
                excelworksheet.Cell(z+1,1).Value = dataGridView1[0, z].Value.ToString();
                excelworksheet.Cell(z+1,2).Value = dataGridView1[1, z].Value.ToString();
                excelworksheet.Cell(z+1,3).Value = dataGridView1[2, z].Value.ToString();
            }
            xLWorkbook.SaveAs((Application.StartupPath) + @"\otvet.xlsx");
            MessageBox.Show((Application.StartupPath) + @"\otvet.xlsx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int z = 0; z < dataGridView1.RowCount - 2; z++)
            {
                dataGridView1[1, z].Value = dataGridView1[1, z].Value.ToString().Replace("1.\t", "").Replace("2.\t", "").Replace("3.\t", "").Replace("4.\t", "");
                if (dataGridView1[1, z].Value.ToString().Contains("<@1>") && dataGridView1[1, z].Value != null)
                {
                    dataGridView1[1, z].Value = dataGridView1[1, z].Value.ToString().Replace("<@1>", "");
                    dataGridView1[2, z].Value = "true";
                }
                else
                {
                    dataGridView1[2, z].Value = "false";
                }
            }
        }
    }
}
