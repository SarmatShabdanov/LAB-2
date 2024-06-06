
using System;
using ComplexMethod;
using IRootFindingStrategyMethod;

namespace QuadraticEquationStrategyMethod
{
    public class QuadraticEquationStrategy : IRootFindingStrategy
    {
        public Complex[] FindRoots(double[] coefficients)
        {
          if (coefficients.Length != 3)
          {
              throw new ArgumentException("Количество коэффициентов должно быть равно 3 для квадратного уравнения.");
          }

          double a = coefficients[0];
          double b = coefficients[1];
          double c = coefficients[2];

          if (a == 0)
          {
              throw new DivideByZeroException("Коэффициент a не может быть равен нулю.");
          }

          double discriminant = b * b - 4 * a * c;
          if (discriminant < 0)
          {
              // Корни комплексные
              double realPart = -b / (2 * a);
              double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
              return new Complex[] { new Complex(realPart, imaginaryPart), new Complex(realPart, -imaginaryPart) };
          }
          else
          {
              // Корни вещественные
              double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
              double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
              return new Complex[] { new Complex(root1, 0), new Complex(root2, 0) };
          }
        }
    }
}
