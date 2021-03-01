using System;
using Logger.Appenders;
using System.Linq;

namespace Logger.Engine
{
    using Logger;
    public class Engine : IEngine
    {
        private IAppender[] appenders;
        private IAppender appender;
        private ILogger logger;
        public void Run()
        {
            int number = int.Parse(Console.ReadLine());
            this.appenders = new IAppender[number];
            for (int i = 0; i < number; i++)
            {
                string[] appendData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                this.appender = Factories.AppenderFactory.CreateAppender(appendData);
                this.appenders[i] = this.appender;
            }
            this.logger = new Logger(this.appenders);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] loggerArgs = input
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                PrintReportLevel(loggerArgs);
            }
            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
        private void PrintReportLevel(string[] args)
        {
            string reportType = args[0];
            string dateTime = args[1];
            string message = args[2];
            if (reportType == "INFO")
            {
                this.logger.Info(dateTime, message);
            }
            else if (reportType == "WARNING")
            {
                this.logger.Warning(dateTime, message);
            }
            else if (reportType == "ERROR")
            {
                this.logger.Error(dateTime, message);
            }
            else if (reportType == "CRITICAL")
            {
                this.logger.Critical(dateTime, message);
            }
            else if (reportType == "FATAL")
            {
                this.logger.Fatal(dateTime, message);
            }
        }
    }
}
