using System;

namespace Lab5
{
    class Sudoku
    {
        public int[,] sudokuMatrix = new int[,] {
            { 2, 3, 0, 4, 1, 5, 0, 6, 8 },
            { 0, 8, 0, 2, 3, 6, 5, 1, 9 },
            { 1, 6, 0, 9, 8, 7, 2, 3, 4 },
            { 3, 1, 7, 0, 9, 4, 0, 2, 5 },
            { 4, 5, 8, 1, 2, 0, 6, 9, 7 },
            { 9, 2, 6, 0, 5, 8, 3, 0, 1 },
            { 0, 0, 0, 5, 0, 0, 1, 0, 2 },
            { 0, 0, 0, 8, 4, 2, 9, 0, 3 },
            { 5, 9, 2, 3, 7, 1, 4, 8, 6 }
        };
        public void PrintSudokuMatrix(int[,] matr)
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((j + 1) % 3 == 0)
                    {
                        Console.Write($"{matr[i, j]}   ");
                    }
                    else 
                    { 
                        Console.Write($"{matr[i, j]} "); 
                    }
                }
                Console.WriteLine();                                   
                if (((i + 1) % 3 == 0) && (i != 8)) Console.WriteLine();
            }
            Console.WriteLine();
        }
        private bool NotExistInRow(int i, int num)
        {
            for (int j = 0; j < 9; j++)
            {
                if (sudokuMatrix[i, j] == num)
                {
                    return false;
                }
            }
            return true;
        }
        private bool NotExistInCol(int j, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudokuMatrix[i, j] == num)
                {
                    return false;
                }
            }
            return true;
        }
        private bool NotExistInBox(int row, int col, int num)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sudokuMatrix[row + i, col + j] == num)
                    {
                        return false;
                    }
                        
                }
            }
            return true;
        }
        private bool CheckNum(int i, int j, int num)
        {
            return (NotExistInRow(i, num) &&
                    NotExistInCol(j, num) &&
                    NotExistInBox(i - i % 3, j - j % 3, num));
        }
        public void FillTable(int i, int j, int num)
        {
            if ((CheckNum(i, j, num) == true) && (sudokuMatrix[i, j] == 0))
            {
                sudokuMatrix[i, j] = num;
            }
            else
            {
                Console.WriteLine("\nYou can't do this.");
            }
            PrintSudokuMatrix(sudokuMatrix);
        }
        public Memento SaveSudokuMatrixState()
        {
            Console.WriteLine("Save progress");
            int[,] newsudokuMatrix = sudokuMatrix.Clone() as int[,];
            return new Memento(newsudokuMatrix);
        }
        public void RestoreState(Memento memento)
        {
            this.sudokuMatrix = memento.sudokuMatrix;
            Console.WriteLine("Recovered progress. Your sudoku matrix:");
            PrintSudokuMatrix(memento.sudokuMatrix);
        }
    }
}

