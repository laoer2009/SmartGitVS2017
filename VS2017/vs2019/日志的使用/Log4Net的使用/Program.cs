using System;

namespace Log4Net的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.Info(".net core使用logger");
            LogHelper.Xmpplog.Info("xmpp");
            Console.WriteLine("Hello World!");
        }
    }
}
