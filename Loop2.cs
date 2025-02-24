//Step 2: Using a While Loop to Calculate Factorials
using System;
					
public class Loop2
{
    public static void Main()
    {
        	int number = 5;
		int factorial = 1;

		while (number > 0) {
			factorial *= number;
			number--;
		}

		Console.WriteLine("Factorial: " + factorial);
	}
}