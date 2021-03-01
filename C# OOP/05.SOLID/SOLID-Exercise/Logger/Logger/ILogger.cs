
using Logger.Appenders;

namespace Logger.Logger
{
    public interface ILogger
    {
        public IAppender[] Appenders { get; }
        public void Info(string dateTime, string fileApender);
        public void Warning(string dateTime, string fileApender);
        public void Error(string dateTime, string fileApender);
        public void Critical(string dateTime, string fileApender);
        public void Fatal(string dateTime, string fileApender);
    }
}
