using System;
using Logger.Enumerators;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
              : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel report, string message)
        {
            if (this.ReportLevel <= report)
            {
                this.MessagesAppended++;
                Console.WriteLine(Layout.Format, dateTime, report, message);
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
