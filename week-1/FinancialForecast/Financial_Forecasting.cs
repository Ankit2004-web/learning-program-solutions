/* Exercise 7: Financial Forecasting
Scenario: 
You are developing a financial forecasting tool that predicts future values based on past data.
Steps:
1.Understand Recursive Algorithms:
oExplain the concept of recursion and how it can simplify certain problems.
2.Setup:
oCreate a method to calculate the future value using a recursive approach.
3.Implementation:
oImplement a recursive algorithm to predict future values based on past growth rates.
4.Analysis:
oDiscuss the time complexity of your recursive algorithm.
oExplain how to optimize the recursive solution to avoid excessive computation. */

using System;

class Program
{
    // Recursive function to calculate future value based on growth rate
    static double FutureValue(double presentValue, double rate, int years)
    {
        if (years == 0)
            return presentValue;

        return (1 + rate) * FutureValue(presentValue, rate, years - 1);
    }

    static void Main()
    {
        Console.WriteLine("=== Financial Forecasting Tool ===");

        Console.Write("Enter Present Value: ");
        double presentValue = double.Parse(Console.ReadLine());

        Console.Write("Enter Annual Growth Rate (%): ");
        double ratePercent = double.Parse(Console.ReadLine());

        Console.Write("Enter Number of Years: ");
        int years = int.Parse(Console.ReadLine());

        double rate = ratePercent / 100;

        double result = FutureValue(presentValue, rate, years);

        Console.WriteLine($"\nPredicted Future Value after {years} years: {result:F2}");
    }
}
