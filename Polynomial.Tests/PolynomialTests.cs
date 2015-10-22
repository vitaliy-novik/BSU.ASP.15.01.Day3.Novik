using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Polynomial;
using System.Diagnostics;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {

        [TestCase(new int[] {2, 4, 6}, new int[] {2, 4, 6}, Result=true)]
        [TestCase(new int[] { 2, 4, 6 }, new int[] { 2, 6, 6 }, Result = false)]
        [TestCase(new int[] { 2, 4, 6, 0 }, new int[] {2, 4, 6, 0, 0 }, Result = true)]
        public bool EqualsTest(int[] a, int[] b)
        {
            Polynomial p1 = new Polynomial(a);
            Polynomial p2 = new Polynomial(b);
            return (p1 == p2);
        }

        [TestCase(new int[] {2, 4, 6}, new int[] {2, 4, 6}, 
            new int[]{4, 8, 12}, Result=true)]
        [TestCase(new int[] { 2, 4, 6 }, new int[] { 2, 6, 6 },
            new int[] { 4, 10, 12 }, Result = true)]
        [TestCase(new int[] { 2, 4, 6, 0 }, new int[] {2, 4, 6, 0, 0 },
            new int[] { 4, 8, 12 }, Result = true)]
        public bool AddTest(int[] a, int[] b, int[] c)
        {
            Polynomial p1 = new Polynomial(a);
            Polynomial p2 = new Polynomial(b);
            Polynomial p = new Polynomial(c);
            return ((p1 + p2) == p);
        }

        [TestCase(new int[] { 2, 4, 6 }, Result = "6x^2 + 4x^1 + 2x^0")]
        [TestCase(new int[] { 2, -4, 6, 0 }, Result = "6x^2 + -4x^1 + 2x^0")]
        public string ToStringTest(int[] a)
        {
            Polynomial p = new Polynomial(a);
            return (p.ToString());
        }

        [TestCase(new int[] { 1, 1}, new int[] { 1, 1 },
            new int[] { 1, 2, 1 }, Result = true)]
        [TestCase(new int[] { -1, 2 }, new int[] { 2, 1 },
            new int[] { -2, 3, 2 }, Result = true)]
        public bool MultiplyTest(int[] a, int[] b, int[] c)
        {
            Polynomial p1 = new Polynomial(a);
            Debug.WriteLine(p1); 
            Polynomial p2 = new Polynomial(b);
            Debug.WriteLine(p2);
            Debug.WriteLine(p1*p2);
            Polynomial p = new Polynomial(c);
            return ((p1 * p2) == p);
        }

        [TestCase(new int[] { 1, 1}, new int[] { 1, 1 }, Result=true)]
        public bool GetHashCodeTest(int[] a, int[] b)
        {
            Polynomial p1 = new Polynomial(a);
            Polynomial p2 = new Polynomial(b);
            return (p1.GetHashCode() == p2.GetHashCode());
        }

    }
}
