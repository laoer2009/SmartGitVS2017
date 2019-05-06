using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iConsole
{
    class Program
    {
        private static readonly IList<Func<RequestDelegate, RequestDelegate>> _mycomponents = 
            new List<Func<RequestDelegate, RequestDelegate>>();

        static void Main(string[] args)
        {
            //以下是Lambada表达式的简写
            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("PipeLine 1……");
                    return next.Invoke(context);
                };
            });

            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine("PipeLine 2……");
                    return next.Invoke(context);
                };
            });

            RequestDelegate PipeLine_end = context =>
            {
                Console.WriteLine("PipeLine_end……");
                return Task.CompletedTask;
            };

            foreach (var component in _mycomponents)
            {
                PipeLine_end = component(PipeLine_end);
            }

            PipeLine_end.Invoke(new HttpContext());


            Console.ReadLine();
        }

        public static void Use(Func<RequestDelegate,RequestDelegate> middleware)
        {
            _mycomponents.Add(middleware);
        }
    }
}
