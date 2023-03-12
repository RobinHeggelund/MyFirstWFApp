using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWFApp
{
    internal class Instrument
    {
        //Class body

        public DateTime RegisterDate { get; set; }

        private string sensorName; //field

        public string SensorName // property
        {

            set { sensorName = value; }
            get { return sensorName; }

        }

        public string SerialNumber { get; set; }
        public string SensorSerialNumber { get; set; }
        public string SignalType { get; set; }
        public string MeasureType { get; set; }
        public string Options { get; set; }
        public string Comment { get; set; }

        public double LRV { get; set; }
        public double URV { get; set; }

        public int AlarmFloor { get; set; }
        public int AlarmCeiling { get; set; }
        
        public string Unit { get; set; }

        public Instrument(DateTime registerDateTime,
                          string sensorName,
                          string serialNumber,
                          string signalType,
                          string measureType,
                          string options=null,
                          string comment=null,
                          double lrv = 0.0,
                          double urv = 0.0,
                          int alarmFloor = 0,
                          int alarmCeiling = 0,
                          string unit = null)
        {
            this.RegisterDate = registerDateTime;
            this.SensorName = sensorName;
            this.SerialNumber= serialNumber;
            this.SignalType = signalType;
            this.MeasureType = measureType;
            this.Options = options;
            this.Comment = comment;
            this.LRV = lrv;
            this.URV = urv;
            this.AlarmFloor = alarmFloor;
            this.AlarmCeiling = alarmCeiling;
            this.Unit = unit;


        }

        public double Span()
        {
            return URV - LRV;

        }

        public override string ToString()
        {
            return  RegisterDate
            + ";" + SensorName
            + ";" + SerialNumber
            + ";" + SignalType
            + ";" + MeasureType
            + ";" + Options
            + ";" + Comment
            + ";" + Convert.ToString(LRV, CultureInfo.InvariantCulture)
            + ";" + Convert.ToString(URV, CultureInfo.InvariantCulture)
            + ";" + AlarmFloor.ToString()
            + ";" + AlarmCeiling.ToString()
            + ";" + Unit;

        }



    }
}
