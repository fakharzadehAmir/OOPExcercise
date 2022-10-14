using System;
using System.Threading;
namespace A4
{
    public class SingleReminderThread : ISingleReminder
    {
        public int Delay {get; private set;}
        public string Msg {get; private set;}
        public event Action<string> Reminder ;
        public SingleReminderThread(string msg, int delay) { this.Msg = msg ; this.Delay = delay ; }
        public void Start()
        { Thread ReiminderThread = new Thread( () => { Reminder(this.Msg) ; Thread.Sleep(this.Delay) ; } ) ; ReiminderThread.Start() ; }
    }
}