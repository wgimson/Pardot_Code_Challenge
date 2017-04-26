
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
            // algorithm begins with 2
            int p = 2;
            do
            {
                for (var i = (2*p); i < limit; i = (i + p))
                {
                    var iIndex = Array.IndexOf(numbers, i);
                    // if number has not already been removed by previous iteration
                    if (iIndex != -1)
                    {
                        // remove multiple of P; cannot be prime
                        numbers = numbers.Where((val, idx) => idx != iIndex).ToArray();
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
            do {
                // compare a prime with every prime larger than it in primes array
                for (var yIndex = (xIndex + 1); yIndex < primes.Length; yIndex++)
                {
                    // uncomment to print all prime pairs passed to secret functions
                    //Console.WriteLine("Applying Secret() to :" + primes[xIndex] + " and " + primes[yIndex]);
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
                if (!secretIsAdditive)
                    break;
                // increment x pointer to compare with all larger primes
                xIndex++;
            } while (xIndex < primes.Length);
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
