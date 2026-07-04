//  TASK 1 - Countdown Timer 

            Console.Write("Enter starting number: ");
            int start = int.Parse(Console.ReadLine());

            for (int i = start; i >= 1; i--)
                Console.WriteLine(i);

            Console.WriteLine("Liftoff!");


            //TASK 2 - Sum of Numbers 1 to N 

            Console.Write("Enter a number N: ");
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= n; i++)
                sum += i;

            Console.WriteLine("Sum: " + sum);


            // TASK 3 - Multiplication Table

            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
                Console.WriteLine(num + " x " + i + " = " + (num * i));


            // TASK 4 - Password Retry 

            string correctPassword = "Spark2026";

            Console.Write("Enter password: ");
            string input = Console.ReadLine();

            while (input != correctPassword)
            {
                Console.WriteLine("Incorrect password, try again");
                Console.Write("Enter password: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Access Granted");


            //TASK 5 - Number Guessing 

            int secret = 42;
            int guess;
            int attempts = 0;

            do
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (guess > secret)
                    Console.WriteLine("Too high");
                else if (guess < secret)
                    Console.WriteLine("Too low");

            } while (guess != secret);

            Console.WriteLine("Correct! You got it in " + attempts + " attempts");


            // TASK 6 - Safe Division Calculator

            try
            {
                Console.Write("Enter first number: ");
                double a = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double b = double.Parse(Console.ReadLine());

                if (b == 0)
                    Console.WriteLine("Cannot divide by zero");
                else
                    Console.WriteLine("Result: " + (a / b));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please enter a valid number");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            //tASK 7 - Repeating Menu

            bool menuRunning = true;

            while (menuRunning)
            {
                Console.WriteLine("\n1) Say Hello");
                Console.WriteLine("2) Time-of-day Greeting");
                Console.WriteLine("3) Exit");
                Console.Write("Enter choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Hello!");
                            break;
                        case 2:
                            Console.WriteLine("Good day, hope you're doing well!");
                            break;
                        case 3:
                            menuRunning = false;
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option, try again");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, please enter a number");
                }
            }


            // TASK 8 - Sum of Even Numbers 

            Console.Write("Enter a number N: ");
            int evenN = int.Parse(Console.ReadLine());

            int evenSum = 0;
            for (int i = 1; i <= evenN; i++)
            {
                if (i % 2 == 0)
                    evenSum += i;
            }

            Console.WriteLine("Sum of even numbers: " + evenSum);


            //  TASK 9 - Validated Positive Number Input

            int validNumber = 0;
            bool isValid = false;

            do
            {
                try
                {
                    Console.Write("Enter a positive whole number: ");
                    validNumber = int.Parse(Console.ReadLine());

                    if (validNumber <= 0)
                        Console.WriteLine("Number must be positive, try again");
                    else
                        isValid = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input, please enter a whole number");
                }

            } while (!isValid);

            int validSum = 0;
            for (int i = 1; i <= validNumber; i++)
                validSum += i;

            Console.WriteLine("Sum from 1 to " + validNumber + " is: " + validSum);


            //TASK 10 - Simple ATM Simulation

            int correctPin = 1234;
            double balance = 100.000;
            int pinAttempts = 0;
            bool pinCorrect = false;

            while (pinAttempts < 3 && !pinCorrect)
            {
                try
                {
                    Console.Write("Enter PIN: ");
                    int pin = int.Parse(Console.ReadLine());
                    pinAttempts++;

                    if (pin == correctPin)
                        pinCorrect = true;
                    else
                        Console.WriteLine("Wrong PIN. Attempts left: " + (3 - pinAttempts));
                }
                catch
                {
                    pinAttempts++;
                    Console.WriteLine("Invalid input. Attempts left: " + (3 - pinAttempts));
                }
            }

            if (!pinCorrect)
            {
                Console.WriteLine("Card Blocked");
                return;
            }

            Console.WriteLine("Welcome!");

            bool atmRunning = true;
            while (atmRunning)
            {
                Console.WriteLine("\n1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3) Check Balance");
                Console.WriteLine("4) Exit");
                Console.Write("Enter choice: ");

                try
                {
                    int atmChoice = int.Parse(Console.ReadLine());

                    switch (atmChoice)
                    {
                        case 1:
                            try
                            {
                                Console.Write("Enter deposit amount: ");
                                double deposit = double.Parse(Console.ReadLine());

                                if (deposit <= 0)
                                    Console.WriteLine("Amount must be positive");
                                else
                                {
                                    balance += deposit;
                                    Console.WriteLine("New balance: " + balance + " OMR");
                                }
                            }
                            catch { Console.WriteLine("Invalid amount"); }
                            break;

                        case 2:
                            try
                            {
                                Console.Write("Enter withdrawal amount: ");
                                double withdraw = double.Parse(Console.ReadLine());

                                if (withdraw <= 0)
                                    Console.WriteLine("Amount must be positive");
                                else if (withdraw > balance)
                                    Console.WriteLine("Insufficient balance");
                                else
                                {
                                    balance -= withdraw;
                                    Console.WriteLine("New balance: " + balance + " OMR");
                                }
                            }
                            catch { Console.WriteLine("Invalid amount"); }
                            break;

                        case 3:
                            Console.WriteLine("Balance: " + balance + " OMR");
                            break;

                        case 4:
                            atmRunning = false;
                            Console.WriteLine("Thank you, goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, please enter a number");
                }
            }
        }
    }
}