using System;
using System.IO;
using System.Linq;

namespace Logger
{
    public class WeekdayLogFileName : LogFileNamePolicy
    {
        public WeekdayLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt)
        { }

        public override string NextFileName() => 
            Path.Combine(LogDir, 
                $"{LogPrefix}_{this.ToDay()}.{LogExt}");

        public string ToDay()
        {
            string result = "";
            for(int i = 0 ; i < 3 ; i++)
                result += DateTime.Today.DayOfWeek.ToString()[i];
            return result;
        }

    }
}