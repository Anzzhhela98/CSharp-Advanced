using Logger.Enumerators;
using Logger.Logger;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel report, string message)
        {
            if (this.ReportLevel <= report)
            {

                this.MessagesAppended++;
                this.logFile.Write(string.Format(this.Layout.Format, dateTime, report, message));
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
