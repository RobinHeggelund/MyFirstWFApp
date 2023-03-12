using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWFApp
{
    internal class InstrumentLog
    {
        // Class body

        public string InstrumentScaledValue { get; set; }
        public DateTime LoggingDate { get; set; }

        public InstrumentLog(DateTime loggingDate, string instrumentScaledValue)
        {
            this.InstrumentScaledValue = instrumentScaledValue;
            this.LoggingDate = loggingDate;
        }

        public override string ToString()
        {
            
            return LoggingDate
           + ";" + InstrumentScaledValue;

           
        }



    }
}
