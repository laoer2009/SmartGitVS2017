using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample2
{
    /// <summary>
    /// 领域对象事件句柄
    /// 领域对象事件句柄是领域对象发生变化时，通知EventBus触发所有的事件句柄
    /// </summary>
    public class UserAddedEventHandlerSendEmail :IEventHandler<UserGenerator>
    {
        public void Handle(UserGenerator tEvent)
        {
            Console.WriteLine($"{0}的邮件已经发送", tEvent.UserId);
        }
    }
 
}
