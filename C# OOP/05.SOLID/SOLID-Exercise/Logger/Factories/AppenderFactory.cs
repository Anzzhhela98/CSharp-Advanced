using Logger.Appenders;
using Logger.Enumerators;
using Logger.Logger;
using System;
namespace Logger.Factories
{
    public class AppenderFactory
    {
        public static IAppender CreateAppender(string[] args)
        {
            IAppender appender = null;
            ILayout layout = layout = LayoutFactory.CreateLayout(args[1]);
            string type = args[0];
            ReportLevel reportLevel;

            if (args.Length == 2)
            {
                reportLevel = ReportLevel.Info;
            }
            else
            {
                Enum.TryParse<ReportLevel>(args[2], out reportLevel);
            }
            if (type == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
                appender.ReportLevel = reportLevel;
            }
            else if (type == "FileAppender")
            {
                ILogFile file = new LogFile();
                appender = new FileAppender(layout, file);
                appender.ReportLevel = reportLevel;
            }

            return appender;
        }
    }
}
