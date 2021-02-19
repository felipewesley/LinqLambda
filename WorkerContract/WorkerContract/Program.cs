using System;
using WorkerContract.Entities;
using WorkerContract.Entities.Enums;
using System.Globalization;

namespace WorkerContract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            showDivisor();

            Console.Write("Enter worker name: ");
            string name = Console.ReadLine();

            Console.Write("Enter worker level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Enter worker base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            showDivisor();

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int index = 1; index <= n; index++)
            {
                showDivisor();

                Console.WriteLine($"Enter #{ index } contract data: ");

                Console.Write("\tDate (dd/mm/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.Write("\tValue per hour: $ ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("\tDuration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                worker.AddContract(new HourContract(date, value, hours));
            }

            showDivisor();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string[] readedDate = Console.ReadLine().Split('/');

            int month = int.Parse(readedDate[0]);
            int year = int.Parse(readedDate[1]);

            WorkerData(worker, month, year);
        }

        static void WorkerData(Worker worker, int month, int year)
        {
            Console.WriteLine($"Name: { worker.Name }");
            Console.WriteLine($"Department: { worker.Department.Name }");
            Console.WriteLine($"Income for {month:F2}/{year}: $ { worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture) }");
        }

        static void showDivisor()
        {
            Console.WriteLine("------------------------------------");
        }
    }
}
