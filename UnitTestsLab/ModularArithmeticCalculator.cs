using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsLab
{
    /// <summary>
    /// Performs basic arithmetic operations in the integers mod 7.
    /// </summary>
    public class ModularArithmeticCalculator
    {
        /// <summary>
        /// The modulus applied to the arithmetic operations.
        /// </summary>
        public int Modulus { get; } = 7;

        /// <summary>
        /// Adds 2 numbers and returns the result mod 7.
        /// </summary>
        /// <param name="x">The first value to add.</param>
        /// <param name="y">The second value to add.</param>
        /// <returns>The sum of x and y mod 7.</returns>
        public int Add(int x, int y)
        {
            return (x + y) % Modulus;
        }

        /// <summary>
        /// Multiplies 2 numbers and returns the result mod 7.
        /// </summary>
        /// <param name="x">The first factor.</param>
        /// <param name="y">The second factor.</param>
        /// <returns>The product of the two factors, mod the 7.</returns>
        public int Multiply(int x, int y)
        {
            return (x * y) % Modulus;
        }

        /// <summary>
        /// Calculates the inverse of y (y^-1). The inverse is defined
        /// as the integer b such that y * b = 1 mod 7. Because 7 is prime,
        /// all numbers except 0 have an inverse. If y == 0, then an
        /// ArgumentException is thrown.
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        private int FindInverse(int y)
        {
            if (y == 0)
            {
                throw new ArgumentException("0 does not have an inverse.");
            }
            int inverse = 1;
            for (int i = 2; i < Modulus; i++)
            {
                if (Multiply(y, i) == 1)
                {
                    return i;
                }
            }

            return inverse;
        }

        /// <summary>
        /// Divides the first parameter by the second parameter. Division is defined
        /// by performing the multiplication x * b, where b is the number such that
        /// y * b = 1 mod 7. Because 7 is prime, there is guaranteed to be a number
        /// b for all integers y except for 0. If is 0, an ArgumentException is thrown.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The dividend divided by the divisor, mod 7.</returns>
        public int Divide(int x, int y)
        {
            if (y == 0)
            {
                throw new ArgumentException("Cannot divide by 0.");
            }
            int inverse = FindInverse(y);
            return Multiply(x, inverse);
        }
    }
}
