using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace iDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dict = new Dictionary<string, string>()
            //{
            //    { "name","jackyfei"},
            //    { "age","18"}
            //};

            //var builder = new ConfigurationBuilder()
            //    .AddInMemoryCollection(dict)
            //    .AddCommandLine(args);

            //var configuration = builder.Build();

            //Console.WriteLine($"name:{configuration["name"]}");
            //Console.WriteLine($"age:{configuration["age"]}");

            //1.初始化Builder
            var builder = new ConfigurationBuilder();

            //2.将Source添加到Builder
            builder.AddJsonFile("student.json", false, true);
            //builder.AddInMemoryCollection(dict)
            //builder.AddXmlFile("/path/tmp.xml")
            
            //3.调用Build
            var configuration = builder.Build();

            Console.WriteLine($"name:{configuration["name"]}");
            Console.WriteLine($"age:{configuration["age"]}");

            Console.WriteLine("Students");

            Console.WriteLine(configuration["Student:0:name"]);
            Console.WriteLine(configuration["Student:0:age"]);

            Console.WriteLine(configuration["Student:1:name"]);
            Console.WriteLine(configuration["Student:1:age"]);

            Console.ReadLine();
        }
    }
}
