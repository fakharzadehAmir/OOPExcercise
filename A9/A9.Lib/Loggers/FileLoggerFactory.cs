using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class FileLoggerFactory
    {
        public static FileLogger<LockedLogWriter> LockNullIncrementalCsv(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllIncrementalCsv(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockNullTimeCsv(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllTimeCsv(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockNullIncrementalConsole(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllIncrementalConsole(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockNullTimeConsole(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllTimeConsole(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockNullIncrementalXml(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllIncrementalXml(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockNullTimeXml(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<LockedLogWriter> LockAllTimeXml(string logDir , string logPrefix) =>
            new FileLogger<LockedLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullIncrementalCsv(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllIncrementalCsv(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullTimeCsv(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllTimeCsv(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                CsvLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullIncrementalConsole(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllIncrementalConsole(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullTimeConsole(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllTimeConsole(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                ConsoleLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,ConsoleLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullIncrementalXml(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllIncrementalXml(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new IncrementalLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentNullTimeXml(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.NullScrub(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);
        public static FileLogger<ConcurrentLogWriter> ConcurrentAllTimeXml(string logDir , string logPrefix) =>
            new FileLogger<ConcurrentLogWriter>(
                XmlLogFormatter.Instance,
                PrivacyScrubberFactory.ScrubAll(),
                new TimeBasedLogFileName($@"{logDir}",logPrefix,XmlLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

    }
}