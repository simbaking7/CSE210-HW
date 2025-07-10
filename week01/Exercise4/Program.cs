using System;

class Program
{
    static void Main(string[] args)
    {
          List<double> numbers = new List<double>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            double input = Convert.ToDouble(Console.ReadLine());
            
            if (input == 0)
                break;
                
            numbers.Add(input);
        }

        if (numbers.Count > 0)
        {
            double sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");

            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");

            double max = numbers.Max();
            Console.WriteLine($"The largest number is: {max}");

            double? smallestPositive = numbers.Where(n => n > 0).Min();
            if (smallestPositive.HasValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("The sorted list is:");
            foreach (double num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}