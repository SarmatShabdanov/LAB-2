using System;
// hello
namespace ComplexMethod
{
    public class Complex
    {
        public static readonly Complex Zero = new Complex(0, 0);
        public static readonly Complex One = new Complex(1, 0);
        public static readonly Complex ImaginaryUnit = new Complex(0, 1);

        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Re() => Real;
        public double Im() => Imaginary;

        public static Complex Sqrt(double real) => new Complex(Math.Sqrt(real), 0);

        public override string ToString() => $"{Real} + {Imaginary}i";

        public override bool Equals(object obj) => obj is Complex other && Real == other.Real && Imaginary == other.Imaginary;

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public static Complex operator +(Complex a, Complex b) => new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        public static Complex operator -(Complex a, Complex b) => new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        public static Complex operator *(Complex a, Complex b) => new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        public static Complex operator /(Complex a, Complex b)
        {
            if (b.Real == 0 && b.Imaginary == 0)
                throw new DivideByZeroException();
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            return new Complex((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator, (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
        }

        public static Complex operator -(Complex a) => new Complex(-a.Real, -a.Imaginary);
        public static Complex operator +(Complex a) => a;
    }
}
