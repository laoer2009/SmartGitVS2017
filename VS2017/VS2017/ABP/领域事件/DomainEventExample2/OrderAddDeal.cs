using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample2
{
    public class OrderAddDeal : IEventHandler<UserGenerator>
    {
        public void Handle(UserGenerator evt)
        {
            Console.WriteLine($"当前用户id{evt.UserId}");
        }
    }
}
