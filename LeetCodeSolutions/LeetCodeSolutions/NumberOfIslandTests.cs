using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutions
{
    /* https://leetcode.com/problems/number-of-islands/
     200. Number of Islands
Medium
Given an m x n 2d grid map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

 

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1
Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/
    class NumberOfIslandTests
    {
        public class PaymanSolution
        {
            int m = 0;
            int n = 0;
            char[][] _grid;
            public int NumIslands(char[][] grid)
            {
                m = grid.Length;
                n = grid[0].Length;
                _grid = grid;

                int islandCount = 0;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (_grid[i][j] == '1')
                        {
                            SetToZero(i, j);
                            islandCount++;
                        }
                    }
                }
                return islandCount;
            }

            private void SetToZero(int i, int j)
            {
                if (i < 0 || i >= m || j < 0 || j >= n || _grid[i][j] == '0')
                {
                    return;
                }
                _grid[i][j] = '0';
                var rowOffset = new[] { -1, 0, 1, 0 };
                var colOffset = new[] { 0, 1, 0, -1 };
                for (int k = 0; k < 4; k++)
                {
                    SetToZero(i + rowOffset[k], j + colOffset[k]);
                }
            }
        }

        public class MySolution
        {
            private const char IslandChar = '1';

            public int NumIslands(char[][] grid)
            {
                int count = 0;
                var hashedIslandsGridCoordinates = new HashSet<int>();
                for (int rowNo = 0; rowNo < grid.Length; rowNo++)
                {
                    for (int columnNo = 0; columnNo < grid[rowNo].Length; columnNo++)
                    {
                        var gridItem = grid[rowNo][columnNo];

                        if (IsIsland(gridItem) && !hashedIslandsGridCoordinates.Contains(HashGridCoordinates(rowNo, columnNo)))
                        {
                            count++;

                            Stack<(int, int)> neibours = new Stack<(int, int)>();
                            neibours.Push((rowNo, columnNo));

                            while (neibours.TryPop(out var currentItem))
                            {
                                if (hashedIslandsGridCoordinates.Add(HashGridCoordinates(currentItem.Item1, currentItem.Item2)))
                                {
                                    var rowNoToCheck = currentItem.Item1 + 1;
                                    var columnNoToCheck = currentItem.Item2;

                                    if (IsElementAnIsland(grid, rowNoToCheck, columnNoToCheck))
                                    {
                                        neibours.Push((rowNoToCheck, columnNoToCheck));
                                    }

                                    rowNoToCheck = currentItem.Item1 - 1;
                                    columnNoToCheck = currentItem.Item2;

                                    if (IsElementAnIsland(grid, rowNoToCheck, columnNoToCheck))
                                    {
                                        neibours.Push((rowNoToCheck, columnNoToCheck));
                                    }

                                    rowNoToCheck = currentItem.Item1;
                                    columnNoToCheck = currentItem.Item2 + 1;

                                    if (IsElementAnIsland(grid, rowNoToCheck, columnNoToCheck))
                                    {
                                        neibours.Push((rowNoToCheck, columnNoToCheck));
                                    }

                                    rowNoToCheck = currentItem.Item1;
                                    columnNoToCheck = currentItem.Item2 - 1;

                                    if (IsElementAnIsland(grid, rowNoToCheck, columnNoToCheck))
                                    {
                                        neibours.Push((rowNoToCheck, columnNoToCheck));
                                    }
                                }
                            }
                        }
                    }
                }

                return count;
            }


            private bool IsIsland(char c) => c == IslandChar;

            private int HashGridCoordinates(int rowNo, int columnNo)
            {
                var hash = rowNo;
                hash = hash << 16;
                hash = hash | columnNo;
                return hash;
            }

            private bool IsElementAnIsland(char[][] grid, int rowNo, int columnNo)
            {
                return 0 <= rowNo && rowNo < grid.Length && 0 <= columnNo && columnNo < grid[rowNo].Length && IsIsland(grid[rowNo][columnNo]);
            }
        }

    }
}
