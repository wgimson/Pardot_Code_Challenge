using System;

namespace Pardot_Code_Challenge
{
    public class PardotCodeChallenge
    {
        static int Main(string[] args)
        {
            // make sure an argument is supplied
            if (args.Length == 0)
            {
                Console.WriteLine("--- Please enter a number ---");
                return 1;
            }

            int primeLimit;
            bool isInt = int.TryParse(args[0], out primeLimit);
            // make sure argument is a number
            if (isInt == false)
            {
                Console.WriteLine("--- Please enter a number ---");
                return 1;
            }

            if (isInt && primeLimit < 3)
            {
                Console.WriteLine("--- Please enter a prime limit greater than 2 ---");
                return 1;
            }

            Utilities utils = new Utilities();
            // get all primes less than argument
            int[] primes = utils.EratosthenesSieve(primeLimit);
            // should always be true
            bool secretAdditiveIsAdditive = utils.SecretIsAdditive(utils.SecretAdditive, primes);
            Console.WriteLine(secretAdditiveIsAdditive ? "--- Function SecretAdditive is additive, as expected... ---" : "--- Function SecretAdditive is NOT additive, which should never happen... ---");
            // should always be false
            bool secretNotAdditiveIsAdditive = utils.SecretIsAdditive(utils.SecretNotAdditive, primes);
            Console.WriteLine(secretNotAdditiveIsAdditive ? "--- Function SecretNotAdditive is additive, which should never happen... ---" : "--- Function SecretNotAdditive is NOT additive, as expected... ---");
            // uncomment to print out all primes
            //Console.WriteLine("-- All Primes Less Than " + primeLimit + " ---");
            //foreach (int prime in primes)
            //{
            //    Console.WriteLine(prime);
            //}
            return 0;
        }
    }
}
