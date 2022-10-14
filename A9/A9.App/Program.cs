using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger clogger = new ConsoleLogger();

            FileLogger<LockedLogWriter> errorLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_error", CsvLogFormatter.Instance.FileExtention),
                LogLevels.ErrorOnly,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> allLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_all", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> uiLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_ui", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.UI),
                true);

            FileLogger<LockedLogWriter> phonenumberLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_phonenumber", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> clientLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new IncrementalLogFileName(@"c:\log", "A9_client", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.Create(LogSource.Client),
                true);

            FileLogger<LockedLogWriter> weekLogger = new FileLogger<LockedLogWriter>(
                CsvLogFormatter.Instance,
                new PrivacyScrubber(PhoneNumberScrubber.Instance, IDScrubber.Instance, FullNameScrubber.Instance),
                new WeekdayLogFileName(@"c:\log", "A9_week", CsvLogFormatter.Instance.FileExtention),
                LogLevels.All,
                LogSources.All,
                true);

            FileLogger<LockedLogWriter> FactoryallLogger = FileLoggerFactory.LockNullIncrementalXml(@"c:\log","A9_allFactoryMethod");

            Logger.Loggers.Add(errorLogger);
            Logger.Loggers.Add(allLogger);
            Logger.Loggers.Add(clogger);
            Logger.Loggers.Add(uiLogger);
            Logger.Loggers.Add(phonenumberLogger);
            Logger.Loggers.Add(clientLogger);
            Logger.Loggers.Add(weekLogger);
            Logger.Loggers.Add(FactoryallLogger);

            Logger.Instance.OnLog +=
            (LogEntry logEntry) =>
            {
                switch (logEntry.Level)
                {
                    case LogLevel.Debug :
                        Logger.Instance.CountOfLevels[LogLevel.Debug] += logEntry.Message.Length;
                        break;
                    case LogLevel.Error :
                        Logger.Instance.CountOfLevels[LogLevel.Error] += logEntry.Message.Length;
                        break;
                    case LogLevel.Info :
                        Logger.Instance.CountOfLevels[LogLevel.Info] += logEntry.Message.Length;
                        break;
                    case LogLevel.Warn :
                        Logger.Instance.CountOfLevels[LogLevel.Warn] += logEntry.Message.Length;
                        break;
                }
            };
            // Logger is set up and ready to use

            // درسته که همه این دستورات را پشت سر هم زدم
            // ولی شما فرض کنید که اینها در جاهای مختلف برنامه
            // زده شده...
            Logger.Instance.Debug(LogSource.UI, "Login button clicked");
            Logger.Instance.Debug(LogSource.Client, "User logged in", ("Name", "Mr. Ali Hassan"));
            Logger.Instance.Debug(LogSource.UI, "Add phone number cliecked");
            Logger.Instance.Info(LogSource.Client, "User number added", ("Name", "Mr. Ali Hassan"), ("PhoneNumber", "+9821 2543331"));
            Logger.Instance.Debug(LogSource.UI, "Add national ID cliecked");
            Logger.Instance.Warn(LogSource.Client, "User national ID added", ("ID", "232-12-1212"));
            Logger.Instance.Debug(LogSource.UI, "Display error to user");
            Logger.Instance.Error(LogSource.Client, "Unable to add user", ("ID", "232-12-1212"));

            foreach(var count in Logger.Instance.CountOfLevels)
                System.Console.WriteLine($"{count.Key} : {count.Value}");
        }
    }
}
//🟠🔵🟠🔵🟠🔵🟠🔵2-آ
/*
shebahat va tafavote line ha dar file va console
asli tain tafavot dar mask kardan etelate usere
ama dar file ha yekseri filter ha anjam shode masalan
loglevel haei ke marboot be errore ya oon haei ke baraye ui hast ro dar
yeki file jodagane minevise
ama shebahat dar formate gozareshe beine console va masalan file A9_all0000.log hastesh.
*/
//🟠🔵🟠🔵🟠🔵🟠🔵



//🟠🔵🟠🔵🟠🔵🟠🔵2-ب
/*
save shodane data ha ke batavajoh be factor method ha va incrementallog va timebased log soorat migirad
ama in ke chera too console ham print mikone be dalil oon generici hast ke ma mizanim
manzooram GaurdedWriter e FileLogger hast ke mogheye dispose shodan write line mikonan in data haro.
rastesh man khodamam az in system motmaen nistam ke bekhatereoverride Dispose in data ha too console print mishan
age shoma midoonid behem begid :) (?)
*/
//🟠🔵🟠🔵🟠🔵🟠🔵


//🟠🔵🟠🔵🟠🔵🟠🔵2-ج
/*
be dalil scrubber ha ke data haye privacy user ro mask mikonan ba estefade az regex
*/
//🟠🔵🟠🔵🟠🔵🟠🔵


//🟠🔵🟠🔵🟠🔵🟠🔵2-د
/*
be dalilein ke logLevel ha va ya LogSource ha filter bandi shodan va batavajoh be oon chizi ke
be functioneshoon midan oon file ro misazan va ba hamoon logLevel haye moshakhasi ke ma taein kardim tooye
yek file data haye marboot be oon logLevel ya souce ro daste bandi mikonan
masalan jahaei ke user natooneste etelaatesho be dorosti submit kone error khorde ke in error ha hame
too file A9_error... zakhire shodan
hala az koja barname bayad befahme ke faghat error haro too oon file save kone??
az hamoon parametr haei ke ma bala mogheye tarif kardane FileLogger ha neveshtim masalan
LogLevels.ErrorOnly
ya Logsources.Create(LogSource.Client) va ... .
*/
//🟠🔵🟠🔵🟠🔵🟠🔵