using System;
using ComplexMethod;

namespace IPolynomialEquationMethod
{
    public interface IPolynomialEquation
    {
        int Dimension { get; }
        double[] Coefficients { get; }
        Complex[] FindRoots();
    }
}

