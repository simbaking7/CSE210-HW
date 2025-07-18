using System;

class Program
{
    static void Main(string[] args)
    {
      
        // all constructors and display representations
        Fraction f1 = new Fraction();       // 1/1
        Fraction f2 = new Fraction(5);      // 5/1
        Fraction f3 = new Fraction(3, 4);   // 3/4
        Fraction f4 = new Fraction(1, 3);   // 1/3

        // Display initial fractions and decimal values
        Console.WriteLine($"f1: {f1.GetFractionString()} = {f1.GetDecimalValue()}");
        Console.WriteLine($"f2: {f2.GetFractionString()} = {f2.GetDecimalValue()}");
        Console.WriteLine($"f3: {f3.GetFractionString()} = {f3.GetDecimalValue()}");
        Console.WriteLine($"f4: {f4.GetFractionString()} = {f4.GetDecimalValue()}");

        // setters and getters with new values
        f1.SetTop(3);
        f1.SetBottom(4);
        f2.SetTop(2);
        f2.SetBottom(3);
        f3.SetTop(5);
        f3.SetBottom(6);

        Console.WriteLine($"\nAfter changes:");
        Console.WriteLine($"f1: {f1.GetFractionString()} = {f1.GetDecimalValue()}"); 
        Console.WriteLine($"f2: {f2.GetFractionString()} = {f2.GetDecimalValue()}"); 
        Console.WriteLine($"f3: {f3.GetFractionString()} = {f3.GetDecimalValue()}"); 
    
        Console.WriteLine("Hello World! This is the Fractions Project.");
    }
}