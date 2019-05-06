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


            var builder = new ConfigurationBuilder()
                .AddJsonFile("student.json");

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
