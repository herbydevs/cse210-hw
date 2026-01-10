using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[0];
        int count = 0;

        // 1️⃣ Collect numbers
        while (true)
        {
            Console.Write("Enter a number (0 to quit): ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
                break;

            Array.Resize(ref numbers, count + 1);
            numbers[count] = input;
            count++;
        }

        // 2️⃣ Compute sum
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += numbers[i];
        }

        // 3️⃣ Compute average
        double average = (double)sum / count;

        // 4️⃣ Find maximum
        int max = numbers[0];
        for (int i = 1; i < count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        // 5️⃣ Output
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
