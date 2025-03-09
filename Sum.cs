// Description: This program calculates the sum of an array of numbers.
using System;

class Sum{
    static void Main(){
        int numbers[] = {1, 2, 3, 4, 5};
        int sum = 0;

        for(int i = 0; i < numbers.Length; i++){
            sum += numbers[i];
        }

        Console.WriteLine("The sum of the array is: " + sum);
    }
}