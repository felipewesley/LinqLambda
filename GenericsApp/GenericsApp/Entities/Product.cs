using System;
using System.Globalization;

namespace GenericsApp.Entities
{
    class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string nome, double value)
        {
            Name = nome;
            Price = value;
        }

        public Product(string csvFormatInput)
        {
            string[] s = csvFormatInput.Split(',');

            Name = s[0];
            Price = double.Parse(s[1], CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Product))
            {
                throw new ArgumentException("The argument need be a Product");
            }
            Product otherProd = (Product)obj;

            return Price.CompareTo(otherProd.Price);
        }

        public override string ToString()
        {
            return $"{ Name }, $ { Price.ToString("F2", CultureInfo.InvariantCulture) }";
        }
    }
}
