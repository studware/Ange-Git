using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class Minesweeper
    {
        private const int MaxEmptyCells = 35;

        public static void Main()
        {
            string command = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] mines = DeployMines();
            int cellsOpened = 0;
            bool boom = false;
            var topPlayers = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool startGame = true;
            bool gameFinished = false;

            do
            {
                if (startGame)
                {
                    Console.WriteLine("Let's play “Minesweeper”. Try your chance to find the cells without mines." +
                    " Command 'top' shows the scores, 'restart' starts new play, 'exit' to exit and say goodbye!");
                    DrawField(gameField);
                    startGame = false;
                }

                Console.Write("Input row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScoreBoard(topPlayers);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        mines = DeployMines();
                        DrawField(gameField);
                        boom = false;
                        startGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye!");
                        break;
                    case "turn":
                        if (mines[row, column] != '*')
                        {
                            if (mines[row, column] == '-')
                            {
                                UpdateField(gameField, mines, row, column);
                                cellsOpened++;
                            }

                            if (cellsOpened == MaxEmptyCells)
                            {
                                gameFinished = true;
                            }
                            else
                            {
                                DrawField(gameField);
                            }
                        }
                        else
                        {
                            boom = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (boom)
                {
                    DrawField(mines);
                    Console.Write("\nHrrrrrr! Died as a hero with {0} scores. Enter your nickname: ", cellsOpened);
                    string nickname = Console.ReadLine();
                    var player = new Player(nickname, cellsOpened);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < player.Points)
                            {
                                topPlayers.Insert(i, player);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    PrintScoreBoard(topPlayers);

                    gameField = CreateGameField();
                    mines = DeployMines();
                    cellsOpened = 0;
                    boom = false;
                    startGame = true;
                }

                if (gameFinished)
                {
                    Console.WriteLine("\nGood for you! You opened 35 cells without a drop of blood.");
                    DrawField(mines);
                    Console.WriteLine("Your name: ");
                    string name = Console.ReadLine();
                    var score = new Player(name, cellsOpened);
                    topPlayers.Add(score);
                    PrintScoreBoard(topPlayers);
                    gameField = CreateGameField();
                    mines = DeployMines();
                    cellsOpened = 0;
                    gameFinished = false;
                    startGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Seeee you laaaaaaaaateeeeeeeeer.");
            Console.Read();
            }

        private static void PrintScoreBoard(List<Player> players)
        {
            Console.WriteLine("\nPlayers:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void UpdateField(char[,] cell, char[,] mines, int row, int column)
        {
            char adjacentMines = CountAdjacentMines(mines, row, column);
            mines[row, column] = adjacentMines;
            cell[row, column] = adjacentMines;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] DeployMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            var bombCells = new List<int>();
            while (bombCells.Count < 15)
            {
                Random random = new Random();
                int cell = random.Next(50);
                if (!bombCells.Contains(cell))
                {
                    bombCells.Add(cell);
                }
            }

            foreach (var cell in bombCells)
            {
                int col = cell / cols;
                int row = cell % cols;
                if (row == 0 && cell != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static char CountAdjacentMines(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
