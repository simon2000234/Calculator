using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Calculator
{
    public class Calculate
    {
        private readonly Repo repo;

        public Calculate(Repo repo)
        {
            this.repo = repo;
        }

        public bool IsPrime(int number)
        {
            if (number == 1 || number % 2 == 0 || number == 0 || number < 0) return false;

            if (number == 2) return true;

            var boundary = number / 2;

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }


        public int GetNumberOfPerfectNumbersInRange(int start)
        {
            int end = repo.GetEnd();
            if (start < end || start > 1000 && end < start+1000)
            {
                throw new Exception("Bad nubmers");
            }

            int total = 0;
            int flag = 0;

            for (start = start; start <= end; start++)
            {
                for (int i = 1; i < start; i++)
                {
                    if (start % i == 0)
                        total += i;
                }
                if ((total == start) && (start != 0))
                {
                    flag = 1;
                }
                total = 0;
            }

            if (flag == 0)
                throw new Exception("No perfect numbers");
            return total;
        }


        public List<int> PrimeFactor(int num)
        {
            int flag = 0;
            List<int> primeFactors = new List<int>();

            for (int i = 2; i < num; i++)
            {
                // check for divisibility
                if (num % i == 0)
                {
                    var count = 0;
                    // check for prime number
                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                            count++;
                    }
                    if (count == 2)
                    {
                        flag = 1;
                        primeFactors.Add(i);
                    }
                }
            }

            if (flag == 0)
                throw new Exception("No prime factors");
            return primeFactors;
        }
    }
}