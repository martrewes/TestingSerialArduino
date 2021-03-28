using System;
using System.IO;
using System.Threading.Tasks;
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
            var watcher = new FileSystemWatcher(@"D:\Desktop\")
            {
                NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size
            };

            watcher.Changed += OnChanged;

            watcher.Filter = "fooNow.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {   

            }
            System.Threading.Thread.Sleep(200);
            String songInfo = "D:\\Desktop\\fooNow.txt";  
                String strPort = "COM3";
                String strSend = "|";
                string line;
                int counter = 0;
                System.IO.StreamReader lineReader = new System.IO.StreamReader(songInfo);
                while ((line = lineReader.ReadLine()) != null)
                {
                    strSend = strSend + line + "|";
                    counter++;
                }
                lineReader.Close();
                int baud = 9600;
                var sendPort = new SerialPort(strPort, baud);
                sendPort.Open();
                sendPort.WriteLine(strSend);
                sendPort.Close();
            
            Console.WriteLine($"Changed: {e.FullPath}");
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
            
        }

        public void lstPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }

}