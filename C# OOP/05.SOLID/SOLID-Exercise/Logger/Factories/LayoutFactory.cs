using Logger.Layout;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public static ILayout CreateLayout(string layoutArgs)
        {
            ILayout layout = null;
            if (layoutArgs == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (layoutArgs == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            return layout;
        }
    }
}
