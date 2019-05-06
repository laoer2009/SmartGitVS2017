using System;

namespace DomainEventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            EventBus.Instance.Subscribe(new OrderAddedEventHandler_SendEmail());
            var entity = new OrderGeneratorEvent() { OrderID = 1 };
            Console.WriteLine("生成一个订单，单号为{0}", entity.OrderID);
            EventBus.Instance.Publish(entity);
            Console.ReadKey();
        }
    }
}
