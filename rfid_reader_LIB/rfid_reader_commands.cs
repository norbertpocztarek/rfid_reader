using System;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace rfid_reader_LIB
{
    public partial class RFID_reader
    {
        public void fillingReaderTestCards()
        {
            _spc.WriteToPort("bb\r");
        }

        public void saveMasterCardArch()
        {
            _spc.WriteToPort("km\r");
        }

        public void saveOrdinaryCardsArch()//writes 10 cards according to the frame 
        {
            _spc.WriteToPort("kz\r"); 
        }

        public void readReaderType()
        {
            _spc.WriteToPort("iu\r");
        }

        public void readReaderVersionFirmware()
        {
            _spc.WriteToPort("ve\r");
        }

        public void readPublicID()
        {
            _spc.WriteToPort("ir\r");
        }

        public void savePublicID()
        {
            _spc.WriteToPort("iw\r");
        }

        public void readUnixID()
        {
            _spc.WriteToPort("dr\r");
        }

        public void saveUnixID()
        {
            _spc.WriteToPort("dw\r");
        }

        public void readAllCards()
        {
            _spc.WriteToPort("er\r");
        }

        public void deleteOneCard()
        {
            _spc.WriteToPort("uk\r");
        }

        public void addOneCard()
        {
            _spc.WriteToPort("dk\r");
        }

        public void readOptions()
        {
            _spc.WriteToPort("or\r");
        }

        public void saveOptions()
        {
            _spc.WriteToPort("ow\r");
        }

        public void returnToFactorySettings()
        {
            _spc.WriteToPort("fw\r");
        }

        public void cleaningCardsMemory()
        {
            _spc.WriteToPort("cl\r");
        }
    }
}
