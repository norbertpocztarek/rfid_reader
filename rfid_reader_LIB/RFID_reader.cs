using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rfid_reader_LIB
{
    public partial class RFID_reader
    {
        // Client Objects
        private SerialPortController _spc;

        public RFID_reader(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _spc = new SerialPortController(portName, baudRate, parity, dataBits, stopBits);
        }

        public void ConnectToSerialPort()
        {
            _spc.OpenPort();
            Thread.Sleep(1000);
            if (_spc.IsSerialPortOpen())
            {
                //...
            }
            else
            {
                //...
            }
        }
    }
}

