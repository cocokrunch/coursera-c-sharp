// Creating a Function for Circle Area Calculation
using System;

public class Area
{
    // Function to calculate the area of a circle
    static double CalculateCircleArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    public static void Main()
    {
        // Prompt the user to input the radius
        Console.WriteLine("Enter the radius of the circle:");
        double radius = Convert.ToDouble(Console.ReadLine());

        // Call the function to calculate the area
        double area = CalculateCircleArea(radius);

        // Output the result
        Console.WriteLine("The area of the circle is: " + area);
    }
}