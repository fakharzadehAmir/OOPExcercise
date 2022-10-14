using System;
using System.IO;
namespace A4
{
    public enum ObserverType { Create, Delete }
    public class DirectoryWatcher : IDisposable
    {
        public DirectoryWatcher(string dir)
        {
            this.Dir = dir;
            this.Watcher = new FileSystemWatcher(this.Dir) ;
            this.Watcher.Created += this.FileHasCreated ;
            this.Watcher.Deleted += this.PathHasDeleted ;
            this.Watcher.EnableRaisingEvents = true ;
        }
        private void PathHasDeleted(object obj, FileSystemEventArgs e)
        { if(this.RegisterCheckD != null) this.RegisterCheckD(e.FullPath) ; }

        private void FileHasCreated(object obj, FileSystemEventArgs e)
        { if(this.RegisterCheckC != null) this.RegisterCheckC(e.FullPath) ; }
        public void Register(Action<string> notifyMe, ObserverType create)
        {
            if( create == ObserverType.Create ) this.RegisterCheckC += notifyMe ;
            else this.RegisterCheckD += notifyMe ; 
        }
        public void Unregister(Action<string> notifyMe, ObserverType delete)
        {
            if( delete == ObserverType.Delete ) this.RegisterCheckD -= notifyMe ;
            else this.RegisterCheckC -= notifyMe ; 
        }
        public void Dispose() => this.Watcher.Dispose() ;
        public event Action<string> RegisterCheckC ;
        public event Action<string> RegisterCheckD ;
        private string Dir ;
        private FileSystemWatcher Watcher ;
    }
}