// Author: Norbert Pocztarek

using System;
using System.IO.Ports;

public class SerialPortController
{
    private SerialPort _serialPort;

    string _connectedSerialPortName;
    /// <summary>
    /// get connected COM port
    /// </summary>
    public string ConnectedSerialPortName
    {
        get { return _connectedSerialPortName; }
        set { _connectedSerialPortName = value; }
    }

    public SerialPortController(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
    {
        _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
    }

    public void OpenPort()
    {
        if (!_serialPort.IsOpen)
        {
            _serialPort.Open();
            ConnectedSerialPortName = _serialPort.PortName;
        }
    }

    public void ClosePort()
    {
        if (_serialPort.IsOpen)
        {
            _serialPort.Close();
        }
    }

    public void WriteToPort(string message)
    {
        if (_serialPort.IsOpen)
        {
            _serialPort.Write(message);
        }
    }

    public string ReadFromPort()
    {
        if (_serialPort.IsOpen)
        {
            return _serialPort.ReadExisting();
        }

        return string.Empty;
    }

    /// <summary>
    /// Return is Serial Port Open
    /// </summary>
    /// <returns></returns>
    public bool IsSerialPortOpen()
    {
        if (_serialPort.IsOpen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

