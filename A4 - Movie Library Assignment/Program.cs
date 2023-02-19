using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace A4___Movie_Library_Assignment
{
    class Program
    {

        
        static void Main(string[] args)
        {
            
            MovieApp movieapp = new MovieApp();
  
            MenuGenerator(movieapp);

            /*IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddLogging(x=>x.AddConsole())
                .BuildServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            
            logger.Log(LogLevel.Information, ":)");*/
            

            
        }
        
        public static void MenuGenerator(MovieApp app)
        {

            char menuAnswer = 'a';

            while (menuAnswer != 'q')
            {

                app.createList();
                Console.WriteLine("Welcome to the Movie Library Menu");
                Console.WriteLine("1. List All Movies in the File");
                Console.WriteLine("2. Add Movie to the File");
                Console.WriteLine(".........................................");
                Console.Write("Please Enter Menu Number (q for quit): ");
                menuAnswer = Console.ReadLine().ToLower()[0];

                if (menuAnswer == '1')
                {
                    app.displayList();
                }

                else if (menuAnswer == '2')
                {
                    app.NewMovie();
                
                }
                else if (menuAnswer == 'q')
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Try again\n\n");
                }
                    
            }
        }
        
        public static void Exit()
        {
            
        }
        
    }
}   