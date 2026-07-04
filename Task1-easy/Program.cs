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

// Task 6 - Temperature Converter
Console.Write("Enter temperature in Celsius: ");
double celsius = double.Parse(Console.ReadLine());

double fahrenheit = (celsius * 9 / 5) + 32;
Console.WriteLine("Fahrenheit: " + fahrenheit);

if (celsius < 10)
    Console.WriteLine("Cold");
else if (celsius <= 30)
    Console.WriteLine("Mild");
else
    Console.WriteLine("Hot");


// Task 7- Movie Ticket Price
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

if (age <= 12)
    Console.WriteLine("Children - 2.000 OMR");
else if (age <= 59)
    Console.WriteLine("Adult - 5.000 OMR");
else
    Console.WriteLine("Senior - 3.000 OMR");

//task 8 - Restaurant Discount
Console.Write("Enter your bill amount: ");
double bill = double.Parse(Console.ReadLine());

Console.Write("Are you a loyalty member? (yes/no): ");
bool isMember = Console.ReadLine() == "yes";

double discount = 0;

if (bill > 20 && isMember)
    discount = bill * 0.15;

Console.WriteLine("Original bill: " + bill);
Console.WriteLine("Discount: " + discount);
Console.WriteLine("Final amount: " + (bill - discount));


//task 9 -  Day Name
Console.Write("Enter a number (1-7): ");
int day = int.Parse(Console.ReadLine());

switch (day)
{
    case 1: Console.WriteLine("Sunday"); break;
    case 2: Console.WriteLine("Monday"); break;
    case 3: Console.WriteLine("Tuesday"); break;
    case 4: Console.WriteLine("Wednesday"); break;
    case 5: Console.WriteLine("Thursday"); break;
    case 6: Console.WriteLine("Friday"); break;
    case 7: Console.WriteLine("Saturday"); break;
    default: Console.WriteLine("Invalid day number"); break;
}

// task 10 - mini calculator
Console.Write("Enter first number: ");
double a = double.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
double b = double.Parse(Console.ReadLine());

Console.Write("Enter operator (+, -, *, /, %): ");
char op = char.Parse(Console.ReadLine());

switch (op)
{
    case '+': Console.WriteLine(a + b); break;
    case '-': Console.WriteLine(a - b); break;
    case '*': Console.WriteLine(a * b); break;
    case '/':
        if (b == 0) Console.WriteLine("Cannot divide by zero");
        else Console.WriteLine(a / b);
        break;
    case '%':
        if (b == 0) Console.WriteLine("Cannot divide by zero");
        else Console.WriteLine(a % b);
        break;
    default: Console.WriteLine("Invalid operator"); break;
}

//task 11 - Loan Eligibility

Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

Console.Write("Enter your monthly income: ");
double income = double.Parse(Console.ReadLine());

Console.Write("Do you have an existing loan? (yes/no): ");
bool hasLoan = Console.ReadLine() == "yes";

if (age < 21 || age > 60)
    Console.WriteLine("Not eligible age out of range");
else if (income < 400)
    Console.WriteLine("Not eligible income too low");
else if (hasLoan)
    Console.WriteLine("Not eligible you already have an existing loan");
else
    Console.WriteLine("Eligible for the loan");


//Task 12 - Shipping Cost
Console.Write("Enter region (A/B/C): ");
char region = char.Parse(Console.ReadLine());

Console.Write("Enter package weight (kg): ");
double weight = double.Parse(Console.ReadLine());

double baseCost = 0;
double extraCharge = 0;

switch (region)
{
    case 'A': baseCost = 1.000; break;
    case 'B': baseCost = 3.000; break;
    case 'C': baseCost = 7.000; break;
    default:
        Console.WriteLine("Invalid region");
        return;
}

if (weight > 10)
    extraCharge = 5.000;
else if (weight > 5)
    extraCharge = 2.000;

Console.WriteLine("Base cost: " + baseCost);
Console.WriteLine("Extra charge: " + extraCharge);
Console.WriteLine("Total: " + (baseCost + extraCharge));

//Task 13 - Triangle Classifier
Console.Write("Enter side 1: ");
double a = double.Parse(Console.ReadLine());

Console.Write("Enter side 2: ");
double b = double.Parse(Console.ReadLine());

Console.Write("Enter side 3: ");
double c = double.Parse(Console.ReadLine());

if (a + b <= c || a + c <= b || b + c <= a)
{
    Console.WriteLine("Not a valid triangle");
}
else if (a == b && b == c)
    Console.WriteLine("Equilateral");
else if (a == b || b == c || a == c)
    Console.WriteLine("Isosceles");
else
    Console.WriteLine("Scalene");

//task 14 Store Checkout\
Console.Write("Enter product code (1/2/3): ");
int code = int.Parse(Console.ReadLine());

double price = 0;

switch (code)
{
    case 1: price = 8.500; Console.WriteLine("Headphones"); break;
    case 2: price = 12.000; Console.WriteLine("Keyboard"); break;
    case 3: price = 5.000; Console.WriteLine("Mouse"); break;
    default:
        Console.WriteLine("Invalid product code");
        return;
}

Console.Write("Enter quantity: ");
int quantity = int.Parse(Console.ReadLine());

Console.Write("Do you have a coupon? (yes/no): ");
bool hasCoupon = Console.ReadLine() == "yes";

double subtotal = price * quantity;
double discount = 0;

if (hasCoupon && subtotal > 20)
    discount = subtotal * 0.10;

double afterDiscount = subtotal - discount;
double tax = afterDiscount * 0.05;
double total = afterDiscount + tax;

Console.WriteLine("Subtotal: " + subtotal);
Console.WriteLine("Discount: " + discount);
Console.WriteLine("Tax: " + tax);
Console.WriteLine("Total: " + total);

//Task 15 - University Admission
Console.Write("Enter program type (S/A): ");
char program = char.Parse(Console.ReadLine());

Console.Write("Enter GPA (out of 4.0): ");
double gpa = double.Parse(Console.ReadLine());

Console.Write("Enter exam score (out of 100): ");
int score = int.Parse(Console.ReadLine());

Console.Write("Do you have extracurricular achievements? (yes/no): ");
bool hasExtra = Console.ReadLine() == "yes";

bool meetsRequirements = false;

switch (program)
{
    case 'S':
        meetsRequirements = gpa >= 3.0 && score >= 75;
        Console.WriteLine("Program: Science");
        break;
    case 'A':
        meetsRequirements = gpa >= 2.5 && score >= 60;
        Console.WriteLine("Program: Arts");
        break;
    default:
        Console.WriteLine("Invalid program type");
        return;
}

if (meetsRequirements)
    Console.WriteLine("Admitted");
else if (hasExtra)
    Console.WriteLine("Conditionally Admitted");
else
    Console.WriteLine("Not Admitted");