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

namespace FinalTermDemo
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
        private void Form1_Load(object sender, EventArgs e)
        {
            myplc.Open();
            timer1.Start();
            txtMassRice.Text = DataMassStatic.MassRice.ToString("0");
            txtMassCorn.Text = DataMassStatic.MassCorn.ToString("0");
            txtMassManioc.Text = DataMassStatic.MassManioc.ToString("0");
            txtMassBean.Text = DataMassStatic.MassBean.ToString("0");
            txtMassFish.Text = DataMassStatic.MassFish.ToString("0");
        }

        class ReadDataInput
        {
            public bool Start { get; set; }
            public bool Stop { get; set; }
            public bool Continue { get; set; }
            public bool Reset { get; set; }

        }
        ReadDataInput InputandOutput = new ReadDataInput();

        class ReadDataOutput
        {
            public bool Silo1 { get; set; }
            public bool Silo2 { get; set; }
            public bool Silo3 { get; set; }
            public bool Silo4 { get; set; }
            public bool Silo5 { get; set; }
            public bool Silo6 { get; set; }
            public bool Silo7 { get; set; }
            public bool Silo8 { get; set; }
            public bool Silo9 { get; set; }
            public bool Silo10 { get; set; }
            public bool Silo11 { get; set; }
            public bool Silo12 { get; set; }
            public bool Silo13 { get; set; }
            public bool Silo14 { get; set; }
            public bool Silo15 { get; set; }
            public bool Silo16 { get; set; }
        }
        ReadDataOutput DataOutput = new ReadDataOutput();

        class ReadDataLight
        {
            public bool LightRice { get; set; }
            public bool LightCorn { get; set; }
            public bool LightManioc { get; set; }
            public bool LightBean { get; set; }
            public bool LightFish { get; set; }

        }
        ReadDataLight DataLight = new ReadDataLight();


        class DataMass
        {
            public int MassRice { get; set; }
            public int MassCorn { get; set; }
            public int MassManioc { get; set; }
            public int MassBean { get; set; }
            public int MassFish { get; set; }
            public int MassSum1 { get; set; }
            public int MassSum2 { get; set; }
        }
        DataMass Mass = new DataMass();


        public static class DataMassStatic
        {
            public static int MassRice { get; set; }
            public static int MassCorn { get; set; }
            public static int MassManioc { get; set; }
            public static int MassBean { get; set; }
            public static int MassFish { get; set; }
            public static int MassSum1 { get; set; }
            public static int MassSum2 { get; set; }
        }


        class DataMassEachSilo
        {
            public int MassRiceEachSilo { get; set; }
            public int MassCornEachSilo { get; set; }
            public int MassManiocEachSilo { get; set; }
            public int MassFishEachSilo { get; set; }
            public int MassBeanEachSilo { get; set; }
        }
        DataMassEachSilo MassEachSilo = new DataMassEachSilo();
        public static class DataMassEachSiloStatic
        {
            public static int MassRiceEachSilo { get; set; }
            public static int MassCornEachSilo { get; set; }
            public static int MassManiocEachSilo { get; set; }
            public static int MassFishEachSilo { get; set; }
            public static int MassBeanEachSilo { get; set; }
        }
        class DataAdd
        {
            public int ScaleSum1 { get; set; }
            public int ScaleSum2 { get; set; }
        }
        DataAdd Add = new DataAdd();

        class DataWeight
        {
            public int WeightSilo1 { get; set; }
            public int WeightSilo2 { get; set; }
            public int WeightSilo3 { get; set; }
            public int WeightSilo4 { get; set; }
            public int WeightSilo5 { get; set; }
            public int WeightSilo6 { get; set; }
            public int WeightSilo7 { get; set; }
            public int WeightSilo8 { get; set; }
            public int WeightSilo9 { get; set; }
            public int WeightSilo10 { get; set; }
            public int WeightSilo11 { get; set; }
            public int WeightSilo12 { get; set; }
            public int WeightSilo13 { get; set; }
            public int WeightSilo14 { get; set; }
            public int WeightSilo15 { get; set; }
            public int WeightSilo16 { get; set; }
            public int WeightSum1 { get; set; }
            public int WeightSum2 { get; set; }
        }
        DataWeight Weight = new DataWeight();


        private void timer1_Tick(object sender, EventArgs e)
        {
            myplc.ReadClass(Add, 24);
            myplc.ReadClass(Weight, 23);
            Output = myplc.ReadBytes(DataType.Output, 0, 0, 15);
            if (Output[0].SelectBit(0) == true)
            {
                Silo1.DiscreteValue1 = false;
                Silo1.DiscreteValue2 = true;
            }
            else
            {
                Silo1.DiscreteValue1 = true;
                Silo1.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(1) == true)
            {
                Silo2.DiscreteValue1 = false;
                Silo2.DiscreteValue2 = true;
            }
            else
            {
                Silo2.DiscreteValue1 = true;
                Silo2.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(2) == true)
            {
                Silo3.DiscreteValue1 = false;
                Silo3.DiscreteValue2 = true;
            }
            else
            {
                Silo3.DiscreteValue1 = true;
                Silo3.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(3) == true)
            {
                Silo4.DiscreteValue1 = false;
                Silo4.DiscreteValue2 = true;
            }
            else
            {
                Silo4.DiscreteValue1 = true;
                Silo4.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(4) == true)
            {
                Silo5.DiscreteValue1 = false;
                Silo5.DiscreteValue2 = true;
            }
            else
            {
                Silo5.DiscreteValue1 = true;
                Silo5.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(5) == true)
            {
                Silo6.DiscreteValue1 = false;
                Silo6.DiscreteValue2 = true;
            }
            else
            {
                Silo6.DiscreteValue1 = true;
                Silo6.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(6) == true)
            {
                Silo7.DiscreteValue1 = false;
                Silo7.DiscreteValue2 = true;
            }
            else
            {
                Silo7.DiscreteValue1 = true;
                Silo7.DiscreteValue2 = false;
            }
            if (Output[0].SelectBit(7) == true)
            {
                Silo8.DiscreteValue1 = false;
                Silo8.DiscreteValue2 = true;
            }
            else
            {
                Silo8.DiscreteValue1 = true;
                Silo8.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(0) == true)
            {
                Silo9.DiscreteValue1 = false;
                Silo9.DiscreteValue2 = true;
            }
            else
            {
                Silo9.DiscreteValue1 = true;
                Silo9.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(1) == true)
            {
                Silo10.DiscreteValue1 = false;
                Silo10.DiscreteValue2 = true;
            }
            else
            {
                Silo10.DiscreteValue1 = true;
                Silo10.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(2) == true)
            {
                Silo11.DiscreteValue1 = false;
                Silo11.DiscreteValue2 = true;
            }
            else
            {
                Silo11.DiscreteValue1 = true;
                Silo11.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(3) == true)
            {
                Silo12.DiscreteValue1 = false;
                Silo12.DiscreteValue2 = true;
            }
            else
            {
                Silo12.DiscreteValue1 = true;
                Silo12.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(4) == true)
            {
                Silo13.DiscreteValue1 = false;
                Silo13.DiscreteValue2 = true;
            }
            else
            {
                Silo13.DiscreteValue1 = true;
                Silo13.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(5) == true)
            {
                Silo14.DiscreteValue1 = false;
                Silo14.DiscreteValue2 = true;
            }
            else
            {
                Silo14.DiscreteValue1 = true;
                Silo14.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(6) == true)
            {
                Silo15.DiscreteValue1 = false;
                Silo15.DiscreteValue2 = true;
            }
            else
            {
                Silo15.DiscreteValue1 = true;
                Silo15.DiscreteValue2 = false;
            }
            if (Output[1].SelectBit(7) == true)
            {
                Silo16.DiscreteValue1 = false;
                Silo16.DiscreteValue2 = true;
            }
            else
            {
                Silo16.DiscreteValue1 = true;
                Silo16.DiscreteValue2 = false;
            }
            if (Output[2].SelectBit(0) == true)
            {

                oValve1.DiscreteValue1 = false;
                oValve1.DiscreteValue2 = true;
            }
            else
            {
                oValve1.DiscreteValue1 = true;
                oValve1.DiscreteValue2 = false;
            }
            if (Output[2].SelectBit(3) == true)
            {

                oValve3.DiscreteValue1 = false;
                oValve3.DiscreteValue2 = true;
            }
            else
            {
                oValve3.DiscreteValue1 = true;
                oValve3.DiscreteValue2 = false;
            }
            if (Output[2].SelectBit(1) == true)
            {
                oValve2.DiscreteValue1 = false;
                oValve2.DiscreteValue2 = true;
            }
            else
            {

                oValve2.DiscreteValue1 = true;
                oValve2.DiscreteValue2 = false;
            }

            if (Output[2].SelectBit(2) == true)
            {
                oMix.DiscreteValue1 = false;
                oMix.DiscreteValue2 = true;
            }
            else
            {

                oMix.DiscreteValue1 = true;
                oMix.DiscreteValue2 = false;
            }

            Memory = myplc.ReadBytes(DataType.Memory, 0, 0, 5);

            if (Memory[1].SelectBit(5) == true)
            {
                LightRice.DiscreteValue1 = false;
                LightRice.DiscreteValue2 = true;
            }
            else
            {
                LightRice.DiscreteValue1 = true;
                LightRice.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(6) == true)
            {
                LightCorn.DiscreteValue1 = false;
                LightCorn.DiscreteValue2 = true;
            }
            else
            {
                LightCorn.DiscreteValue1 = true;
                LightCorn.DiscreteValue2 = false;
            }
            if (Memory[1].SelectBit(7) == true)
            {
                LightManioc.DiscreteValue1 = false;
                LightManioc.DiscreteValue2 = true;
            }
            else
            {
                LightManioc.DiscreteValue1 = true;
                LightManioc.DiscreteValue2 = false;
            }
            if (Memory[2].SelectBit(0) == true)
            {
                LightBean.DiscreteValue1 = false;
                LightBean.DiscreteValue2 = true;
            }
            else
            {
                LightBean.DiscreteValue1 = true;
                LightBean.DiscreteValue2 = false;
            }
            if (Memory[2].SelectBit(1) == true)
            {
                LightFish.DiscreteValue1 = false;
                LightFish.DiscreteValue2 = true;
            }
            else
            {
                LightFish.DiscreteValue1 = true;
                LightFish.DiscreteValue2 = false;
            }
            if (Memory[2].SelectBit(4) == true)
            {
                Sensor1.DiscreteValue3 = false;
                Sensor1.DiscreteValue2 = true;
                iSensor1.DiscreteValue1 = false;
                iSensor1.DiscreteValue2 = true;

            }
            else
            {
                Sensor1.DiscreteValue3 = true;
                Sensor1.DiscreteValue2 = false;
                iSensor1.DiscreteValue1 = true;
                iSensor1.DiscreteValue2 = false;

            }
            if (Memory[3].SelectBit(4) == true)
            {
                Sensor3.DiscreteValue3 = false;
                Sensor3.DiscreteValue2 = true;
                iSensor3.DiscreteValue1 = false;
                iSensor3.DiscreteValue2 = true;

            }
            else
            {
                Sensor3.DiscreteValue3 = true;
                Sensor3.DiscreteValue2 = false;
                iSensor3.DiscreteValue1 = true;
                iSensor3.DiscreteValue2 = false;

            }
            if (Memory[2].SelectBit(5) == true)
            {
                SensorHigh2.DiscreteValue3 = false;
                SensorHigh2.DiscreteValue2 = true;
                iSensorHigh2.DiscreteValue1 = false;
                iSensorHigh2.DiscreteValue2 = true;

            }
            else
            {
                SensorHigh2.DiscreteValue3 = true;
                SensorHigh2.DiscreteValue2 = false;
                iSensorHigh2.DiscreteValue1 = true;
                iSensorHigh2.DiscreteValue2 = false;
            }
            if (Memory[2].SelectBit(6) == true)
            {
                SensorLow2.DiscreteValue3 = false;
                SensorLow2.DiscreteValue2 = true;
                iSensorLow2.DiscreteValue1 = false;
                iSensorLow2.DiscreteValue2 = true;

            }
            else
            {
                SensorLow2.DiscreteValue3 = true;
                SensorLow2.DiscreteValue2 = false;
                iSensorLow2.DiscreteValue1 = true;
                iSensorLow2.DiscreteValue2 = false;

            }
            if (Memory[0].SelectBit(2) == true)
            {
                txtMass1.Text = myplc.Read("DB24.DBW0").ToString();
                txtMass2.Text = myplc.Read("DB24.DBW2").ToString();
                if (Memory[2].SelectBit(3) == true)
                {
                    txtMass1.Text = myplc.Read("DB23.DBW32").ToString();

                    txtMass2.Text = myplc.Read("DB23.DBW34").ToString();
                }
            }

        }

        private void Silo1_Load(object sender, EventArgs e)
        {

        }
        private void standardControl16_Load(object sender, EventArgs e)
        {

        }
        private void Start_Click(object sender, EventArgs e)
        {
            myplc.Write("M0.0", 1);
            myplc.Write("M0.0", 0);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            myplc.Write("M0.1", 1);
            myplc.Write("M0.1", 0);
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            myplc.Write("M3.1", 1);
            myplc.Write("M3.1", 0);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            myplc.Write("M4.3", 1);
            myplc.Write("M4.3", 0);
        }

        private void btOnSensorHigh1_Click(object sender, EventArgs e)
        {
            myplc.Write("M2.4", 1);
        }

        private void btOffSensorHigh1_Click(object sender, EventArgs e)
        {
            myplc.Write("M2.4", 0);
        }

        private void button2_Click(object sender, EventArgs e)  // on sensor 3
        {
            myplc.Write("M3.4", 1);
        }

        private void button1_Click(object sender, EventArgs e)  // off sensor 3
        {
            myplc.Write("M3.4", 0);
        }

        private void button4_Click(object sender, EventArgs e)  // on sensorhigh2
        {
            myplc.Write("M2.5", 1);
        }

        private void button3_Click(object sender, EventArgs e)  // off sensorhigh2
        {
            myplc.Write("M2.5", 0);
        }

        private void button6_Click(object sender, EventArgs e)  // on sensorlow2
        {
            myplc.Write("M2.6", 1);
        }

        private void button5_Click(object sender, EventArgs e)  // off sensorlow2
        {
            myplc.Write("M2.6", 0);

        }
        private void Save_Click(object sender, EventArgs e)
        {

            Mass.MassRice = int.Parse(txtMassRice.Text);
            Mass.MassCorn = int.Parse(txtMassCorn.Text);
            Mass.MassManioc = int.Parse(txtMassManioc.Text);
            Mass.MassBean = int.Parse(txtMassBean.Text);
            Mass.MassFish = int.Parse(txtMassFish.Text);

            MassEachSilo.MassRiceEachSilo = Mass.MassRice / 3;
            MassEachSilo.MassCornEachSilo = Mass.MassCorn / 4;
            MassEachSilo.MassManiocEachSilo = Mass.MassManioc / 2;
            MassEachSilo.MassBeanEachSilo = Mass.MassBean / 3;
            MassEachSilo.MassFishEachSilo = Mass.MassFish / 4;

            Mass.MassSum1 = Mass.MassRice + Mass.MassCorn + Mass.MassManioc;
            Mass.MassSum2 = Mass.MassBean + Mass.MassFish;
            myplc.Write("DB22.DBW0", Mass.MassRice);
            myplc.Write("DB22.DBW2", Mass.MassCorn);
            myplc.Write("DB22.DBW4", Mass.MassManioc);
            myplc.Write("DB22.DBW6", Mass.MassBean);
            myplc.Write("DB22.DBW8", Mass.MassFish);
            myplc.Write("DB22.DBW10", Mass.MassSum1);
            myplc.Write("DB22.DBW12", Mass.MassSum2);

            myplc.Write("DB1.DBW0", MassEachSilo.MassRiceEachSilo);
            myplc.Write("DB1.DBW2", MassEachSilo.MassCornEachSilo);
            myplc.Write("DB1.DBW4", MassEachSilo.MassManiocEachSilo);
            myplc.Write("DB1.DBW6", MassEachSilo.MassBeanEachSilo);
            myplc.Write("DB1.DBW8", MassEachSilo.MassFishEachSilo);

        }

    }
}
