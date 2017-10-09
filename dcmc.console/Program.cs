using System;
using dcmc.shared;

namespace dcmc.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Tasks");
            var nestie = new NestClient("http://beast2:9200");
            nestie.AddSeedData();
            Console.WriteLine("AllDone");
        }
    }
}
