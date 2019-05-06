using System;

namespace DomainEventExample2
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.cnblogs.com/lori/p/3476703.html
            //https://www.cnblogs.com/tiancai/p/7266858.html

            EventBus.Instance.Subscribe(new UserAddedEventHandlerSendEmail());
            EventBus.Instance.Subscribe(new OrderAddDeal());

            var user = new UserGenerator() { UserId = Guid.NewGuid() };
            Console.WriteLine($"{user.UserId} 注册成功,");

            EventBus.Instance.Publish(user, CallBack);

        }
        public static void CallBack(UserGenerator userGenerator, bool result, Exception ex)
        {

        }
    }
}
