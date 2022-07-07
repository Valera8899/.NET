using System;
using System.Collections.Generic;

namespace Lab5
{
    class SudokuHistory
    {
        public Stack<Memento> History { get; private set; }

        public SudokuHistory() { this.History = new Stack<Memento>(); }
    }
}
