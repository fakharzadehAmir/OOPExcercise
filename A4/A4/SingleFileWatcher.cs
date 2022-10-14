using System;
using System.IO;
namespace A4
{
    public class SingleFileWatcher : IDisposable
    {
        public SingleFileWatcher(string fileName)
        {
            this.FileName = fileName ;
            this.Watcher = new FileSystemWatcher(Path.GetDirectoryName(this.FileName),Path.GetFileName(this.FileName)) ;
//                            1-The directory to monitor, in standard  2-The type of files to watch.
            this.Watcher.Changed += this.PathHasChanged ;// Run event delegate (check event is not null) 
            this.Watcher.EnableRaisingEvents = true;// Call our events 
        }
        public void Register(Action notifyPlus) => this.RegisterCheck += notifyPlus ;
        public void Unregister(Action notifyMinus) => this.RegisterCheck -= notifyMinus ;
        public void PathHasChanged(object obj, FileSystemEventArgs e) { if(this.RegisterCheck!=null) this.RegisterCheck() ; } 
        public void Dispose() => this.Watcher.Dispose() ;
        private FileSystemWatcher Watcher = null ;
        public string FileName { get; private set; }
        public event Action RegisterCheck = null ;
    }
}