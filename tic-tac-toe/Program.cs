using System;

namespace tic_tac_toe
{
    class Program
    {
        class Game
        {
            private PrintGameField Print;
            public void StartGame(char[,] field, int[,] steps)
            {
                Print.ShowTheField(field);
                for (int i = 0; i < steps.GetUpperBound(0) + 2; i++)
                {
                    int testwin = isWin(field);
                    if (testwin == ' ')
                    {
                        if (i % 2 == 0)
                        {
                            field = DoStep(field, steps[i, 0], steps[i, 1], 'x');
                        }
                        else
                        {
                            field = DoStep(field, steps[i, 0], steps[i, 1], 'o');
                        }
                        Print.ShowTheField(field);
                    }
                    else if (testwin == 'x')
                    {
                        System.Console.WriteLine("Win: X");
                        break;
                    }
                    else if (testwin == 'o')
                    {
                        System.Console.WriteLine("Win: O");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("No one win!");
                        break;
                    }
                }
            }

            private char[,] DoStep(char[,] field, int row, int col, char XorO)
            {
                if (XorO == 'x' || XorO == 'o')
                {
                    if (checkCell(row, col, field))
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

            private bool checkCell(int row, int col, char[,] field)
            {
                if (field[row, col] == ' ') return true;
                else return false;
            }
            private char isWin(char[,] field)
            {
                string isX = "xxx";
                string isO = "ooo";
                if (isDiagonal(field, isX)) return 'x';
                else if (isDiagonal(field, isO)) return 'o';
                else if (isHorisontal(field, isX)) return 'x';
                else if (isHorisontal(field, isO)) return 'o';
                else if (isVertical(field, isX)) return 'x';
                else if (isVertical(field, isO)) return 'o';
                else if (isСellsAreFree(field)) return ' ';
                else return 'y';
            }


            private bool isСellsAreFree(char[,] field)
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

            private bool isVertical(char[,] field, string XorO)
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
            private bool isDiagonal(char[,] field, string XorO)
            {
                if ($"{field[0, 0]}{field[1, 1]}{field[2, 2]}" == XorO) return true;
                else if ($"{field[0, 2]}{field[1, 1]}{field[2, 0]}" == XorO) return true;
                else return false;
            }
            private bool isHorisontal(char[,] field, string XorO)
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
            public void PrintWiner()
            {

            }
        }
        static void Main()
        {
            char[,] field = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            int[,] steps = { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 }, { 2, 2 } };

            Game firstGame = new Game();
            firstGame.StartGame(field, steps);




        }



    }
}