using System;
using System.Collections.Generic;

class EightQueens
{
    static int boardSize = 8;

    static bool IsSafe(List<int> queens, int row, int col)
    {
        for (int prevRow = 0; prevRow < row; prevRow++)
        {
            int prevCol = queens[prevRow];

            if (prevCol == col || prevRow + prevCol == row + col || prevRow - prevCol == row - col)
            {
                return false;
            }
        }
        return true;
    }

    static void PrintSolution(List<int> queens)
    {
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (queens[row] == col)
                {
                    Console.Write("Q ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Stack<List<int>> solutions = new Stack<List<int>>();
        List<int> queens = new List<int>(boardSize);

        for (int i = 0; i < boardSize; i++)
        {
            queens.Clear();
            queens.Add(i);
            solutions.Push(new List<int>(queens));
        }

        while (solutions.Count > 0)
        {
            queens = solutions.Pop();

            if (queens.Count == boardSize)
            {
                PrintSolution(queens);
                continue;
            }

            int nextRow = queens.Count;
            for (int nextCol = 0; nextCol < boardSize; nextCol++)
            {
                if (IsSafe(queens, nextRow, nextCol))
                {
                    queens.Add(nextCol);
                    solutions.Push(new List<int>(queens));
                    queens.RemoveAt(queens.Count - 1);
                }
            }
        }
    }
}