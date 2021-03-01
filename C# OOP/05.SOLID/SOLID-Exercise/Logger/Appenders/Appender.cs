using Logger.Enumerators;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }
        protected int MessagesAppended { get; set; }

        public abstract void Append(string dateTime, ReportLevel report, string message);
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesAppended}";
        }
    }
}