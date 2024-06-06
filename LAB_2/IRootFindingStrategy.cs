using System;
using ComplexMethod;

namespace IRootFindingStrategyMethod
{
    public interface IRootFindingStrategy
    {
        Complex[] FindRoots(double[] coefficients);
    }
}

