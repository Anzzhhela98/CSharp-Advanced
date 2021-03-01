using Logger.Enumerators;
namespace Logger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }
        public void Append(string dateTime, ReportLevel report, string message);
    }
}
