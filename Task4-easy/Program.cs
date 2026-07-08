using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //   Task 1 - Fixed Grades Array  
        Console.WriteLine("--- Task 1 ---");
        int[] grades = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            grades[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Grades entered:");
        foreach (int grade in grades)
        {
            Console.WriteLine(grade);
        }

        //   Task 2 - Dynamic To-Do List  
        Console.WriteLine("\n--- Task 2 ---");
        List<string> todoList = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter task " + (i + 1) + ": ");
            todoList.Add(Console.ReadLine());
        }

        Console.WriteLine("To-Do List:");
        int taskNumber = 1;
        foreach (string task in todoList)
        {
            Console.WriteLine(taskNumber + ". " + task);
            taskNumber++;
        }

        //   Task 3 - Browsing History Stack  
        Console.WriteLine("\n--- Task 3 ---");
        Stack<string> history = new Stack<string>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter URL " + (i + 1) + ": ");
            history.Push(Console.ReadLine());
        }

        // Simulate pressing the back button once
        history.Pop();

        Console.WriteLine("Went back. Currently on: " + history.Peek());

        //   Task 4 - Customer Service Queue  
        Console.WriteLine("\n--- Task 4 ---");
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter customer name " + (i + 1) + ": ");
            queue.Enqueue(Console.ReadLine());
        }

        // Serve the first customer
        string servedCustomer = queue.Dequeue();
        Console.WriteLine("Served customer: " + servedCustomer);

        //   Task 5 - Array Grade Range  
        Console.WriteLine("\n--- Task 5 ---");
        int[] rangeGrades = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            rangeGrades[i] = Convert.ToInt32(Console.ReadLine());
        }

        Array.Sort(rangeGrades);

        int sum = 0;
        foreach (int g in rangeGrades)
        {
            sum += g;
        }
        double average = (double)sum / 5;

        Console.WriteLine("Lowest grade: " + rangeGrades[0]); // First after sorted
        Console.WriteLine("Highest grade: " + rangeGrades[4]); // Last after sorted
        Console.WriteLine("Average grade: " + average);

        //  Task 6 - Filtered Shopping List
        Console.WriteLine("\n--- Task 6 ---");
        List<string> shoppingList = new List<string>();
        while (true)
        {
            Console.Write("Enter a shopping item (or type 'done' to stop): ");
            string item = Console.ReadLine();
            if (item == "done")
            {
                break;
            }
            shoppingList.Add(item);
        }

        Console.WriteLine("List before removal:");
        foreach (string item in shoppingList)
        {
            Console.WriteLine("- " + item);
        }

        Console.Write("Enter item name to remove: ");
        string itemToRemove = Console.ReadLine();
        shoppingList.Remove(itemToRemove);

        Console.WriteLine("Final shopping list:");
        foreach (string item in shoppingList)
        {
            Console.WriteLine("- " + item);
        }

        //   Task 7 - High Score Podium  
        Console.WriteLine("\n--- Task 7 ---");
        List<int> gameScores = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter a game score: ");
            gameScores.Add(Convert.ToInt32(Console.ReadLine()));
        }

        gameScores.Sort();
        gameScores.Reverse();

        Console.WriteLine("1st place: " + gameScores[0]);
        Console.WriteLine("2nd place: " + gameScores[1]);
        Console.WriteLine("3rd place: " + gameScores[2]);

        //   Task 8 - Undo Last Action  
        Console.WriteLine("\n--- Task 8 ---");
        Stack<string> actions = new Stack<string>();
        while (true)
        {
            Console.Write("Enter an action (or type 'stop'): ");
            string action = Console.ReadLine();
            if (action == "stop")
            {
                break;
            }
            actions.Push(action);
        }

        // Simulate pressing undo twice
        Console.WriteLine("Undone: " + actions.Pop());
        Console.WriteLine("Undone: " + actions.Pop());

        Console.WriteLine("Remaining actions on stack:");
        foreach (string remainingAction in actions)
        {
            Console.WriteLine("- " + remainingAction);
        }

        //   Task 9 - Grade Analyzer with Functions  
        Console.WriteLine("\n--- Task 9 ---");
        Console.Write("How many grades do you want to enter? ");
        int numGrades = Convert.ToInt32(Console.ReadLine());

        List<int> functionGrades = new List<int>();
        for (int i = 0; i < numGrades; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            functionGrades.Add(Convert.ToInt32(Console.ReadLine()));
        }

        double avgResult = CalculateAverage(functionGrades);
        int failingResult = FindFirstFailing(functionGrades);

        Console.WriteLine("Average: " + avgResult);
        if (failingResult == 0)
        {
            Console.WriteLine("No failing grades found.");
        }
        else
        {
            Console.WriteLine("First failing grade: " + failingResult);
        }

        //   Task 10 - Print Queue Manager  
        Console.WriteLine("\n--- Task 10 ---");
        Queue<string> printJobs = new Queue<string>();
        while (true)
        {
            Console.Write("Enter a print job name (or type 'done'): ");
            string job = Console.ReadLine();
            if (job == "done")
            {
                break;
            }
            printJobs.Enqueue(job);
        }

        Console.WriteLine("Queue before cancellation:");
        foreach (string job in printJobs)
        {
            Console.WriteLine("- " + job);
        }

        Console.Write("Enter the name of the job to cancel: ");
        string jobToCancel = Console.ReadLine();

        printJobs = RemoveJob(printJobs, jobToCancel);

        Console.WriteLine("Queue after cancellation:");
        foreach (string job in printJobs)
        {
            Console.WriteLine("- " + job);
        }

        Console.WriteLine("\nAll Task 4 exercises completed!");
    }

    // FUNCTION FOR TASK 9
    static double CalculateAverage(List<int> gradesList)
    {
        if (gradesList.Count == 0) return 0;
        int sum = 0;
        foreach (int item in gradesList)
        {
            sum += item;
        }
        return (double)sum / gradesList.Count;
    }

    // FUNCTION FOR TASK 9
    static int FindFirstFailing(List<int> gradesList)
    {
        return gradesList.Find(grade => grade < 60);
    }

    // FUNCTION FOR TASK 10
    static Queue<string> RemoveJob(Queue<string> queue, string jobName)
    {
        Queue<string> updatedQueue = new Queue<string>();

        while (queue.Count > 0)
        {
            string currentJob = queue.Dequeue();

            // Only add jobs that do NOT match the one being cancelled
            if (currentJob != jobName)
            {
                updatedQueue.Enqueue(currentJob);
            }
        }

        return updatedQueue;
    }
}
