using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace task6._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MouseWheel += textBox1_MouseWheel;
            progressBar1.Visible = false;
          
        }
        void textBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                progressBar1.Minimum = 0;
                progressBar1.Step = textBox1.Lines.Count() / 10;
                progressBar1.Maximum = textBox1.Lines.Count();

                while (progressBar1.Value < progressBar1.Maximum)
                {
                    try
                    {
                        progressBar1.Value += 1;
                        break;
                    }
                    catch (Exception ep)
                    {
                        progressBar1.Value = progressBar1.Maximum;
                    }

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WithProgressReader wp = new WithProgressReader(openFileDialog1.FileName, progressBar1);
                textBox1.Text = wp.ReadAll();

               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                WithPasswordReader wp = new WithPasswordReader(openFileDialog1.FileName, "1");
                textBox1.Text = wp.ReadAll();
            }
        }
    }
}
