using System;
using dcmc.shared;
using Microsoft.Extensions.Configuration;

namespace dcmc.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfig = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var elastic = appConfig["elasticsearchURI"];
            Console.WriteLine($"ES {elastic}");


            Console.WriteLine("Starting Tasks - {0}", DateTime.Now);
            var stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            var nestie = new NestClient(elastic);

            //nestie.AddSeedData();

            var myUploader = new Uploader(nestie);
            myUploader.UploadDirectory(appConfig["RootPath"]);

            //nestie.GetVideoDocumentByID("somefakepath");
            
            stopWatch.Stop();
            Console.WriteLine("AllDone - {0}", DateTime.Now);
            Console.WriteLine(stopWatch.Elapsed);
            Console.Read();
        }
    }
}
