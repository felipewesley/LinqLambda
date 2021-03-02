using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using LinqLambda.Entity;

namespace LinqLambda
{
    class CsvController
    {
        public string FilePath { get; set; }

        public CsvController(string csvFilePath)
        {
            FilePath = csvFilePath;
        }

        public Dictionary<string, int> GetFormat()
        {
            /*
             * Default CSV file format:
             * 
             * country,latitude,longitude,name
             * 
            */

            return new Dictionary<string, int>
            {
                { "country", 0 },
                { "latitude", 1 },
                { "longitude", 2 },
                { "name", 3 }
            };
        }

        public IEnumerable<Country> GetCountries()
        {
            var listCounttries = new HashSet<Country>();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                var format = GetFormat();

                string s = sr.ReadLine().Split(',')[format["latitude"]];

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    try
                    {
                        string acronym = line[format["country"]];
                        string name = line[format["name"]].Replace("\"", "");
                        // Nullable because the latitude or longitidade can be empty (null)
                        double? latitude;
                        double? longitude;
                        
                        if (string.IsNullOrEmpty(line[format["latitude"]]))
                        { latitude = null; } 
                        else
                        { latitude = double.Parse(line[format["latitude"]], CultureInfo.InvariantCulture.NumberFormat); }
                        
                        if (string.IsNullOrEmpty(line[format["longitude"]]))
                        { longitude = null; } 
                        else
                        { longitude = double.Parse(line[format["longitude"]], CultureInfo.InvariantCulture); }
                        
                        // Add to countries list a new Country object with CSV data
                        listCounttries.Add(new Country()
                        {
                            Acronym = acronym,
                            Latitude = latitude,
                            Longitude = longitude,
                            Name = name
                        });

                    } catch (Exception e)
                    {
                        Console.WriteLine("A error has been ocurred: " + e.Message);
                    }
                }
            }
            return listCounttries;
        }
    }
}
