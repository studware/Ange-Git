using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MineSweeper
{
    public static void Main()
	{
        string command = string.Empty;
		char[,] gameField = CreateGameField();
		char[,] theMines = PutTheMines();
		int counter = 0;
		bool mineExploded = false;
		List<PlayerScores> champions = new List<PlayerScores>(6);
		int row = 0;
		int column = 0;
		bool startGame = true;
		const int MAXTURNS = 35;
		bool startNextLevel = false;

		do
		{
			if (startGame)
			{
                Console.WriteLine("Let's play “MineSweeper”. Try your luck to find fields without mines." +
				"\nCommand \"top\" shows the rating\n\"restart\" start new game\n\"exit\" stop the game and bye!");
				DisplayGameBoard(gameField);
				startGame = false;
			}

			Console.Write("Enter row and column: ");
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
					Rating(champions);
					break;
				case "restart":
					gameField = CreateGameField();
					theMines = PutTheMines();
					DisplayGameBoard(gameField);
					mineExploded = false;
					startGame = false;
					break;
				case "exit":
					Console.WriteLine("Chao, Chao, Chao!");
					break;
				case "turn":
					if (theMines[row, column] != '*')
					{
						if (theMines[row, column] == '-')
						{
							YourTurn(gameField, theMines, row, column);
							counter++;
						}

						if (counter == MAXTURNS)
						{
							startNextLevel = true;
						}
						else
						{
							DisplayGameBoard(gameField);
						}
					}
					else
					{
						mineExploded = true;
					}

					break;
				default:
					Console.WriteLine("\nError! Invalid command.\n");
					break;
			}

			if (mineExploded)
			{
				DisplayGameBoard(theMines);
				Console.Write("Hrrrrr! Died heroically with {0} points. " + " Enter the nickname: ", counter);
				string nickName = Console.ReadLine();
				PlayerScores personalScores = new PlayerScores(nickName, counter);
				if (champions.Count < 5)
				{
					champions.Add(personalScores);
				}
				else
				{
					for (int i = 0; i < champions.Count; i++)
					{
						if (champions[i].Scores < personalScores.Scores)
						{
							champions.Insert(i, personalScores);
							champions.RemoveAt(champions.Count - 1);
							break;
						}
					}
				}

				champions.Sort((PlayerScores player1, PlayerScores player2) => player2.Name.CompareTo(player1.Name));
				champions.Sort((PlayerScores player1, PlayerScores player2) => player2.Scores.CompareTo(player1.Scores));
				Rating(champions);

				gameField = CreateGameField();
				theMines = PutTheMines();
				counter = 0;
				mineExploded = false;
				startGame = true;
			}

			if (startNextLevel)
			{
                Console.WriteLine("\nBRAVOOOOS! 35 holes open without a drop of blood cells.");
				DisplayGameBoard(theMines);
                Console.WriteLine("Enter your name, brother: ");
				string currentPlayer = Console.ReadLine();
				PlayerScores currentPlayerScores = new PlayerScores(currentPlayer, counter);
				champions.Add(currentPlayerScores);
				Rating(champions);
				gameField = CreateGameField();
				theMines = PutTheMines();
				counter = 0;
				startNextLevel = false;
				startGame = true;
			}
		}
		while (command != "exit");
		Console.WriteLine("Made in Bulgaria - Wowhahahaha!");
		Console.WriteLine("Gooooooooooooo.");
		Console.Read();
	}

    private static void Rating(List<PlayerScores> currentPlayerScores)
	{
		Console.WriteLine("\nRating:");
		if (currentPlayerScores.Count > 0)
		{
			for (int i = 0; i < currentPlayerScores.Count; i++)
			{
				Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, currentPlayerScores[i].Name, currentPlayerScores[i].Scores);
			}

			Console.WriteLine();
		}
		else
		{
			Console.WriteLine("Empty rating!\n");
		}
	}

	private static void YourTurn(char[,] field, char[,] mines, int currentRow, int currentColumn)
	{
		char countOfMines = CountMines(mines, currentRow, currentColumn);
		mines[currentRow, currentColumn] = countOfMines;
		field[currentRow, currentColumn] = countOfMines;
	}

	private static void DisplayGameBoard(char[,] board)
	{
		int boardRowsNumber = board.GetLength(0);
		int boardColumnsNumber = board.GetLength(1);
		Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
		Console.WriteLine("   ---------------------");
		for (int i = 0; i < boardRowsNumber; i++)
		{
			Console.Write("{0} | ", i);
			for (int j = 0; j < boardColumnsNumber; j++)
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

	private static char[,] PutTheMines()
	{
		int numberOfRows = 5;
		int numberOfColumns = 10;
		char[,] gameField = new char[numberOfRows, numberOfColumns];

		for (int i = 0; i < numberOfRows; i++)
		{
			for (int j = 0; j < numberOfColumns; j++)
			{
				gameField[i, j] = '-';
			}
		}

		List<int> randomNumbers = new List<int>();
		while (randomNumbers.Count < 15)
		{
			Random random = new Random();
			int nextRandom = random.Next(50);
			if (!randomNumbers.Contains(nextRandom))
			{
				randomNumbers.Add(nextRandom);
			}
		}

		foreach (int randomNumber in randomNumbers)
		{
			int column = randomNumber / numberOfColumns;
			int row = randomNumber % numberOfColumns;
			if (row == 0 && randomNumber != 0)
			{
				column--;
				row = numberOfColumns;
			}
			else
			{
				row++;
			}

			gameField[column, row - 1] = '*';
		}

		return gameField;
	}

	private static char CountMines(char[,] mines, int row, int column)
	{
		int countOfMines = 0;
		int rows = mines.GetLength(0);
		int columns = mines.GetLength(1);

		if (row - 1 >= 0)
		{
			if (mines[row - 1, column] == '*')
			{ 
				countOfMines++; 
			}
		}

		if (row + 1 < rows)
		{
			if (mines[row + 1, column] == '*')
			{ 
				countOfMines++; 
			}
		}

		if (column - 1 >= 0)
		{
			if (mines[row, column - 1] == '*')
			{ 
				countOfMines++;
			}
		}

		if (column + 1 < columns)
		{
			if (mines[row, column + 1] == '*')
			{ 
				countOfMines++;
			}
		}

		if ((row - 1 >= 0) && (column - 1 >= 0))
		{
			if (mines[row - 1, column - 1] == '*')
			{ 
				countOfMines++; 
			}
		}

		if ((row - 1 >= 0) && (column + 1 < columns))
		{
			if (mines[row - 1, column + 1] == '*')
			{ 
				countOfMines++; 
			}
		}

		if ((row + 1 < rows) && (column - 1 >= 0))
		{
			if (mines[row + 1, column - 1] == '*')
			{ 
				countOfMines++; 
			}
		}

		if ((row + 1 < rows) && (column + 1 < columns))
		{
			if (mines[row + 1, column + 1] == '*')
			{ 
				countOfMines++; 
			}
		}

		return char.Parse(countOfMines.ToString());
	}

    public class PlayerScores
    {
        private string name;
        private int scores;

        public PlayerScores()
        {
        }

        public PlayerScores(string name, int scores)
        {
            this.Name = name;
            this.Scores = scores;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Scores
        {
            get { return this.scores; }
            set { this.scores = value; }
        }
    }
}