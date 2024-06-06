
using System;
using ComplexMethod;
using IRootFindingStrategyMethod;
using IPolynomialEquationMethod;

namespace PolynomialEquationMethod
{
    public class PolynomialEquation : IPolynomialEquation
    {
        private readonly double[] _coefficients;
        private readonly IRootFindingStrategy _strategy;

        public int Dimension => _coefficients.Length;

        public double[] Coefficients => (double[])_coefficients.Clone();

        public PolynomialEquation(double[] coefficients, IRootFindingStrategy strategy)
        {
            _coefficients = coefficients;
            _strategy = strategy;
        }

        public Complex[] FindRoots() => _strategy.FindRoots(_coefficients);
    }
}

