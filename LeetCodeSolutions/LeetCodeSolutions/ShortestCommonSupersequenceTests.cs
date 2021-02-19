using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeSolutions
{
    //1092. Shortest Common Supersequence
    //Given two strings str1 and str2, return the shortest string that has both str1 and str2 as subsequences.If multiple answers exist, you may return any of them.

    //(A string S is a subsequence of string T if deleting some number of characters from T(possibly 0, and the characters are chosen anywhere from T) results in the string S.)




    //Example 1:

    //Input: str1 = "abac", str2 = "cab"
    //Output: "cabac"
    //Explanation: 
    //str1 = "abac" is a subsequence of "cabac" because we can delete the first "c".
    //str2 = "cab" is a subsequence of "cabac" because we can delete the last "ac".
    //The answer provided is the shortest such string that satisfies these properties.


    //Note:

    //1 <= str1.length, str2.length <= 1000
    //str1 and str2 consist of lowercase English letters.

    public class Solution
    {
        public string ShortestCommonSupersequence(string baseStr, string compareStr)
        {

            if (baseStr.Length < compareStr.Length)
            {
                var tempStr = baseStr;
                baseStr = compareStr;
                compareStr = tempStr;
            }
            string combinedStr;
            combinedStr = compareStr + baseStr;

            for (int bi = 0; bi < baseStr.Length; bi++)
            {
                var shouldCombine = true;
                for (int ci = compareStr.Length - 1; ci >= 0; ci--)
                {
                    var biIndex = bi + ci + 1 - compareStr.Length;
                    if (biIndex < 0)
                    {
                        break;
                    }

                    if (compareStr[ci] != baseStr[biIndex])
                    {
                        shouldCombine = false;
                        break;
                    }
                }

                if (shouldCombine)
                {
                    var newCombinedString = baseStr;
                    if (bi < compareStr.Length - 1)
                    {
                        int shift = compareStr.Length - 1 - bi;
                        var sub = compareStr.Substring(0, shift);
                        newCombinedString = sub + newCombinedString;

                    }
                    
                    if (newCombinedString.Length < combinedStr.Length)
                    {
                        combinedStr = newCombinedString;
                    }
                }
            }

            return combinedStr;
        }
    }

    public class ShortestCommonSupersequenceTests
    {
        private Solution solution;

        public ShortestCommonSupersequenceTests()
        {
            solution = new Solution();
        }

        [Theory]
        [InlineData("abac", "cab", "cabac")]
        [InlineData("michal", "chal", "michal")]
        [InlineData("mich", "chal", "michal")]
        public void ShortestCommonSupersequenceOfTwoStringTests(string str1, string str2, string expected)
        {
            var output = solution.ShortestCommonSupersequence(str1, str2);

            Assert.Equal(expected, output);
        }
    }
}
