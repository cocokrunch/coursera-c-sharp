using System;
					
public class Practical
{
	// Define the method that checks if the user is old enough to drive
	public static bool IsOldEnoughToDrive(int age) {
		if (age >= 18) {
			return true;
		} else {
			return false;
		}
	}

	// Call the method inside Main and check if the user is old enough to drive
	static void Main(string[] args) {
		Console.WriteLine("Enter your age:");
		int age = int.Parse(Console.ReadLine());
		bool canDrive = IsOldEnoughToDrive(age);
		if (canDrive) {
			Console.WriteLine("You are old enough to drive.");
		} else {
			Console.WriteLine("You are not old enough to drive.");
		}
	}
}