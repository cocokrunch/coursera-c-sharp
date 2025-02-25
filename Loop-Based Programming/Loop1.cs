//Step 1: Using a For Loop to Calculate Total Scores
using System;
					
public class Loop1
{
    public static void Main()
    {
        int[] scores = { 85, 90, 78, 92, 88 };
		int total = 0;

		for (int i = 0; i < scores.Length; i++) {
			total += scores[i];
		}

		Console.WriteLine("Total score: " + total);

			}
}