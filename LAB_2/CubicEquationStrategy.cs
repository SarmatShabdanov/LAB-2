
using System;
using ComplexMethod;
using IRootFindingStrategyMethod;

namespace CubicEquationStrategyMethod
{
    public class CubicEquationStrategy : IRootFindingStrategy
    {
        public Complex[] FindRoots(double[] coefficients)
        {
          if (coefficients.Length != 4)
          {
              throw new ArgumentException("Количество коэффициентов должно быть равно 4 для кубического уравнения.");
          }

          double A = coefficients[0];
          double B = coefficients[1];
          double C = coefficients[2];
          double D = coefficients[3];

          if (A == 0)
          {
              throw new DivideByZeroException("Коэффициент A не может быть равен нулю.");
          }

          double f = ((3 * C) / A) - ((B * B) / (A * A)) / 3;
          double g = ((2 * Math.Pow(B, 3)) / (Math.Pow(A, 3))) - ((9 * B * C) / (Math.Pow(A, 2))) + ((27 * D) / A) / 27;
          double h = (Math.Pow(g, 2) / 4) + (Math.Pow(f, 3) / 27);

          Complex[] roots = new Complex[3];

          if (h <= 0)
          {
              double i = (Math.Pow(g, 2) / 4) - h;
              double i2 = Math.Pow(i, 0.5);
              double j = Math.Pow(i2, 1.0 / 3.0);
              double k = Math.Acos(-g / (2 * i2));
              double l = j * -1;
              double m = Math.Cos(k / 3);
              double n = Math.Sqrt(3) * Math.Sin(k / 3);
              double p = (B / (3 * A)) * -1;

              roots[0] = new Complex((2 * j) * m - (B / (3 * A)), 0);
              roots[1] = new Complex((l * (m + n)) + p, 0);
              roots[2] = new Complex((l * (m - n)) + p, 0);
          }
          else
          {
              double r = -(g / 2) + Math.Pow(h, 0.5);
              if (r >= 0)
              {
                  double s = Math.Pow(r, 1.0 / 3.0);
                  double t = -(g / 2) - Math.Pow(h, 0.5);
                  if (t >= 0)
                  {
                      double u = Math.Pow(t, 1.0 / 3.0);
                      roots[0] = new Complex((s + u) - (B / (3 * A)), 0);
                      roots[1] = new Complex((-s + u) - (B / (3 * A)), 0);
                      roots[2] = new Complex((-s - u) - (B / (3 * A)), 0);
                  }
                  else
                  {
                      double v = Math.Pow(-t, 1.0 / 3.0);
                      roots[0] = new Complex((s + v) - (B / (3 * A)), 0);
                      roots[1] = new Complex((-s + v) - (B / (3 * A)), 0);
                      roots[2] = new Complex((-s - v) - (B / (3 * A)), 0);
                  }
              }
              else
              {
                  double u = Math.Pow(-r, 1.0 / 3.0);
                  double v = Math.Pow(-g / 2, 1.0 / 3.0);
                  roots[0] = new Complex((u + v) - (B / (3 * A)), 0);
                  roots[1] = new Complex((-u + v) - (B / (3 * A)), 0);
                  roots[2] = new Complex((-u - v) - (B / (3 * A)), 0);
              }
          }

          return roots;
        }
    }
}
