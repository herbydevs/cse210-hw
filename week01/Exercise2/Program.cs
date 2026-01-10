using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade?");
        int grade = int.Parse(Console.ReadLine());

        char letter;
        string sign = "";

        // 1️⃣ Determine letter grade
        if (grade >= 90)
            letter = 'A';
        else if (grade >= 80)
            letter = 'B';
        else if (grade >= 70)
            letter = 'C';
        else if (grade >= 60)
            letter = 'D';
        else
            letter = 'F';

        
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
            sign = "+";
        else if (lastDigit < 3)
            sign = "-";

        // handling edge cases cus im cool
        if (letter == 'A' && sign == "+")
            sign = "";          // No A+
        if (letter == 'F')
            sign = "";          // No F+ or F-
        Console.WriteLine($"You received a {letter}{sign}.");
    }
}
