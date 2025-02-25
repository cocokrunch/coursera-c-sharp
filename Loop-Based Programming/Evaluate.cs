using System;
					
public class Evaluate
{
    public static void Main()
    {
        int[] scores = { 95, 82, 75, 63, 58 };

		for (int i = 0; i < scores.Length; i++) {
			int score = scores[i];
			switch (score) {
				case int n when (n >= 90):
					Console.WriteLine("Grade A: Excellent!");
					break;
				case int n when (n >= 80):
					Console.WriteLine("Grade B: Good job!");
					break;
				case int n when (n >= 70):
					Console.WriteLine("Grade C: Fair.");
					break;
				case int n when (n >= 60):
					Console.WriteLine("Grade D: Needs improvement.");
					break;
				default:
					Console.WriteLine("Grade F: Fail.");
					break;
			}
		}
    }
}