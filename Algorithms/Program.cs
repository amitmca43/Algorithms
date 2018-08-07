using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static int[,] unsolvedSudoku =
        {
            { 0,8,0,0,0,0,0,7,4 },
            { 0,0,3,4,0,0,2,0,0 },
            { 0,0,6,0,0,2,0,0,0 },
            { 0,3,0,0,9,8,0,6,0},
            { 7,0,0,0,0,0,0,0,8},
            { 0,4,0,5,1,0,0,9,0},
            { 0,0,0,3,0,0,1,0,0},
            { 0,0,4,0,0,9,7,0,0},
            { 5,9,0,0,0,0,0,8,0},

        };
        static void Main(string[] args)
        {
            Console.WriteLine("Unsolved Sudoku:");
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(unsolvedSudoku[row, col] + "  ");
                }
                Console.WriteLine();
            }
            Sudoku.Solve(unsolvedSudoku);

            //SudokuSolver.SolveSudoku(unsolvedSudoku, 0, 0);

            Console.WriteLine("\n\n Solved Sudoku:");
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(unsolvedSudoku[row, col] + "  ");
                }
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
