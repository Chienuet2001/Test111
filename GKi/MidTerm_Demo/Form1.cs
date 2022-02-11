using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using S7.Net.Types;

namespace MidTerm_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Plc myplc = new Plc(CpuType.S71200, "127.0.0.1", 0, 1);
        byte[] Output = new byte[20];
        byte[] Memory = new byte[20];
        class ReadData
        {
            public bool iStart { get; set; }
            public bool iStop { get; set; }
            public bool oPump1 { get; set; }
            public bool oPump2 { get; set; }
            public bool iSensorHigh1 { get; set; }
            public bool iSensorLow1 { get; set; }
            public bool oPump3 { get; set; }
            public bool oValve1 { get; set; }
            public bool iSensorHigh3 { get; set; }
            public bool iSensorLow3 { get; set; }
            public bool iSensorHigh2 { get; set; }
            public bool iSensorLow2 { get; set; }
            public bool iSensorHigh4 { get; set; }
            public bool iSensorLow4 { get; set; }
            public bool oValve2 { get; set; }
            public bool oPump4 { get; set; }
        }
        ReadData myData = new ReadData();

        class DataBlock1
        {
            public double RequiredSalinity { get; set; }
            public double ActualSalinity { get; set; }
        }
        DataBlock1 myDB1 = new DataBlock1();
        public static class DataBlock1static
        {
            public static double RequiredSalinity { get; set; }
            public static double ActualSalinity { get; set; }
        }
        private void standardControl2_Load(object sender, EventArgs e)
        {

        }

        private void standardControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myplc.Open();
            timer1.Start();
            // groupBox1.Visible = false;
        }

        

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (myplc.IsConnected == true)
            {
                MessageBox.Show("Kết nối thành công!");
            }
            else
                MessageBox.Show("Kết nối không thành công!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Output = myplc.ReadBytes(DataType.Output, 0, 0, 1);
            if (Output[0].SelectBit(0) == true)
            {
                oPump1.DiscreteValue2 = true;
                oPump1.DiscreteValue1 = false;
            }
            else
            {
                oPump1.DiscreteValue2 = false;
                oPump1.DiscreteValue1 = true;
            }
            if (Output[0].SelectBit(1) == true)
            {
                oPump2.DiscreteValue2 = true;
                oPump2.DiscreteValue1 = false;
            }
            else
            {
                oPump2.DiscreteValue2 = false;
                oPump2.DiscreteValue1 = true;
            }
            if (Output[0].SelectBit(2) == true)
            {
                oPump3.DiscreteValue2 = true;
                oPump3.DiscreteValue1 = false;
            }
            else
            {
                oPump3.DiscreteValue2 = false;
                oPump3.DiscreteValue1 = true;
            }
            if (Output[0].SelectBit(3) == true)
            {
                oPump4.DiscreteValue2 = true;
                oPump4.DiscreteValue1 = false;
            }
            else
            {
                oPump4.DiscreteValue2 = false;
                oPump4.DiscreteValue1 = true;
            }
            if (Output[0].SelectBit(4) == true)
            {
                oValve1.DiscreteValue2 = true;
                oValve1.DiscreteValue1 = false;
            }
            else
            {
                oValve1.DiscreteValue2 = false;
                oValve1.DiscreteValue1 = true;
            }
            if (Output[0].SelectBit(5) == true)
            {
                oValve2.DiscreteValue2 = true;
                oValve2.DiscreteValue1 = false;
            }
            else
            {
                oValve2.DiscreteValue2 = false;
                oValve2.DiscreteValue1 = true;
            }

            Memory = myplc.ReadBytes(DataType.Memory, 0, 0, 2);

            if (Memory[0].SelectBit(0) == true)
            {
                standardControl56.DiscreteValue1 = false;
                standardControl56.DiscreteValue2 = true;
            }
            else
            {
                standardControl56.DiscreteValue1 = true;
                standardControl56.DiscreteValue2 = false;
            }
            if (Memory[0].SelectBit(4) == true)
            {
                standardControl10.DiscreteValue1 = false;
                standardControl10.DiscreteValue2 = true;
                iSensorHigh1.DiscreteValue1 = false;
                iSensorHigh1.DiscreteValue2 = true;
            }
            else
            {
                standardControl10.DiscreteValue1 = true;
                standardControl10.DiscreteValue2 = false;
                iSensorHigh1.DiscreteValue1 = true;
                iSensorHigh1.DiscreteValue2 = false;
            }
            if (Memory[0].SelectBit(5) == true)
            {
                standardControl3.DiscreteValue1 = false;
                standardControl3.DiscreteValue2 = true;
                iSensorLow1.DiscreteValue1 = false;
                iSensorLow1.DiscreteValue2 = true;
            }
            else
            {
                standardControl3.DiscreteValue1 = true;
                standardControl3.DiscreteValue2 = false;
                iSensorLow1.DiscreteValue1 = true;
                iSensorLow1.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(3) == true)
            {
                standardControl17.DiscreteValue1 = false;
                standardControl17.DiscreteValue2 = true;
                iSensorHigh2.DiscreteValue1 = false;
                iSensorHigh2.DiscreteValue2 = true;
            }
            else
            {
                standardControl17.DiscreteValue1 = true;
                standardControl17.DiscreteValue2 = false;
                iSensorHigh2.DiscreteValue1 = true;
                iSensorHigh2.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(4) == true)
            {
                standardControl27.DiscreteValue1 = false;
                standardControl27.DiscreteValue2 = true;
                iSensorLow2.DiscreteValue1 = false;
                iSensorLow2.DiscreteValue2 = true;
            }
            else
            {
                standardControl27.DiscreteValue1 = true;
                standardControl27.DiscreteValue2 = false;
                iSensorLow2.DiscreteValue1 = true;
                iSensorLow2.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(1) == true)
            {
                standardControl28.DiscreteValue1 = false;
                standardControl28.DiscreteValue2 = true;
                iSensorHigh3.DiscreteValue1 = false;
                iSensorHigh3.DiscreteValue2 = true;
            }
            else
            {
                standardControl28.DiscreteValue1 = true;
                standardControl28.DiscreteValue2 = false;
                iSensorHigh3.DiscreteValue1 = true;
                iSensorHigh3.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(2) == true)
            {
                standardControl35.DiscreteValue1 = false;
                standardControl35.DiscreteValue2 = true;
                iSensorLow3.DiscreteValue1 = false;
                iSensorLow3.DiscreteValue2 = true;
            }
            else
            {
                standardControl35.DiscreteValue1 = true;
                standardControl35.DiscreteValue2 = false;
                iSensorLow3.DiscreteValue1 = true;
                iSensorLow3.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(5) == true)
            {
                standardControl41.DiscreteValue1 = false;
                standardControl41.DiscreteValue2 = true;
                iSensorHigh4.DiscreteValue1 = false;
                iSensorHigh4.DiscreteValue2 = true;
            }
            else
            {
                standardControl41.DiscreteValue1 = true;
                standardControl41.DiscreteValue2 = false;
                iSensorHigh4.DiscreteValue1 = true;
                iSensorHigh4.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(6) == true)
            {
                standardControl55.DiscreteValue1 = false;
                standardControl55.DiscreteValue2 = true;
                iSensorLow4.DiscreteValue1 = false;
                iSensorLow4.DiscreteValue2 = true;
            }
            else
            {
                standardControl55.DiscreteValue1 = true;
                standardControl55.DiscreteValue2 = false;
                iSensorLow4.DiscreteValue1 = true;
                iSensorLow4.DiscreteValue2 = false;
            } 
        }
        

        private void btOffSensorLow1_Click(object sender, EventArgs e)   // Off sensor low 1
        {
           
            myplc.Write("M0.5", 0);
        }

        private void btOnSensorHigh1_Click(object sender, EventArgs e)   // On sensor high 1
        {
            myplc.Write("M0.4",1);
            
        }

        private void btOffSensorHigh1_Click(object sender, EventArgs e)   // Off sensor high 2
        {
            myplc.Write("M1.3", 0);
            
        }

        private void btOnSensorLow1_Click(object sender, EventArgs e)  // On sensor low 1
        {
            
            myplc.Write("M0.5", 1);
        }

        private void btOnSensorHigh2_Click(object sender, EventArgs e)   // On sensor high 2
        {
            myplc.Write("M1.3", 1);
            
        }

        private void btOffSensorHigh2_Click(object sender, EventArgs e)   // Off sensor high 2
        {
            myplc.Write("M1.3", 0);
            
        }

        private void btOnSensorLow2_Click(object sender, EventArgs e)   // On sensor low 2
        {
            
            myplc.Write("M1.4", 1);
        }

        private void btOffSensorLow2_Click(object sender, EventArgs e)   // Off sensor low 2
        {
            
            myplc.Write("M1.4", 0);
        }

        private void btOnSensorHigh3_Click(object sender, EventArgs e)   //On sensor high 3
        {
            myplc.Write("M1.1", 1);
            
        }

        private void btOffSensorHigh3_Click(object sender, EventArgs e)   //Off sensor high 3
        {
            myplc.Write("M1.1", 0);
           
        }

        private void btOnSensorLow3_Click(object sender, EventArgs e)    // On sensor low 3
        {
            
            myplc.Write("M1.2", 1);
        }

        private void btOffSensorLow3_Click(object sender, EventArgs e)   // Off sensor low 3
        {
            myplc.Write("M1.2", 0);
        }
        private void btOnSensorHigh4_Click(object sender, EventArgs e)   // On sensor high 4
        {
            myplc.Write("M1.5", 1);
            
        }

        private void btOffSensorHigh4_Click(object sender, EventArgs e)   // Off sensor high 4
        {
            myplc.Write("M1.5", 0);
            
        }

        private void btOnSensorLow4_Click(object sender, EventArgs e)    // On sensor low 4
        {
            
            myplc.Write("M1.6", 1);
        }

        private void btOffSensorLow4_Click(object sender, EventArgs e)   // Off sensor low 4
        {
            
            myplc.Write("M1.6", 0);
        }

       

        private void btSystemOn_Click(object sender, EventArgs e)  // Start system
        {
            myplc.Write("M0.1", 1);
            myplc.Write("M0.1", 0);
        }

        private void btSystemOff_Click(object sender, EventArgs e)   // Stop system
        {
            myplc.Write("M0.2", 1);
            myplc.Write("M0.2", 0);
        }

        private void nhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // groupBox1.Visible = true;
            myplc.ReadClass(myDB1,3);
            DataBlock1static.RequiredSalinity = myDB1.RequiredSalinity;
            DataBlock1static.ActualSalinity = myDB1.ActualSalinity;

            Salt _Salt = new Salt();
            _Salt.ShowDialog();
            myDB1.RequiredSalinity = DataBlock1static.RequiredSalinity;
            myDB1.ActualSalinity = DataBlock1static.ActualSalinity;
            myplc.WriteClass(myDB1, 3);
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes);
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();

            }
            

        }

    }
}
