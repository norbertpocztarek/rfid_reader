using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace rfid_reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected SerialPortController _spc;

        string _selectedSerialPort;
        /// <summary>
        /// get/set path to osciloscope settings file 
        /// </summary>
        public string SelectedSerialPort
        {
            get { return _selectedSerialPort; }
            set { _selectedSerialPort = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        #region comboBox Serial Port List
        private void comboBoxSerialPortsList_DropDownOpened(object sender, EventArgs e)
        {
            // Get a list of all available serial ports
            List<string> portNames = SerialPort.GetPortNames().ToList();

            // Get a list of all available USB serial ports
            List<string> usbPortNames = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE ClassGuid='{4d36e978-e325-11ce-bfc1-08002be10318}'");
            foreach (ManagementObject obj in searcher.Get())
            {
                string name = obj["Name"].ToString();
                string deviceID = obj["DeviceID"].ToString();

                //check if port name include a word COM and doesn't include a word BTHENUM in deviceID. It's preventing to show Bluetooth COM ports on the list
                if (name.Contains("(COM") && !deviceID.Contains("BTHENUM"))
                {
                    // This is a USB serial port, add it to the list
                    int startIndex = name.IndexOf("(COM") + 1;
                    int endIndex = name.IndexOf(")", startIndex);
                    string portName = name.Substring(startIndex, endIndex - startIndex);
                    usbPortNames.Add(portName);
                }
            }

            // Populate the ComboBox with the list of valid USB serial ports. If list is empty then write BRAK
            comboBoxSerialPortsList.Items.Clear();
            if (usbPortNames.Count > 0)
            {
                foreach (string portName in usbPortNames)
                {
                    comboBoxSerialPortsList.Items.Add(portName);
                }
            }
            else
            {
                comboBoxSerialPortsList.Items.Add("NONE");
            }
        }

        private void comboBoxSerialPortsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSerialPortsList.SelectedItem != null)
            {
                SelectedSerialPort = comboBoxSerialPortsList.SelectedItem.ToString();
            }
        }
        #endregion

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> spConnect = ConnectToSerialPort();
            bool isspConnectSuccessful = await spConnect;
            if (!isspConnectSuccessful)
            {

                return;
            }
            else
            {
            }

            Task<bool> ConnectToSerialPort()
            {
                Func<bool> action = () =>
                {
                    if (SelectedSerialPort != null && SelectedSerialPort != "NONE")
                    {
                        //Log("Łączenie z portem " + comboBoxSerialPortsList.Text);
                        _spc = new SerialPortController(SelectedSerialPort, 57600, Parity.None, 8, StopBits.One);
                        _spc.OpenPort();
                        Thread.Sleep(1000);
                        if (_spc.IsSerialPortOpen())
                        {
                            //Log("Połączono z portem " + SelectedSerialPort);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                };
                Task<bool> task = new Task<bool>(action);
                task.Start();
                return task;
            }
        }

        private void btnAddCard_Click(object sender, RoutedEventArgs e)
        {
            _spc.WriteToPort("dk\r");
        }
    }
}
