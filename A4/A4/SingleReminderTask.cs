using System;
using System.Threading;
using System.Threading.Tasks;
namespace A4
{
    public class SingleReminderTask : ISingleReminder
    
    {
        public int Delay { get; set; }
        public string Msg{ get; set; }
        public event Action<string> Reminder ;
        public SingleReminderTask(string msg, int delay) { this.Msg = msg ; this.Delay = delay ; }
        public void Start()
        { Task ReiminderTask = new Task( () =>{ Task.Delay(this.Delay).Wait() ; Reminder(this.Msg) ; } ) ; ReiminderTask.Start() ; }
    }
}