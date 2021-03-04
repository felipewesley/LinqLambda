# LinqLambda

Project developed during the learning proccess about Linq and Lambda expressions.

### Features

- [x] Reading a CSV file with information from countries around the world;
- [x] "Translates" the CSV file line into a new class, called Country, that contains the following structure:
```c#
class Country {
    public string Acronym { get; set; }
    public string Name { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}
```
- [x] The main program make a collection of countries with **_HashSet Generics_** collection structure. This collection is:
```c#
HashSet<Country> countriesCollection;
```
- [x] Lambda expressions and Linq operators was be used to filter the countries by name, acronym, latitude or longitude references;
 ---
 # Example
 
 - Get name and acronym of countries where latitude greater than 0 (are in North Hemisphere);
 
 ```c#
 var northHemisphereCollection = countriesCollection
                                .Where(x => x.Latitude > 0)
                                .Select(x => new { x.Name, x.Acronym });
 ```
 
 - Get only the first letter of the country name where longitude lower than 0 (are in Western Hemisphere);
 ```c#
 var westernHemisphereCollection = countriesCollection
                                 .Where(x => x.Longitude < 0)
                                 .Select(x => new { FirstChar = x.Name[0] });
 ```
 ---
 ### That is all! :smiley:
