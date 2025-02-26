using System;

public class Calculate
{
    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        int sum = 0;
// Loop through each number in the array
        foreach (int number in numbers)
        {
// Add each number to the sum
            sum += number;
        }
// Output the sum
        Console.WriteLine("The sum of the array is: " + sum);
    }
}
