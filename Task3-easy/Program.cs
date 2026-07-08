using System;

class Program
{
    static void Main()
    {
        //   TASK 1 - Personalized Welcome Function  
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        PrintWelcome(userName);

        //   TASK 2 - Square Number Function  
        Console.Write("\nEnter a number to square: ");
        int numToSquare = Convert.ToInt32(Console.ReadLine());
        int squareResult = Square(numToSquare);
        Console.WriteLine("Square of " + numToSquare + " is " + squareResult);

        //   TASK 3 - Celsius to Fahrenheit Function  
        Console.Write("\nEnter temperature in Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());
        double fahrenheit = CelsiusToFahrenheit(celsius);
        Console.WriteLine(celsius + " C is " + fahrenheit + " F");

        //   TASK 4 - Fixed Menu Display Function  
        Console.WriteLine();
        DisplayMenu();

        //   TASK 5 - Even or Odd Function  
        Console.Write("\nEnter a number to check Even/Odd: ");
        int evenOddNum = Convert.ToInt32(Console.ReadLine());
        if (IsEven(evenOddNum))
        {
            Console.WriteLine(evenOddNum + " is Even");
        }
        else
        {
            Console.WriteLine(evenOddNum + " is Odd");
        }

        //   TASK 6 - Rectangle Area & Perimeter Functions  
        Console.Write("\nEnter rectangle length: ");
        double rectLength = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter rectangle width: ");
        double rectWidth = Convert.ToDouble(Console.ReadLine());
        double rectArea = CalculateArea(rectLength, rectWidth);
        double rectPerimeter = CalculatePerimeter(rectLength, rectWidth);
        Console.WriteLine("Rectangle Area: " + rectArea);
        Console.WriteLine("Rectangle Perimeter: " + rectPerimeter);

        //   TASK 7 - Grade Letter Function  
        Console.Write("\nEnter a score (0-100) for grade letter: ");
        int score = Convert.ToInt32(Console.ReadLine());
        string gradeLetter = GetGradeLetter(score);
        Console.WriteLine("Grade: " + gradeLetter);

        //   TASK 8 - Countdown Function  
        Console.Write("\nEnter a starting number for countdown: ");
        int countdownStart = Convert.ToInt32(Console.ReadLine());
        Countdown(countdownStart);

        //   TASK 9 - Overloaded Multiply Function  
        Console.WriteLine();
        int mInt1 = 4, mInt2 = 5, mInt3 = 3;
        double mDouble1 = 2.5, mDouble2 = 4.0;

        int intResult = Multiply(mInt1, mInt2);
        Console.WriteLine("Multiply(int, int) -> " + mInt1 + " * " + mInt2 + " = " + intResult);

        double doubleResult = Multiply(mDouble1, mDouble2);
        Console.WriteLine("Multiply(double, double) -> " + mDouble1 + " * " + mDouble2 + " = " + doubleResult);

        int tripleIntResult = Multiply(mInt1, mInt2, mInt3);
        Console.WriteLine("Multiply(int, int, int) -> " + mInt1 + " * " + mInt2 + " * " + mInt3 + " = " + tripleIntResult);

        //   TASK 10 - Overloaded Area Calculator  
        Console.Write("\nCalculate area for (1) Square or (2) Rectangle? Enter 1 or 2: ");
        string shapeChoice = Console.ReadLine();

        if (shapeChoice == "1")
        {
            Console.Write("Enter side of square: ");
            double side = Convert.ToDouble(Console.ReadLine());
            double squareArea = CalculateArea(side);
            Console.WriteLine("Square Area: " + squareArea);
        }
        else if (shapeChoice == "2")
        {
            Console.Write("Enter length: ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter width: ");
            double width = Convert.ToDouble(Console.ReadLine());
            double rectangleArea = CalculateArea(length, width);
            Console.WriteLine("Rectangle Area: " + rectangleArea);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        // TASK 11 - Function-Based Calculator
        Console.WriteLine("\n Function-Based Calculator");
        bool keepCalculating = true;

        while (keepCalculating)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1 Add");
            Console.WriteLine("2 Subtract");
            Console.WriteLine("3 Multiply");
            Console.WriteLine("4 Divide");
            Console.WriteLine("5 Exit Calculator");
            Console.Write("Enter choice: ");
            string calcChoice = Console.ReadLine();

            if (calcChoice == "5")
            {
                keepCalculating = false;
            }
            else
            {
                switch (calcChoice)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        Console.Write("Enter first number: ");
                        double num1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        double num2 = Convert.ToDouble(Console.ReadLine());

                        switch (calcChoice)
                        {
                            case "1":
                                DisplayResult("Addition", Add(num1, num2));
                                break;
                            case "2":
                                DisplayResult("Subtraction", Subtract(num1, num2));
                                break;
                            case "3":
                                DisplayResult("Multiplication", MultiplyNumbers(num1, num2));
                                break;
                            case "4":
                                DisplayResult("Division", DivideNumbers(num1, num2));
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        //   TASK 12 - Student Report Card Generator  
        Console.WriteLine("\n--- Student Report Card Generator ---");
        Console.Write("Enter student's name: ");
        string studentName = Console.ReadLine();
        Console.Write("Enter score for subject 1: ");
        double score1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter score for subject 2: ");
        double score2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter score for subject 3: ");
        double score3 = Convert.ToDouble(Console.ReadLine());

        double average = CalculateAverage(score1, score2, score3);
        string reportGrade = GetGradeLetter(average);
        PrintReportCard(studentName, average, reportGrade);

        Console.WriteLine("\nAll tasks completed. Press any key to exit.");
        Console.ReadKey();
    }

    //   TASK 1 FUNCTION  
    static void PrintWelcome(string name)
    {
        Console.WriteLine("Welcome, " + name + "! We're glad to have you here.");
    }

    //   TASK 2 FUNCTION  
    static int Square(int number)
    {
        return number * number;
    }

    //   TASK 3 FUNCTION  
    static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    //   TASK 4 FUNCTION  
    static void DisplayMenu()
    {
        Console.WriteLine(" MENU ");
        Console.WriteLine("1) Start");
        Console.WriteLine("2) Help");
        Console.WriteLine("3) Exit");
    }

    //   TASK 5 FUNCTION  
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    //   TASK 6 FUNCTION  
    static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    static double CalculatePerimeter(double length, double width)
    {
        return 2 * (length + width);
    }

    //   TASK 7 FUNCTION  
    static string GetGradeLetter(int score)
    {
        if (score >= 90)
        {
            return "A";
        }
        else if (score >= 80)
        {
            return "B";
        }
        else if (score >= 70)
        {
            return "C";
        }
        else if (score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }

    //   TASK 8 FUNCTION  
    static void Countdown(int start)
    {
        for (int i = start; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }

    //   TASK 9 FUNCTIONS 
    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static int Multiply(int a, int b, int c)
    {
        return a * b * c;
    }

    //   TASK 10 FUNCTION
    static double CalculateArea(double side)
    {
        return side * side;
    }

    //   TASK 11 FUNCTIONS  
    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }

    static double DivideNumbers(double a, double b)
    {
        try
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero. Returning 0.");
            return 0;
        }
    }

    static void DisplayResult(string operation, double result)
    {
        Console.WriteLine("Operation: " + operation);
        Console.WriteLine("Result: " + result);
    }

    //   TASK 12 FUNCTIONS  
    static double CalculateAverage(double score1, double score2, double score3)
    {
        return (score1 + score2 + score3) / 3;
    }

    static string GetGradeLetter(double average)
    {
        if (average >= 90)
        {
            return "A";
        }
        else if (average >= 80)
        {
            return "B";
        }
        else if (average >= 70)
        {
            return "C";
        }
        else if (average >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }

    static void PrintReportCard(string name, double average, string grade)
    {
        Console.WriteLine(" REPORT CARD ");
        Console.WriteLine("Student Name : " + name);
        Console.WriteLine("Average Score: " + average);
        Console.WriteLine("Final Grade  : " + grade);
        Console.WriteLine(" ");
    }
}