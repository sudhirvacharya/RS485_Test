using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using NModbus;
using NModbus.Device;


namespace RS485
{
    
    public partial class Form1 : Form
    {
        ModbusClient ModClient = new ModbusClient(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            if (btnconnect.Text == "Connect")
            {/*
                ModClient.SerialPort = txtPort.Text;
                ModClient.Baudrate = int.Parse(txtBaud.Text);
                ModClient.Parity = Parity.None;
                ModClient.StopBits = StopBits.Two;
                
                ModClient.Connect();
                // Create a Modbus master
                var master = ModbusMaster.CreateRtu(ModClient);

                // Read the PV value (adjust the slave address and register address as needed)
                ushort pvValue = master.ReadHoldingRegisters(1, 40001, 1)[0];
                lblStatus.Text = "Connected";
                btnconnect.Text = "DisConnect";
                */
                SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
                serialPort.Open();


                var master = ModbusMaster.CreateRtu(serialPort);
                lblStatus.Text = "Connected";
                btnconnect.Text = "DisConnect";
            }
            else
            {
                ModClient.Disconnect();
                lblStatus.Text = "DisConnected";
                btnconnect.Text = "Connect";
            }

        }
    }
}
