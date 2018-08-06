using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
         
        public static void Solve(int[,] sudoku)
        {
            var possibleValuesList = new List<PossibleValues>();

            while (true)
            {               
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (sudoku[row, col] == 0)
                        {
                            if (possibleValuesList.Count() == 0)
                            {
                                List<int> possilbeVaues = GetPossileValues(sudoku, row, col);

                                if (possilbeVaues.Count() == 1)
                                {
                                    sudoku[row, col] = possilbeVaues.FirstOrDefault();
                                }
                                else if (possilbeVaues.Count() > 1)
                                {
                                    possibleValuesList.Add(new PossibleValues
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

                if (possibleValuesList.Count() == 0)
                    break;
            }
        }

        private static List<int> GetPossileValues(int[,] unsolvedSudoku, int row, int col)
        {
            List<int> posibleValues = new List<int>(PossilbeValues);

            posibleValues.Remove(unsolvedSudoku[row, col]);

            //Eliminate Row values
            for (int tempCol = 0; tempCol < 9; tempCol++)
            {
                if (unsolvedSudoku[row, tempCol] != 0 && tempCol != col)
                {
                    posibleValues.Remove(unsolvedSudoku[row, tempCol]);
                }
            }

            //Eliminate Column values
            for (int tempRow = 0; tempRow < 9; tempRow++)
            {
                if (unsolvedSudoku[tempRow, col] != 0 && tempRow != row)
                {
                    posibleValues.Remove(unsolvedSudoku[tempRow, col]);
                }
            }

            //Eliminate sub-matrix values
            RemoveSubMatrixValues(unsolvedSudoku, posibleValues, row, col);

            return posibleValues;
        }

        private static void RemoveSubMatrixValues(int[,] unsolvedSudoku, List<int> posibleValues, int row, int col)
        {
            int rowStart, colStart, rowEnd, colEnd;
           
            if(row < 3)
            {
                rowStart = 0;
            } 
            else if(row > 2 && row < 6)
            {
                rowStart = 3;
            } else
            {
                rowStart = 6;
            }

            if(col < 3)
            {
                colStart = 0;
            } 
            else if(col > 2 && col < 6)
            {
                colStart = 3;
            }
            else
            {
                colStart = 6;
            }

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
