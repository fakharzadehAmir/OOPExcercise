using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class XsvLogFormatter : ILogFormatter
    {
        private char Seprator {get;set;}
        public XsvLogFormatter(char sep) { this.Seprator = sep; }
        public string Header => $"level{this.Seprator}date{this.Seprator}source{this.Seprator}threadId{this.Seprator}ProcessId{this.Seprator}message{this.Seprator}name:value pairs";

        public string Footer => string.Empty;

        public string FileExtention => "log";

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()}{this.Seprator}{entry.DateTime.ToString()}{this.Seprator}{entry.Source.ToString()}{this.Seprator}" +
                    $"{entry.ThreadId.ToString()}{this.Seprator}{entry.ProcessId}{this.Seprator}{entry.Message}{this.Seprator}" +
                    string.Join($"{this.Seprator}", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }
    }
}