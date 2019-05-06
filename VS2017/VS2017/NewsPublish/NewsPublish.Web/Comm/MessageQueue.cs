using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPublish.Web.Models;
namespace NewsPublish.Web
{
    public class MessageQueue
    {
        private static System.Timers.Timer timer = new System.Timers.Timer(5000);
        public static ChartModels CurrentChatModels = new ChartModels();

        static MessageQueue()
        {
            timer.AutoReset = false;
            timer.Enabled = false;
          //  timer.Elapsed += Timer_Elapsed;
         //   timer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var redisClient = new RedisHelper(2);
            //消息出列

            CurrentChatModels = redisClient.ListLeftPop<ChartModels>("MessageQuene");
        }
    }
}
