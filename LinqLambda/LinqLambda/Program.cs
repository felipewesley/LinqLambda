using System;
using System.Linq;
using System.Collections.Generic;
using LinqLambda.Entity;

namespace LinqLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\workspace\learningCSharp\LinqLambda\LinqLambda\Data\countries.csv";
            
            CsvController controller = new CsvController(path);

            var countries = controller.GetCountries();

            /**
             * Help for manipulate this code and lambda expressions
             * 
             * North hemisphere: Latitude > 0
             * South hemisphere: Latitude < 0
             * East hemisphere (Oriental): Longitude > 0
             * West hemisphere (Occidental): Longitude < 0
             * 
             */

            Console.WriteLine("\n\tCountries that starting with 'B' letter and have latitude greater than 15: \n");

            var newCollection = countries.
                                Where(x => x.Name[0] == 'B' && x.Latitude > 1).
                                Select(x => new { CountryLabel = x.Acronym + " - " + x.Name, x.Latitude}).
                                ToList();

            newCollection.ForEach(x => 
                                Console.WriteLine("\t" + x.CountryLabel + " - L: " + x.Latitude));

            PressEnterToContinue();

            Console.WriteLine("\n\tOccidental countries of south hemisphere: \n");

            var southCountries = countries.
                                Where(x => x.Latitude < 0 && x.Longitude < 0).
                                Select(x => new { CountryLabel = x.Acronym + " - " + x.Name }).
                                ToList();

            southCountries.ForEach(x =>
                                Console.WriteLine("\t" + x.CountryLabel));

            PressEnterToContinue();
        }

        public static void PressEnterToContinue()
        {
            Console.Write("\n\tPress 'Enter' to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
