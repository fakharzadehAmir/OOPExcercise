using System;
using System.Threading;
namespace A4
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public int Delay { get; set;}
        public string Msg{ get; set;}
        public event Action<string> Reminder ;
        public SingleReminderThreadPool(string msg, int delay) { this.Msg = msg ; this.Delay = delay ; }
        public void Start() => ThreadPool.QueueUserWorkItem( (obj) => { Thread.Sleep(this.Delay) ; Reminder(this.Msg) ; } ) ;
    }
}