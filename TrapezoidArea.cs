using System;

public class TrapezoidArea {
    public static void Main() {
        // Prompt the user for the lengths of the two parallel sides and the height
        Console.WriteLine("Enter the length of the first parallel side (a):");
        decimal a = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter the length of the second parallel side (b):");
        decimal b = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter the height of the trapezoid:");
        decimal height = Convert.ToDecimal(Console.ReadLine());

        // Call the function to calculate the area and store the result in 'area'
        decimal area = CalculateTrapezoidArea(a, b, height);

        // Output the result
        Console.WriteLine("The area of the trapezoid is: " + area);
    }

    // Define the method to calculate the trapezoid's area
    static decimal CalculateTrapezoidArea(decimal a, decimal b, decimal height) {
        return (a + b) / 2 * height;
    }
}