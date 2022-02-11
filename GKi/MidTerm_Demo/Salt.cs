using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MidTerm_Demo.Form1;

namespace MidTerm_Demo
{
    public partial class Salt : Form
    {
        public Salt()
        {
            InitializeComponent();
        }

        private void Salt_Load(object sender, EventArgs e)
        {
            textBox1.Text = DataBlock1static.RequiredSalinity.ToString("0.00");
            textBox2.Text = DataBlock1static.ActualSalinity.ToString("0.00");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DataBlock1static.RequiredSalinity = double.Parse(textBox1.Text);
            DataBlock1static.ActualSalinity = double.Parse(textBox2.Text);
            MessageBox.Show("Save completed","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Salt_Load_1(object sender, EventArgs e)
        {

        }
    }
}
