using Logger.Appenders;
using Logger.Enumerators;
namespace Logger.Logger
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appender)
        {
            this.Appenders = appender;
        }

        public IAppender[] Appenders { get; }


        public void Critical(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.Critical, fileApender);
        }

        public void Error(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.Error, fileApender);
        }

        public void Fatal(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.Fatal, fileApender);
        }

        public void Info(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.Info, fileApender);
        }

        public void Warning(string dateTime, string fileApender)
        {
            Append(dateTime, ReportLevel.Warning, fileApender);
        }
        private void Append(string dateTime, ReportLevel reportLevel, string fileApender)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(dateTime, reportLevel, fileApender);
            }
        }
    }
}
