
using System;
using ComplexMethod;
using CubicEquationStrategyMethod;
using EquationsMethod;
using IPolynomialEquationMethod;
using LinearEquationStrategyMethod;
using QuadraticEquationStrategyMethod;

class Program
{
    public static void Main(string[] args)
    {
      Console.WriteLine("Введите коэффициенты уравнения через пробел:");
      string input = Console.ReadLine();
      string[] inputCoefficients = input.Split(' ');

      double[] coefficients = new double[inputCoefficients.Length];
      for (int i = 0; i < inputCoefficients.Length; i++)
      {
          if (!double.TryParse(inputCoefficients[i], out coefficients[i]))
          {
              Console.WriteLine("Ошибка ввода. Введите числа.");
              return;
          }
      }

      try
      {
        IPolynomialEquation equation = Equations.CreateEquation(coefficients);
          Complex[] roots = equation.FindRoots();
          Console.WriteLine("Корни уравнения:");
          foreach (var root in roots)
          {
              Console.WriteLine(root);
          }
      }
      catch (Exception ex)
      {
          Console.WriteLine($"Произошла ошибка: {ex.Message}");
      }
    }
}

