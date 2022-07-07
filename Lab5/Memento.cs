using System;

namespace Lab5
{
    class Memento
    {
        public int[,] sudokuMatrix { get; private set; }

        public Memento(int[,] SudokuMatrix) { this.sudokuMatrix = SudokuMatrix;  }
    }
}
