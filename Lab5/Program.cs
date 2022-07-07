using System;
using System.Linq;

namespace Lab5
{
    class Program
    {
        /*Реалізувати алгоритм гри судоку. Реалізувати можливість «взяти назад хід».    */
        static void Main()
        {
            string choice;
            int num;
            int i;
            int j;         
            Sudoku game = new Sudoku();
            SudokuHistory sudokuHistory = new SudokuHistory();

            Console.WriteLine("Your initial sudoku matrix: "); game.PrintSudokuMatrix(game.sudokuMatrix);

            while (game.sudokuMatrix.Cast<int>().ToList().Any(val => val == 0))
            {
                Console.WriteLine("\nEnter a number and coordinates for it:");
                Console.Write("Row: "); i = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Column: "); j = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Number: "); num = Convert.ToInt32(Console.ReadLine());

                sudokuHistory.History.Push(game.SaveSudokuMatrixState());
                game.FillTable(i, j, num);
                do
                {
                    Console.Write("Continue — press Enter, \n" +
                                  "Go back  — input  1, \n" +
                                  "Exit     — input -1: \n");
                    choice = Console.ReadLine();

                    if (choice == "-1") return;
                    if (sudokuHistory.History.Count == 0)
                    {
                        Console.WriteLine("You can't go back! There is nothing to recover.");
                        break;
                    }
                    if (choice == "1")
                    {
                        game.RestoreState(sudokuHistory.History.Pop());
                    }
                } while (!string.IsNullOrEmpty(choice));
            }
        }
    }
}
