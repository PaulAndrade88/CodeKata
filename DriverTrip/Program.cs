using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using DriverTrip.Command;

namespace DriverTrip
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceCollection serviceCollection = new ServiceCollection();
            InitialConfiguration.ConfigureServices(serviceCollection);


            string[] content = File.ReadAllLines(InitialConfiguration.configuration.GetSection("InputFile").Value);

            Requester _requester = new Requester();

            string[] report = _requester.GetReport(content);

            for (int i = 0; i < report.Length; i++)
                Console.WriteLine(report[i]);

            Console.ReadLine();
        }

        
    }
}
