using System;
using System.Collections.Generic;

namespace all_string_permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var perms = AllPermutations("abcde");

            perms.ForEach(p => Console.WriteLine(p));
        }

        /// given a string of unique chars, print all possible permutations of it.
        private static List<string> AllPermutations(string s)
        {
            // assume we have a function that can give us
            // all permutations of a string already, and we want to add another char to it

            // we would do so by iterating through each existing permutation,
            // and for each of those permutations, placing the char c in each possible position.

            // for example, if we already had permutations for "abc":
            // 'abc', 'acb', 'bac', 'bca', 'cab', 'cba'
            // adding 'd' would be done by going through each one and placing it in all possible positions.
            // 3 was '3 * 2 * 1' = 6, 4 would be 6 * 4 = 24

            // let's first establish base cases
            if (s.Length == 0) { return new List<string>(); }
            else if (s.Length == 1) { return new List<string> { s }; }

            // so first, find all permutations of s[0:length-1]
            string substr = s.Substring(0, s.Length - 1);
            List<string> substrPerms = AllPermutations(substr);

            // then build our new set of permutations
            char finalChar = s[s.Length - 1];
            var results = new List<string>();
            foreach (string perm in substrPerms)
            {
                // place the final char in every possible position
                string result = string.Empty;
                List<string> charInAllPos = PlaceCharInAllPos(perm, finalChar);
                results.AddRange(charInAllPos);
            }

            return results;
        }

        private static List<string> PlaceCharInAllPos(string s, char c)
        {
            var result = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                // place char in this position (and also at the end)
                string unique = s.Substring(0, i) + c + s.Substring(i, s.Length - i);

                result.Add(unique);
            }

            result.Add(s + c);

            return result;
        }
    }
}
