// Task 1 Personal Info Card
using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Sara";
        int age = 21;
        double height = 1.65;
        bool isStudent = true;

        Console.WriteLine("Info Card");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Height: " + height);
        Console.WriteLine("Student: " + isStudent);
    }
}

// Task 2 - Rectangle Calculation

Console.Write("Enter length: ");
double length = double.Parse(Console.ReadLine());

Console.Write("Enter width: ");
double width = double.Parse(Console.ReadLine());

Console.WriteLine("Area: " + (length * width));
Console.WriteLine("Perimeter: " + (2 * (length + width)));

// Task 3 - Rectangle Calculation

Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());

if (number % 2 == 0)
    Console.WriteLine("Even");
else
    Console.WriteLine("Odd");


