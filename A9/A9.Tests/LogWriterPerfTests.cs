using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Logger.Tests
{
    [TestClass()]
    public class LogWriterPerfTests
    {
        [TestMethod()]
        public void LockedLogWriterPerfTest()
        {
            var time = PerfTest<LockedLogWriter>(threadCount: 10, linePerThread:100);
            System.Console.WriteLine(time);
        }

        [TestMethod()]
        public void ConcurrentLogWriterPerfTest()
        {
            var time = PerfTest<ConcurrentLogWriter>(threadCount: 10, linePerThread: 100);
            System.Console.WriteLine(time);
        }
        [TestMethod()]
        public void LockedQueueLogWriterPerfTest()
        {
            var time = PerfTest<LockedQueueLogWriter>(threadCount: 10, linePerThread: 100);
            System.Console.WriteLine(time);
        }

        //🟠🔵🟠🔵

        //in test baraye in khata midad ke baraye file NoLockWriter.cs 
        //functioni ke WriteLine override shode ba gozashtan yek lock dg be error nemikhore ama 
        //dalile error in bude thread haye mokhtalef moghei ke WriteLine mikarde hamzaman az object
        //this.Writer estefade mikardan ke too yr file benevisan ke ghati mikardan va 
        //be error mikhord va ma mitoonestim ba gozashtan yek
        //lock balaye this.Writer.writLine (...)
        //error marboote ro bardarim ke too file LockLogWriter.cs ham anjam shode 
        //ta thread ha be tartib az ye object estefade konan va hamzaman baham run nashan ke dobare be error bokhore.

        //🟠🔵🟠🔵

        // [TestMethod()]
        // public void NoLockPerfTest()
        // {
        //     var time = PerfTest<NoLockLogWriter>(threadCount: 25, linePerThread: 1000);
        // }

        private string PerfTest<_LogWriter>(int threadCount, int linePerThread)
            where _LogWriter: GuardedLogWriter, new()
        {
            string logDir = Path.GetTempFileName();
            File.Delete(logDir);
            string logPrefix = "sauleh_all";
            string time = string.Empty;
            using (FileLogger<_LogWriter> logger = new FileLogger<_LogWriter>(
                    XmlLogFormatter.Instance,
                    new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                    new TimeBasedLogFileName(logDir, logPrefix, XmlLogFormatter.Instance.FileExtention),
                    LogLevels.All,
                    LogSources.All,
                    false))
            {
                var threads = Enumerable.Range(0, threadCount)
                                        .Select(n => new Thread(
                                            new ThreadStart(() => LogRandomMessages(linePerThread, logger))))
                                        .ToList();

                Stopwatch sw = Stopwatch.StartNew();
                threads.ForEach(t => t.Start());
                threads.ForEach(t => t.Join());
                sw.Stop();

                time = sw.Elapsed.TotalSeconds.ToString();
            }

            int actualLogLines = CountLogLines(logDir, pattern: $"{logPrefix}*.{XmlLogFormatter.Instance.FileExtention}");

            Assert.AreEqual(linePerThread * threadCount + 2, actualLogLines); // plus 2 for header and footer

            return time;
        }

        private int CountLogLines(string logDir, string pattern)
        {
            return Directory.GetFiles(logDir, pattern).Sum(f => File.ReadAllLines(f).Length);
        }

        private void LogRandomMessages(int count, ILogger logger)
        {
            for (int i=0; i<count; i++)
            {
                LogEntry logEntry = new LogEntry(LogSource.Client, LogLevel.Debug,
                    $"student {i} created", ("FirstName", $"Pegah_{i}"), ("LastName", $"Ayati_{i}"));
                logger.Log(logEntry);
            }
        }
    }
}


//🟠🔵🟠🔵🟠🔵🟠🔵
//jadvale tafavote zaman
/*

| Tests           | Thread : 1 | Thread : 2 | Thread : 5 | Thread : 10 | Thread : 20 | Thread : 50 | Thread : 100 |
----------------------------------------------------------------------------------------------------------------
|LockedLog       |  0.2048119 |  0.237152  | 0.3648182  | 0.6201982  |  1.2324234  |  3.1259762  |  7.3475971   |
---------------------------------------------------------------------------------------------------------------
|ConcurrentLog  | 0.1944406  | 0.2119083  | 0.3347516  | 0.6464775  |  1.2376747  |  3.751563   |  10.0925196  |
--------------------------------------------------------------------------------------------------------------
|LockedQueueLog| 0.1936164  | 0.2109066  | 0.3445061  | 0.6192441  |  1.2526186  |  3.6719489  |   9.970501   |
--------------------------------------------------------------------------------------------------------------

*/
//🟠🔵🟠🔵🟠🔵🟠🔵



//🟠🔵🟠🔵🟠🔵🟠🔵
/*
    natijei ke man gereftam in bude ke karaeie LockedLog va Concurrent kheili shabihe hame vali vaghti ke threadcount ha ziad
    mishan locked zamane kamtari masraf mishe vali cpu ro bishtar dargir mikone ama concurrent daghighan barakse
    va man haghighatan natoonestam befahmam kodoom behine tare :) ama ostad too grooh goftan ke concurrent behine tare too thread haye 
    bishtar choon zamanesh kamtare vali man harcheghadr run test kardam be in natije natooestam beresam va bara khodam soale (?)
    baraye LockedQueue ham amar taghriban beyne ConcurentLog  va LockedLog bud ke too jadval sabt shod.
*/
//🟠🔵🟠🔵🟠🔵🟠🔵