using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evristika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Input> inp = new List<Input>();
        private List<Output> outp = new List<Output>();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            inp.Clear();
            outp.Clear();
            int lenght = Convert.ToInt32(textBox1.Text);
            Input inV;
            Output ouV;
            int sum = 0;
            int count = 0;
            for(int i=0;i<dataGridView1.RowCount-1;i++)
            {
                inV = new Input();
                inV.name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                inV.lenght = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                inV.count = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                inp.Add(inV);
                count = count + Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                sum = sum + Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) * Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            int kol = sum % lenght;
            if (kol > 0)
                kol = 1;
            kol = kol + ((sum - sum % lenght) / lenght);
            //for(int i=0;i<kol;i++)
            //{
            //    ouV = new Output();
            //    ouV.name = (i + 1).ToString();
            //    ouV.decription = "";
            //    ouV.ostatok = 0;
            //    outp.Add(ouV);
            //}
            int p = 1;
            int nachcount = 0;
            while(nachcount<count)
            {
                ouV = new Output();
                ouV.name = (p).ToString();
                string description = "";
                int lenght1 = lenght;
                for(int j=0;j<inp.Count;j++)
                {
                    int count1 = 0;
                    for(int k=0;k<inp[j].count;k++)
                    {
                        if(inp[j].lenght<=lenght1)
                        {
                            if (inp[j].count != 0)
                            {
                                count1 = count1+1;
                                lenght1 = lenght1 - inp[j].lenght;
                                
                            }
                        }
                    }
                    inp[j].count = inp[j].count - count1;
                    nachcount=nachcount + count1;
                    if(count1>0)
                    {
                        description = description + inp[j].name+ " - " +count1.ToString() + ";";
                    }
                }
                ouV.decription = description;
                ouV.ostatok = lenght1;
                outp.Add(ouV);
                p = p + 1;

            }
            for(int i=0;i<outp.Count;i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = outp[i].name;
                dataGridView2.Rows[i].Cells[1].Value = outp[i].decription;
                dataGridView2.Rows[i].Cells[2].Value = outp[i].ostatok;
            }

        }
    }
    public class Input
    {
        public string name { get; set; }
        public int lenght { get; set; }
        public int count { get; set; }
    }
    public class Output
    {
        public string name { get; set; }
        public string decription { get; set; }
        public int ostatok { get; set; }
    }
}
