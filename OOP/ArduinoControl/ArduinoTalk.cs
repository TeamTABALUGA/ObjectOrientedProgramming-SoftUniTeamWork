using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


public class ArduinoTalk
{

        private string portNumber;
        private int baudRate;
        
        public ArduinoTalk(string PortNumber, int BaudRate)
        {
            this.PortNumber = PortNumber;
            this.BaudRate = BaudRate;
            

        }
        public SerialPort CreatePort(string number, int rate)
        {
            SerialPort port = new SerialPort(number, rate);
            return port;
        }
        public string PortNumber
        {
            get
            {
                return this.portNumber;
            }
            set
            {
                string pat = @"COM+[0-9]+";
                Regex reg = new Regex(pat);
                Match mat = reg.Match(value);
                if (mat.Success == false)
                {
                    throw new ArgumentException("Invalid communication port number.");
                }
                else
                {
                    this.portNumber = value;
                }
            }

        }

        public int BaudRate
        {
            get
            {
                return this.baudRate;
            }
            set
            {
                if (value < 9600)
                {
                    throw new ArgumentException("Invalid Baud Rate argument. The Baud Rate must be greater or equal to 9600.");
                }
                else
                {
                    this.baudRate = value;
                }
            }
        }
        public override string ToString()
        {
            return string.Format("{0}", this.PortNumber);
        }
        public void OpenPort(SerialPort sp, int ReadTimeOut)
        {
            sp.Open();
            if (ReadTimeOut <= 0)
            {
                throw new ArgumentException("Invalid ReadTimeOut argument.");
            }
            else
            {
                sp.ReadTimeout = ReadTimeOut;
            }
        }
        public void PrintPortValue(SerialPort sp)
        {
            if (sp.IsOpen)
            {
                try
                {
                    Console.WriteLine("Value: {0}", sp.ReadByte());
                }
                catch(SystemException)
                {

                }
                
            }
        }
        public int ReadPortValue(SerialPort sp)
        {
            int i = 0;
            if (sp.IsOpen)
            {
                try
                {
                    i = sp.ReadByte();
                    
                }
                catch (SystemException)
                {

                }

            }
            return i;
        }
        public void ClosePort(SerialPort sp)
        {
            sp.Close();
        }
}
