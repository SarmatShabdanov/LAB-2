
using System;
using ComplexMethod;
using IRootFindingStrategyMethod;

namespace LinearEquationStrategyMethod
{
    public class LinearEquationStrategy : IRootFindingStrategy
    {
        public Complex[] FindRoots(double[] coefficients)
        {
          if (coefficients.Length != 2)
          {
              throw new ArgumentException("Количество коэффициентов должно быть равно 2 для линейного уравнения.");
          }

          double a = coefficients[0];
          double b = coefficients[1];

          if (a == 0)
          {
              throw new DivideByZeroException("Коэффициент a не может быть равен нулю.");
          }

          // Решение линейного уравнения: x = -b / a
          Complex root = new Complex(-b / a, 0);
          return new Complex[] { root };
        }
    }
}
