
using System;
using System.Linq;

namespace Pardot_Code_Challenge
{
    public class Utilities
    {
        // this function was created to *always* be additive
        public int SecretAdditive(int number)
        {
            return number;
        }
        // this function was created to *never* be additive
        public int SecretNotAdditive(int number)
        {
            return (number + 1);
        }

        // Sieve of Eratosthenes Algorithm; returns every prime number less than 'limit'
        public int[] EratosthenesSieve(int limit)
        {
            int[] numbers = initializeArray(limit);
            int p = 2;
            do
            {
                for (var i = (2*p); i < limit; i = (i + p))
                {

                    if (Array.IndexOf(numbers, i) != -1)
                    {
                        var pIndex = Array.IndexOf(numbers, i);
                        // remove multiple of P; cannot be prime
                        numbers = numbers.Where((val, idx) => idx != pIndex).ToArray();
                    }
                }

                p = numbers[Array.IndexOf(numbers, p) + 1];
            } while (stillHasNumbers(numbers, p));

            // Remove final prime if happens to equal limit (limit is prime)
            if (numbers[numbers.Length-1] == limit)
            {
                numbers = numbers.Where((val, idx) => idx != numbers.Length - 1).ToArray();
            }
            return numbers;
        }

        public bool SecretIsAdditive(Func<int, int> secretFunction, int[] primes)
        {
            int xIndex = 0;
            bool secretIsAdditive = true;
            for (var yIndex = (xIndex + 1); yIndex < primes.Length; yIndex++)
            {
                // First test SecretAdditive
                // secret(x + y)
                int xPlusY = primes[xIndex] + primes[yIndex];
                int secretOfXPlusY = secretFunction(xPlusY);
                // secret(x) + secret(y)
                int secretOfX = secretFunction(primes[xIndex]);
                int secretOfY = secretFunction(primes[yIndex]);
                int secretOfXPlusSecretOfY = secretOfX + secretOfY;
                // set to false if secret(x, y) != secret(x) + secret(y)
                if (secretOfXPlusY != secretOfXPlusSecretOfY)
                {
                    secretIsAdditive = false;
                    // no need to continue
                    break;
                }
            }
            return secretIsAdditive;
        }

        private int[] initializeArray(int limit)
        {
            return Enumerable.Range(2, (limit - 1)).ToArray();
        }

        private bool stillHasNumbers(int[] numbers, int p)
        {
            return (numbers.ElementAtOrDefault(Array.IndexOf(numbers, p) + 1) != default(int) ? true : false);
        }
    }
}
