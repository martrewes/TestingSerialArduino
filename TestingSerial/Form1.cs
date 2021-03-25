using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;




namespace TestingSerial
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        public void RefreshPorts()
        {
            lstPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {                
                lstPorts.Items.Add(port);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        public void btnSend_Click(object sender, EventArgs e)
        {
            if (lstPorts.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Item first!");
            }
            else { 
                string strPort = lstPorts.SelectedItem.ToString();
                string strSend = txtString.Text;
                int baud = 9600;
                var sendPort = new SerialPort(strPort, baud);
                sendPort.Open();
                sendPort.WriteLine(strSend);
                sendPort.Close();
            }
        }

        public void lstPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}