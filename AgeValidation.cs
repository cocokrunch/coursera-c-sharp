using System;

public class AgeValidation
{

	public static void Main() {
		// Call the method
		Console.WriteLine("Enter your age: ");
		int age = int.Parse(Console.ReadLine());
		bool canDrive = IsOldEnoughToDrive(age);
		if (canDrive) {
			Console.WriteLine("You are old enough to drive.");
		} else {
			Console.WriteLine("You are not old enough to drive.");
		}	
	}
	// Method Definition
	static bool IsOldEnoughToDrive(int age) {
		if (age >= 18) {
			return true;
		} else {
			return false;
		}
	}
}