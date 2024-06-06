
using System;
using ComplexMethod;
using IRootFindingStrategyMethod;
using LinearEquationStrategyMethod;
using QuadraticEquationStrategyMethod;
using PolynomialEquationMethod;
using IPolynomialEquationMethod;
using CubicEquationStrategyMethod;

namespace EquationsMethod
{
  
    public static class Equations
    {
        public static double[] RemoveLeadingZeros(double[] coefficients)
        {
            int firstNonZeroIndex = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    firstNonZeroIndex = i;
                    break;
                }
            }

            if (firstNonZeroIndex == 0)
            {
                return coefficients;
            }
            else
            {
                double[] trimmedCoefficients = new double[coefficients.Length - firstNonZeroIndex];
                Array.Copy(coefficients, firstNonZeroIndex, trimmedCoefficients, 0, coefficients.Length - firstNonZeroIndex);
                return trimmedCoefficients;
            }
        }

        public static IRootFindingStrategy SelectStrategy(double[] coefficients)
        {
          int degree = coefficients.Length - 1;
          switch (degree)
          {
              case 0:
                  throw new ArgumentException("Уравнение не может быть линейным, так как не содержит коэффициентов.");
              case 1:
                  return new LinearEquationStrategy();
              case 2:
                  return new QuadraticEquationStrategy();
              case 3:
                  return new CubicEquationStrategy();
              default:
                  throw new NotSupportedException("Для уравнений степени больше 3 не предусмотрена прямая реализация.");
          }
        }

        public static IPolynomialEquation CreateEquation(double[] coefficients)
        {
            double[] trimmedCoefficients = RemoveLeadingZeros(coefficients);
            IRootFindingStrategy strategy = SelectStrategy(trimmedCoefficients);
            return new PolynomialEquation(trimmedCoefficients, strategy);
        }
    }
  
}

