using System;
using NUnit.Framework;

namespace VectorCalculator.Test.Unit
{
    [TestFixture]
    public class VectorCalcUnitTest
    {
        private VectorCalc _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new VectorCalc();
        }


        // Example of a "stand-alone" test case for Add()
        [Test]
        public void Add_TwoPositiveVectors_ResultXCorrect()
        {
            Vector v1 = new Vector { X = 2, Y = 3 };
            Vector v2 = new Vector { X = 4, Y = 5 };

            Assert.That(_uut.Add(v1, v2).X, Is.EqualTo(6));
        }


        [Test]
        public void Add_TwoPositiveVectors_ResultYCorrect()
        {
            Vector v1 = new Vector { X = 2, Y = 3 };
            Vector v2 = new Vector { X = 4, Y = 5 };

            Assert.That(_uut.Add(v1, v2).Y, Is.EqualTo(8));
        }


        // Test case for faster definition of test cases for Add() - X coordinate
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, 1, 0)]
        [TestCase(2, 3, 4, 5, 6)]
        [TestCase(-2, 2, -3, 3, -5)]
        [TestCase(-2, 2, 3, -3, 1)]
        public void Add_VariousVectors_ResultXCorrect(double v1x, double v1y, double v2x, double v2y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            Vector v2 = new Vector { X = v2x, Y = v2y };

            Assert.That(_uut.Add(v1, v2).X, Is.EqualTo(result));
        }

        // Test case for faster definition of test cases for Add() - Y coordinate
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, 1, 2)]
        [TestCase(2, 3, 4, 5, 8)]
        [TestCase(-2, 2, -3, 3, 5)]
        [TestCase(-2, 2, 3, -3, -1)]
        public void Add_VariousVectors_ResultYCorrect(double v1x, double v1y, double v2x, double v2y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            Vector v2 = new Vector { X = v2x, Y = v2y };

            Assert.That(_uut.Add(v1, v2).Y, Is.EqualTo(result));
        }


        // Test case for faster definition of test cases for Subtract() - X coordinate
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, 1, 0)]
        [TestCase(2, 3, 4, 5, -2)]
        [TestCase(-2, 2, -3, 3, 1)]
        [TestCase(-2, 2, 3, -3, -5)]
        public void Subtract_VariousVectors_ResultXCorrect(double v1x, double v1y, double v2x, double v2y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            Vector v2 = new Vector { X = v2x, Y = v2y };

            Assert.That(_uut.Subtract(v1, v2).X, Is.EqualTo(result));
        }

        // Test case for faster definition of test cases for Subtract() - Y coordinate
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, -1, 2)]
        [TestCase(2, 3, 4, 6, -3)]
        [TestCase(-2, 2, -3, 3, -1)]
        [TestCase(-2, 2, 3, -3, 5)]
        public void Subtract_VariousVectors_ResultYCorrect(double v1x, double v1y, double v2x, double v2y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            Vector v2 = new Vector { X = v2x, Y = v2y };

            Assert.That(_uut.Subtract(v1, v2).Y, Is.EqualTo(result));
        }

        // Test case for faster definition of test cases for Scale() - X coordinate
        [TestCase(0, 0, 0, 0)]
        [TestCase(2, 3, 0, 0)]
        [TestCase(2, 3, 4, 8)]
        [TestCase(2, 2, -3, -6)]
        [TestCase(-2, 2, -3, 6)]
        public void Scale_VariousVectors_ResultXCorrect(double v1x, double v1y, double factor, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            
            Assert.That(_uut.Scale(v1, factor).X, Is.EqualTo(result));
        }

        // Test case for faster definition of test cases for Scale() - X coordinate
        [TestCase(0, 0, 0, 0)]
        [TestCase(2, 3, 0, 0)]
        [TestCase(2, 3, 4, 12)]
        [TestCase(2, 2, -3, -6)]
        [TestCase(-2, -2, -3, 6)]
        public void Scale_VariousVectors_ResultYCorrect(double v1x, double v1y, double factor, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };

            Assert.That(_uut.Scale(v1, factor).Y, Is.EqualTo(result));
        }
        
        // Test case for faster definition of test cases for DotProduct()
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(0, 1, 0, -1, -1)]
        [TestCase(2, 3, 4, 6, 26)]
        [TestCase(-2, 2, -3, 3, 12)]
        [TestCase(-2, 2, 3, -3, -12)]
        public void DotProduct_VariousVectors_ResultCorrect(double v1x, double v1y, double v2x, double v2y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };
            Vector v2 = new Vector { X = v2x, Y = v2y };

            Assert.That(_uut.DotProduct(v1, v2) - result, Is.LessThan(Double.Epsilon));
        }


        // Test case for faster definition of test cases for DotProduct()
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(3, 4, 5)]
        [TestCase(-3, -4, 5)]
        public void Magnitude_VariousVectors_ResultCorrect(double v1x, double v1y, double result)
        {
            Vector v1 = new Vector { X = v1x, Y = v1y };

            Assert.That(_uut.Magnitude(v1) - result, Is.LessThan(Double.Epsilon));
        }

        public void Magnitude_SingleVectors_ResultCorrect()
        {
            Vector v1 = new Vector { X = 1, Y = 1};

            Assert.That(_uut.Magnitude(v1) - Math.Sqrt(2), Is.LessThan(Double.Epsilon));
        }
    }
}
