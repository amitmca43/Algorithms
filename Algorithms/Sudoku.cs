using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Sudoku;

namespace Algorithms
{
    public class Sudoku
    { 
        public class PossibleValues
        {
            public int Row;
            public int Col;
            public List<int> Values;
        }

        static int[] PossilbeValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        static List<PossibleValues> PossibleValuesList = new List<PossibleValues>();


        public static void Solve(int[,] sudoku)
        {           
            GetPossibleValuesList(sudoku);
            SolveSudoku(sudoku);
        }

        private static bool SolveSudoku(int[,] sudoku)
        {
            var emptyCell = GetEmptyCell(sudoku);
            if(emptyCell.row == -1)
            {
                return true;
            }

            foreach (var possibleValue in PossibleValuesList.First(x => x.Row == emptyCell.row && x.Col == emptyCell.col).Values)
            {
                if(IsValidCellValue(sudoku, emptyCell.row, emptyCell.col, possibleValue))
                {
                    sudoku[emptyCell.row, emptyCell.col] = possibleValue;

                    if(SolveSudoku(sudoku))
                    {
                        return true;
                    }

                    sudoku[emptyCell.row, emptyCell.col] = 0;                  
                }
            }

            return false;
        }

        private static bool IsValidCellValue(int[,] sudoku, int row, int col, int possibleValue)
        {
            int rowStart, colStart;

            rowStart = (row / 3) * 3;
            colStart = (col / 3) * 3;

            for (int temp = 0; temp < 9; temp++)
            {
                if (sudoku[row, temp] == possibleValue) return false;
                if (sudoku[temp, col] == possibleValue) return false;
                if (sudoku[rowStart + (temp % 3), colStart + (temp % 3)] == possibleValue) return false;
            }

            return true;
        }

        private static (int row, int col) GetEmptyCell(int[,] sudoku)
        {   
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudoku[row, col] == 0)
                    {
                        return (row, col);
                    }
                }
            }

            return ( -1,  -1);
        }

        private static void GetPossibleValuesList(int[,] sudoku)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (sudoku[row, col] == 0)
                    {
                        List<int> possilbeVaues = GetPossileValues(sudoku, row, col);

                        if (possilbeVaues.Count() == 1)
                        {
                            sudoku[row, col] = possilbeVaues.FirstOrDefault();
                        }
                        else if (possilbeVaues.Count() > 1)
                        {
                            PossibleValuesList.Add(new PossibleValues
                            {
                                Row = row,
                                Col = col,
                                Values = possilbeVaues
                            });
                        }
                    }
                }
            }             
        }

        private static List<int> GetPossileValues(int[,] unsolvedSudoku, int row, int col)
        {
            List<int> posibleValues = new List<int>(PossilbeValues);

            //Eliminate Row and Column values
            for (int temp = 0; temp < 9; temp++)
            {
                if (unsolvedSudoku[row, temp] != 0 && temp != col)
                {
                    posibleValues.Remove(unsolvedSudoku[row, temp]);
                }

                if (unsolvedSudoku[temp, col] != 0 && temp != row)
                {
                    posibleValues.Remove(unsolvedSudoku[temp, col]);
                }
            }

            //Eliminate sub-matrix values
            RemoveSubMatrixValues(unsolvedSudoku, posibleValues, row, col);

            return posibleValues;
        }

        private static void RemoveSubMatrixValues(int[,] unsolvedSudoku, List<int> posibleValues, int row, int col)
        {
            int rowStart, colStart, rowEnd, colEnd;

            rowStart = (row / 3) * 3;
            colStart = (col / 3) * 3;

            rowEnd = rowStart + 2;
            colEnd = colStart + 2;

            for(int i = rowStart; i <= rowEnd; i++)
            {
                if (i == row)
                    continue;

                for(int j= colStart; j <= colEnd; j++)
                {
                    if (j == col)
                        continue;

                    if (unsolvedSudoku[i, j] != 0)
                    {
                        posibleValues.Remove(unsolvedSudoku[i, j]);
                    }
                }
            }
        }
    }
}
