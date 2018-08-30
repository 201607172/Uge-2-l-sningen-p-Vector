using System;

namespace VectorCalculator
{
    public class VectorCalc
    {
        public Vector Add(Vector v1, Vector v2)
        {
            return new Vector {X = v1.X + v2.X, Y = v1.Y + v2.Y};
        }

        public Vector Subtract(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X - v2.X, Y = v1.Y - v2.Y };
        }

        public Vector Scale(Vector v1, double factor)
        {
            return new Vector { X = v1.X * factor, Y = v1.Y * factor };
        }

        public double DotProduct(Vector v1, Vector v2)
        {
            return (v1.X*v2.X) + (v1.Y*v2.Y);
        }

        public double Magnitude(Vector v)
        {
            return Math.Sqrt(v.X*v.X + v.Y*v.Y);
        }

        public double Angle(Vector v1, Vector v2)
        {
            var cosA = DotProduct(v1, v2)/(Magnitude(v1)*Magnitude(v2));
            return Math.Acos(cosA);
        }

        public PolarVector Convert(Vector v)
        {
            var result = new PolarVector {R = Magnitude(v)};

            if (v.X ==0)
            {
                result.Theta = v.Y >= 0 ? Math.PI/2 : -Math.PI/2;
            }
            result.Theta = Math.Atan(v.Y/v.X);

            return result;
        }

    }
}
