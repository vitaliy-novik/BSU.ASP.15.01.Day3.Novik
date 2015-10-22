using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public class Polynomial
    {
        private int[] coeffs;

        public int Degree { get; protected set; }

        public Polynomial() : this(new int[] { 0 }) { }

        public Polynomial(int[] array)
        {
            if (array == null)
                throw new ArgumentException();
            int i = array.Length - 1;
            while (i > 0 && array[i] == 0)
                --i;
            coeffs = new int[i+1];
            Array.Copy(array, coeffs, i+1);
            Degree = i;
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException();
            int[] arr = new int[Math.Max(p1.coeffs.Length, p2.coeffs.Length)];
            for (int i = 0; i < arr.Length; ++i)
            { 
                if (i < p1.coeffs.Length)
                    arr[i] += p1.coeffs[i];
                if (i < p2.coeffs.Length)
                    arr[i] += p2.coeffs[i];
            }
            return new Polynomial(arr);
        }

        public static Polynomial operator *(Polynomial p, int c)
        {
            if (p == null)
                throw new ArgumentException();
            if (c == 0)
                return new Polynomial();
            int[] arr = new int[p.coeffs.Length];
            for (int i = 0; i < arr.Length; ++i)
                arr[i] = p.coeffs[i] + c;
            return new Polynomial(arr);
        }

        public static Polynomial operator *(int c, Polynomial p)
        {
            return p * c;
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return p1 + p2 * (-1);
        }

        public static Polynomial operator -(Polynomial p)
        {
            return p * (-1);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException();
            int[] arr = new int[p1.Degree + p2.Degree + 1];
            for (int i = 0; i < p1.coeffs.Length; ++i)
            {
                for (int j = 0; j < p2.coeffs.Length; ++j)
                {
                    arr[i + j] += p1.coeffs[i] * p2.coeffs[j];
                }
            }
            return new Polynomial(arr);
        }

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        public static implicit operator int[] (Polynomial p)
        {
            return p.coeffs;
        }

        public static implicit operator Polynomial (int[] a)
        {
            return new Polynomial(a);
        }

        public override string ToString()
        {
            
            return String.Join(" + ", 
                coeffs.AsEnumerable()
                      .Select((x, y)=> String.Format("{0}x^{1}",x, y ))
                      .Reverse());
            /*
            StringBuilder sb = new StringBuilder();
            if (coeffs[coeffs.Length - 1] != 1)
                sb.Append(coeffs[coeffs.Length - 1]);
            sb.Append(String.Format("x^{0}", coeffs.Length - 1));
            if (coeffs.Length > 1)
            {
                for (int i = coeffs.Length - 2; i > 1; --i)
                {
                    if (coeffs[i] == 0) continue;
                    if (coeffs[i] > 0)
                        sb.Append("+");
                    if (coeffs[i] != 1)
                        sb.Append(coeffs[i]);
                    sb.Append(String.Format("x^{0}", i));
                }
                if (coeffs[1] > 0)
                    sb.Append("+");
                if (coeffs[1] != 1)
                    sb.Append(coeffs[1]);
                sb.Append("x");
                if (coeffs[0] > 0)
                    sb.Append("+");
                sb.Append(coeffs[0]);
                
            }
            return sb.ToString();
            */
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynomial && obj != null)
            {
                Polynomial p = (Polynomial)obj;
                return coeffs.SequenceEqual(p.coeffs);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int this[int i]
        {
            get
            {
                return coeffs[i];
            }
            //protected set
            //{
            //    coeffs[i] = value;
            //}
        }

    }
}
