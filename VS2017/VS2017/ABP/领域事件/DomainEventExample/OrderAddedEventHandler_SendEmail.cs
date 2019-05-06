using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample
{
    /// <summary>
    /// 一个为OrderGeneratorEvent工作的领域事件，它用来为客户发邮件
    /// 某个领域对象的事件：它是一个事件处理类，它实现了IEventHandler，它所处理的事情需要在Handle里去完成
    /// </summary>
    public class OrderAddedEventHandler_SendEmail : IEventHandler<OrderGeneratorEvent>
    {
        public void Handle(OrderGeneratorEvent evt)
        {
            Console.WriteLine($"Order_Number{0},Send a Email", evt.OrderID);
        }
    }
}
