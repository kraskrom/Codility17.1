/*
For a given array A of N integers and a sequence S of N integers from the set {−1, 1}, we define val(A, S) as follows:

val(A, S) = |sum{ A[i]*S[i] for i = 0..N−1 }|

(Assume that the sum of zero elements equals zero.)

For a given array A, we are looking for such a sequence S that minimizes val(A,S).

Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, computes the minimum value of val(A,S) from all possible values of val(A,S) for all possible sequences S of N integers from the set {−1, 1}.

For example, given array:

  A[0] =  1
  A[1] =  5
  A[2] =  2
  A[3] = -2
your function should return 0, since for S = [−1, 1, −1, 1], val(A, S) = 0, which is the minimum possible value.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [0..20,000];
each element of array A is an integer within the range [−100..100].
*/

using System;
using System.Collections.Generic;

namespace Codility17._1
{
    class Solution
    {
        public int solution(int[] A)
        {
            if (A.Length == 0)
                return 0;
            if (A.Length == 1)
                return Math.Abs(A[0]);
            int total = 0;
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Math.Abs(A[i]);
                total += A[i];
                if (numbers.ContainsKey(A[i]))
                    numbers[A[i]]++;
                else
                    numbers.Add(A[i], 1);
            }
            int[] possible = new int[total / 2 + 1];
            for (int i = 1; i <= total / 2; i++)
                possible[i] = -1;
            foreach (int number in numbers.Keys)
                for (int trying = 0; trying <= total / 2; trying++)
                    if (possible[trying] >= 0)
                        possible[trying] = numbers[number];
                    else if (trying >= number && possible[trying - number] > 0)
                        possible[trying] = possible[trying - number] - 1;
            for (int halfsum = total / 2; halfsum >= 0; halfsum--)
                if (possible[halfsum] >= 0)
                    return total - 2 * halfsum;
            return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            //int[] A = { 1, 5, 2, -2 };
            //int[] A = { 3, 3, 3, 4, 5 };
            //int[] A = { 1, 5, -2, 5, 2, 3 };
            //int[] A = { 2, 3, 3, 3, 4, 5 };
            int[] A = { 2, 4, 1 };
            int s = sol.solution(A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
} 