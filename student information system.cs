 using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int studentCount = int.Parse(Console.ReadLine() ?? "3");

        string[] names = new string[studentCount];
        string[] ids = new string[studentCount];
        string[] programmes = new string[studentCount];
        string[] levels = new string[studentCount];

        int[,] scores = new int[studentCount, 5];
        int[] totals = new int[studentCount];
        double[] averages = new double[studentCount];
        string[] grades = new string[studentCount];
        string[] statuses = new string[studentCount];

        bool dataEntered = false;

        string[] courses =
        {
            "Programming with C#",
            "Database Systems",
            "Computer Networks",
            "Web Development",
            "Mathematics for Computing"
        };

        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. View Statistics");
            Console.WriteLine("4. Exit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":

                    for (int i = 0; i < studentCount; i++)
                    {
                        Console.Clear();

                        Console.WriteLine($"Enter Details For Student {i + 1}\n");

                        Console.Write("Enter Full Name: ");
                        names[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Student ID: ");
                        ids[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Programme: ");
                        programmes[i] = Console.ReadLine() ?? "";

                        Console.Write("Enter Level: ");
                        levels[i] = Console.ReadLine() ?? "";

                        int total = 0;

                        for (int j = 0; j < 5; j++)
                        {
                            scores[i, j] = GetValidScore(courses[j]);
                            total += scores[i, j];
                        }

                        totals[i] = total;
                        averages[i] = total / 5.0;

                        grades[i] = GetGrade(averages[i]);
                        statuses[i] = GetStatus(averages[i]);
                    }

                    dataEntered = true;

                    Console.WriteLine("\nStudent records saved successfully.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":

                    Console.Clear();

                    if (!dataEntered)
                    {
                        Console.WriteLine("No student records available.");
                    }
                    else
                    {
                        Console.WriteLine("===== STUDENT RESULTS REPORT =====\n");

                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine($"Student Name: {names[i]}");
                            Console.WriteLine($"Student ID: {ids[i]}");
                            Console.WriteLine($"Programme: {programmes[i]}");
                            Console.WriteLine($"Level: {levels[i]}\n");

                            for (int j = 0; j < 5; j++)
                            {
                                Console.WriteLine($"{courses[j]}: {scores[i, j]}");
                            }

                            Console.WriteLine($"\nTotal Score: {totals[i]}");
                            Console.WriteLine($"Average Score: {averages[i]:F1}");
                            Console.WriteLine($"Grade: {grades[i]}");
                            Console.WriteLine($"Status: {statuses[i]}");

                            Console.WriteLine("\n----------------------------------------\n");
                        }
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":

                    if (!dataEntered)
                    {
                        Console.WriteLine("No student records available.");
                        Console.ReadKey();
                        break;
                    }

                    int bestIndex = 0;
                    int lowestIndex = 0;
                    double classTotal = 0;

                    for (int i = 0; i < studentCount; i++)
                    {
                        classTotal += averages[i];

                        if (averages[i] > averages[bestIndex])
                        {
                            bestIndex = i;
                        }

                        if (averages[i] < averages[lowestIndex])
                        {
                            lowestIndex = i;
                        }
                    }

                    double classAverage = classTotal / studentCount;

                    Console.Clear();

                    Console.WriteLine("===== CLASS STATISTICS =====\n");

                    Console.WriteLine("BEST STUDENT");
                    Console.WriteLine($"Name: {names[bestIndex]}");
                    Console.WriteLine($"Average: {averages[bestIndex]:F1}\n");

                    Console.WriteLine("LOWEST STUDENT");
                    Console.WriteLine($"Name: {names[lowestIndex]}");
                    Console.WriteLine($"Average: {averages[lowestIndex]:F1}\n");

                    Console.WriteLine($"CLASS AVERAGE: {classAverage:F1}");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":

                    Console.WriteLine("\nThank you for using the Student Results Processing System.");
                    return;

                default:

                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static int GetValidScore(string course)
    {
        int score;

        while (true)
        {
            Console.Write($"Enter score for {course}: ");

            if (int.TryParse(Console.ReadLine(), out score)
                && score >= 0
                && score <= 100)
            {
                return score;
            }

            Console.WriteLine("Invalid score. Score must be between 0 and 100.");
        }
    }

    static string GetGrade(double average)
    {
        if (average >= 80)
            return "A";
        else if (average >= 70)
            return "B";
        else if (average >= 60)
            return "C";
        else if (average >= 50)
            return "D";
        else
            return "F";
    }

    static string GetStatus(double average)
    {
        return average >= 50 ? "Passed" : "Failed";
    }
}