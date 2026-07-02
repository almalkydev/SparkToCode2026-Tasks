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


// task 4 - Voting Eligibility
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());
Console.Write("do you have a national ID? (yes/no):");
bool hasID = Console.ReadLine() == "yes";

if (age >= 18 && hasID)
    Console.WriteLine("You can vote");
else
    Console.WriteLine("You cannot vote");


// task 5 - grade evaluation

Console.Write("Enter your grade (A/B/C/D/F):");
char grade = char.Parse(Console.ReadLine());

switch (grade)
{
    case 'A': Console.WriteLine("Excellent"); break;
    case 'B': Console.WriteLine("Very Good"); break;
    case 'C': Console.WriteLine("Good"); break;
    case 'D': Console.WriteLine("Pass"); break;
    case 'F': Console.WriteLine("Fail"); break;
    default: Console.WriteLine("Invalid grade"); break;
}

