using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
namespace A4
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for(int i = 0; i<actions.Length ; i++)
                actions[i]();
            return sw.ElapsedMilliseconds;
        }
        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for(int i = 0; i<actions.Length ; i++)
                await Task.Run(actions[i]);
            return sw.ElapsedMilliseconds;
        }
        public static long CallParallel(params Action[] actions)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task[] tasks = new Task[actions.Length];
            for(int i = 0; i<actions.Length ; i++)
                tasks[i] = Task.Run(actions[i]);
            Task.WaitAll(tasks);
            return sw.ElapsedMilliseconds;
        }
        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Task[] tasks = new Task[actions.Length];
            for(int i = 0; i<actions.Length ; i++)
                tasks[i] = Task.Run(actions[i]);
            await Task.WhenAll(tasks);
            return sw.ElapsedMilliseconds;
        }
        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            object obj =  new object();
            Stopwatch sw = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();
            Parallel.ForEach(actions,(action)=>{
                tasks.Add(Task.Run(()=>{
                for(int i = 0 ; i<count ; i++)
                lock(obj)
                    action();
                }));
            });
            Task.WaitAll(tasks.ToArray());
            return sw.ElapsedMilliseconds;
        }
        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            object obj =  new object();
            Stopwatch sw = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();
            Parallel.ForEach(actions,(action)=>{
                tasks.Add(Task.Run(()=>{
                for(int i = 0 ; i<count ; i++)
                lock(obj)
                    action();
                }));
            });
            await Task.WhenAll(tasks.ToArray());
            return sw.ElapsedMilliseconds;
        }
    }
}