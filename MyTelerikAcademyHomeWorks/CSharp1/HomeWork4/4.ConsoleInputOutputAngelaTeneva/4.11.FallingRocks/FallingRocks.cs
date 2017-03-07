using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

class FallingRocks
{
    public static int newWidth;
    public static int newHeight;
    public static int oldWindowSizeX;
    public static int oldWindowSizeY;
    public static int oldBufferSizeX;
    public static int oldBufferSizeY;

    public static StringBuilder randString;
    public static Random rand = new Random();
    public static ConsoleKey key = ConsoleKey.Spacebar;
    public static ConsoleKeyInfo keyInfo;
    public static int sleep = 150;

    public static int startCount = 2;
    public static int difficulty = 0;
    public static int playerX = 0;
    public static int playerY = 0;
    public static bool movePlayer = true;
    public static int score = 0;
    public static bool redrawScore = true;
    public static bool playGame = true;

    public static int lastDensity = 0;
    public static readonly char[] rockTypes = { 'X', '@', 'W', '&', '+', '%', '$', '#', 'D', '\u0001', '\u0002', 'O' };
    public static Queue<int> rockX = new Queue<int>();
    public static Queue<int> rockDensity = new Queue<int>();
    public static List<int> goodX = new List<int>();
    public static List<int> goodY = new List<int>();
    public static bool evenTurn = true;

    public static void Main()
    {
        WelcomeScreen();
        while (playGame)
        {
            StartGame();
            key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.Escape)
            {
                if (Console.KeyAvailable)
                {
                    movePlayer = true;
                    keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;
                    ClearInputStreamBuffer();
                }
                if (key == ConsoleKey.Spacebar) { PauseGame(); }
                Console.MoveBufferArea(0, 2, newWidth, newHeight - 3, 0, 3);
                DrawNewRocks();
                GetNewData();
                CheckCollision();
                DrawScore();
                MovePlayer();
                Thread.Sleep(sleep);
                if (!playGame) { break; }
            }
            ResetGame();
        }
        EndGame();
    }

    public static void PauseGame()
    {
        Console.ReadKey(true);
        key = ConsoleKey.Enter;
    }

    public static void ClearInputStreamBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }

    public static void ResetGame()
    {
        if (key != ConsoleKey.Escape)
        {
            redrawScore = true;
            DrawScore();
            Console.Beep(100, 1000);
            Console.ForegroundColor = ConsoleColor.Magenta;

            // Game Over
            Console.Clear();
            Console.SetCursorPosition(newWidth / 2 - 19, newHeight / 2 - 4 );
            Console.Write("Sorry! Try again!");
            Console.SetCursorPosition(newWidth / 2 - 19, newHeight / 2 -2);
            Console.Write("Your score is: {0}", score.ToString().PadRight(10, ' '));
            Console.SetCursorPosition(newWidth / 2 - 19, newHeight / 2);
            Console.Write("Enter:\t Play again");
            Console.SetCursorPosition(newWidth / 2 - 19, newHeight / 2 + 1 );
            Console.Write("Escape:\t Quit");

            while (key != ConsoleKey.Enter && key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Enter) { playGame = true; }
                if (key == ConsoleKey.Escape) { playGame = false; }
            }
        }
        else
        {
            playGame = false;
        }


    }

    public static void WelcomeScreen()
    {
        Console.CursorVisible = true;
        // Set Colors
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();

        // Get Original Window Size
        oldWindowSizeX = Console.WindowWidth;
        oldWindowSizeY = Console.WindowHeight;
        oldBufferSizeX = Console.BufferWidth;
        oldBufferSizeY = Console.BufferHeight;

        // Set Program New Window Size
        newWidth = Math.Min(Console.LargestWindowWidth, 80);
        newHeight = Math.Min(Console.LargestWindowHeight, 40);
        Console.SetWindowSize(newWidth, newHeight);
        Console.BufferWidth = newWidth;
        Console.BufferHeight = newHeight;

        // Set Difficulty
        difficulty = Math.Max(2, newWidth / 20);

        // Welcome Screen
        Console.SetCursorPosition(newWidth / 2 - 18, newHeight / 2 - 9);
        Console.Write("WELCOME TO THE FALLING ROCKS GAME!");
        Console.SetCursorPosition(newWidth / 2 - 18, newHeight / 2 - 7);
        Console.Write("Arrow keys:\t Move left and right");
        Console.SetCursorPosition(newWidth / 2 - 18, newHeight / 2 - 6);
        Console.Write("Shift:\t\t Move faster");
        Console.SetCursorPosition(newWidth / 2 - 18, newHeight / 2 - 4);
        Console.Write("Press Spacebar to Pause the game.");
        Console.SetCursorPosition(newWidth / 2 - 18, newHeight / 2 - 2);
        Console.Write("Press any key to continue.");
        Console.ReadKey(true);
    }

    public static void CheckCollision()
    {
        if (startCount < newHeight - 1)
        {
            startCount++;
        }
        else
        {
            for (int i = 0; i < rockDensity.Peek(); i++)
            {
                if (rockX.Peek() % newWidth >= (playerX - 1) && rockX.Peek() % newWidth <= (playerX + 1))
                {
                    playGame = false;
                }
                if (rockX.Peek() >= newWidth)
                {
                    goodX.RemoveAt(0);
                    goodY.RemoveAt(0);
                }
                rockX.Dequeue();
            }
            rockDensity.Dequeue();
        }
    }

    public static void GetNewData()
    {
        for (int i = 0; i < randString.Length; i++)
        {
            if (randString[i] != ' ')
            {
            rockX.Enqueue(i + newWidth);
            goodX.Add(i);
            goodY.Add(2);
            }
        }
    }

    public static void DrawNewRocks()
    {
        lastDensity = rand.Next(difficulty);
        rockDensity.Enqueue(lastDensity);
        randString = new StringBuilder(lastDensity);
        for (int i = 0; i < (newWidth - lastDensity - 1); i++)
        {
            randString.Append(' ');
        }
        for (int i = 0; i < lastDensity; i++)
        {
            randString.Insert(1 + rand.Next(randString.Length - 1), rockTypes[rand.Next(rockTypes.Length)] );
        }
        Console.SetCursorPosition(0, 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(randString.ToString());
    }

    public static void MovePlayer()
    {
        if (movePlayer)
        {
            movePlayer = false;
            if (key == ConsoleKey.LeftArrow && playerX > 2)
            {
                //ErasePlayer();
                if (keyInfo.Modifiers != ConsoleModifiers.Shift)
                {
                    playerX--;
                }
                else
                {
                    playerX = playerX - 2;
                }
            }
            else if (key == ConsoleKey.RightArrow && playerX < (newWidth - 3))
            {
                //ErasePlayer();
                if (keyInfo.Modifiers != ConsoleModifiers.Shift)
                {
                    playerX++;
                }
                else
                {
                    playerX = playerX + 2;
                }
            }
        }
        if (playGame) { DrawPlayer(); }
    }

    public static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX - 1, playerY);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("(0)");
    }

    public static void ErasePlayer()
    {
        Console.SetCursorPosition(playerX - 1, playerY);
        Console.Write("   ");
    }

    public static void DrawScore()
    {
        if (redrawScore)
        {
            redrawScore = false;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Score: {0} ", score);
        }
    }

    public static void SetBeginValues()
    {
        startCount = 2;
        score = 0;
        redrawScore = true;
        rockX.Clear();
        rockDensity.Clear();
        goodX.Clear();
        goodY.Clear();
        evenTurn = true;
    }

    public static void StartGame()
    {
        Console.CursorVisible = false;
        SetBeginValues();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;

        //------First Drawings
        for (int i = 0; i < newWidth; i++)
        {
            Console.SetCursorPosition(i, 1);
            Console.Write('.');
        }
        Console.SetCursorPosition(newWidth - 30, 0);
        Console.Write("Space = Pause  Escape = Quit");
        DrawScore();
        playerX = newWidth / 2;
        playerY = newHeight - 1;
        DrawPlayer();
    }

    public static void EndGame()
    {
        Console.CursorVisible = true;
        // Restore Original Window Size And Colors
        Console.ResetColor();
        Console.Clear();
        Console.SetWindowSize(oldWindowSizeX, oldWindowSizeY);
        Console.BufferWidth = oldBufferSizeX;
        Console.BufferHeight = oldBufferSizeY;
    }
 
}
