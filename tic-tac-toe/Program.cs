using System;

namespace tic_tac_toe
{
    class Program
    {
        class Game
        {
            public char[,] field = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            static private string isX = "xxx";
            static private string isO = "ooo";
            public char[,] DoStep( int row, int col, char XorO)
            {
                if (XorO == 'x' || XorO == 'o')
                {
                    if (checkCell(row, col))
                    {
                        field[row, col] = XorO;
                        return field;
                    }
                    else
                    {
                        System.Console.WriteLine("Cell is not free");
                        return field;
                    }
                }
                else
                {
                    System.Console.WriteLine("Enter the right value");
                    return field;
                }
            }

            private bool checkCell(int row, int col)
            {
                if (field[row, col] == ' ') return true;
                else return false;
            }
            public char isWin()
            {
                
                if (isDiagonal(isX)) return 'x';
                else if (isDiagonal(isO)) return 'o';
                else if (isHorisontal(isX)) return 'x';
                else if (isHorisontal(isO)) return 'o';
                else if (isVertical(isX)) return 'x';
                else if (isVertical(isO)) return 'o';
                else if (isСellsAreFree()) return ' ';
                else return 'e';
            }


            private bool isСellsAreFree()
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (field[i, j] == ' ') return true;
                    }
                }
                return false;
            }

            private bool isVertical(string XorO)
            {
                for (int i = 0; i < 3; i++)
                {
                    string resultLine = null;
                    for (int j = 0; j < 3; j++)
                    {
                        resultLine = resultLine + field[j, i];
                        if (resultLine == XorO) return true;
                    }
                }
                return false;
            }
            private bool isDiagonal(string XorO)
            {
                if ($"{field[0, 0]}{field[1, 1]}{field[2, 2]}" == XorO) return true;
                else if ($"{field[0, 2]}{field[1, 1]}{field[2, 0]}" == XorO) return true;
                else return false;
            }
            private bool isHorisontal(string XorO)
            {
                for (int i = 0; i < 3; i++)
                {
                    string resultLine = null;
                    for (int j = 0; j < 3; j++)
                    {
                        resultLine = resultLine + field[i, j];
                        if (resultLine == XorO) return true;
                    }
                }
                return false;
            }
        }

        class PrintGameField
        {
            public void ShowTheField(char[,] field)
            {
                string show = transformField(field);
                Console.WriteLine(show);
            }

            private string transformField(char[,] field)
            {
                string transform = null;

                for (int i = 0; i < field.GetUpperBound(0) + 1; i++)
                    transform += $"{field[i, 0]}|{field[i, 1]}|{field[i, 2]} \n";
                return transform;
            }
            public void PrintWiner(char testwin)
            {
                if (testwin == 'e')
                {
                    Console.WriteLine("No one win!");
                }
                else
                {
                    Console.WriteLine($"Win: {testwin.ToString().ToUpper()}");

                }
            }
        }
        static void Main()
        {
            int[,] steps = { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 }, { 2, 2 } };

            Game StartGame = new Game();
            PrintGameField PrintField = new PrintGameField();

            PrintField.ShowTheField(StartGame.field);
            for (int i = 0; i < steps.GetUpperBound(0) + 2; i++)
            {
                char testwin = StartGame.isWin();
                if (testwin == ' ')
                {
                    if (i % 2 == 0)
                    {
                        StartGame.field = StartGame.DoStep(steps[i, 0], steps[i, 1], 'x');
                    }
                    else
                    {
                        StartGame.field = StartGame.DoStep(steps[i, 0], steps[i, 1], 'o');
                    }
                    PrintField.ShowTheField(StartGame.field );
                }
                else
                {
                    PrintField.PrintWiner(testwin);
                    break;
                }
            }
            
        }
    }
}