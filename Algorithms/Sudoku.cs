using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sudoku
    {
        int[,] unsolvedSudoku =
        {
            { 1,6,4,0,0,0,0,0,2 },
            { 2,0,0,4,0,3,9,1,0 },
            { 0,0,5,0,8,0,4,0,7 },
            { 0,9,0,0,0,6,5,0,0},
            { 5,0,0,1,0,2,0,0,8},
            { 0,0,8,9,0,0,0,3,0},
            { 8,0,9,0,4,0,2,0,0},
            { 0,7,3,5,0,9,0,0,1},
            { 4,0,0,0,0,0,6,7,9},

        };

        static int[] PossilbeValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public 
        public static int[,] Solve(int[,] unsolvedSudoku)
        {
            for(int row =0; row < 9; row++ )
            {
                for (int col = 0; col < 9; col++)
                {
                    if(unsolvedSudoku[row,col] == 0)
                    {
                        int[] possilbeVaues = GetPossileValues(unsolvedSudoku, row, col);
                    }

                }
            }
        }

        private static int[] GetPossileValues(int[,] unsolvedSudoku, int row, int col)
        {
            List<int> posibleValues = new List<int>(PossilbeValues);
            
            //Eliminate Row values
            for (int tempCol = 0; tempCol < 9; tempCol++)
            {
                if (unsolvedSudoku[row, tempCol] != 0)
                {
                    posibleValues.Remove(unsolvedSudoku[row, tempCol]);
                }
            }

            //Eliminate Column values
            for (int tempRow = 0; tempRow < 9; tempRow++)
            {
                if (unsolvedSudoku[tempRow, col] != 0)
                {
                    posibleValues.Remove(unsolvedSudoku[tempRow, col]);
                }
            }

            //Eliminate sub-matrix values
            GetSubMatrixPossileValues(unsolvedSudoku, posibleValues, row, col);

            return posibleValues.ToArray();
        }

        private static void GetSubMatrixPossileValues(int[,] unsolvedSudoku, List<int> posibleValues, int row, int col)
        {
            int rowStart, colStart, rowEnd, colEnd;
           
            if(row < 3)
            {
                rowStart = 0;
            } 
            else if(row > 2 && row < 6)
            {
                rowStart = 5;
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
                for(int j= colStart; i <= colEnd; j++)
                {
                    if (unsolvedSudoku[i, j] != 0)
                    {
                        posibleValues.Remove(unsolvedSudoku[i, j]);
                    }
                }
            }
        }
    }
}
