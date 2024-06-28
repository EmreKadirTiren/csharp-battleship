using System;

class MainClass {
  static void Main(string[] args)
  {
      //1 person battleship game
      Console.WriteLine("Welcome to Battleship!");
      Console.WriteLine("How big of a board do you want?(5-10)");
    Console.WriteLine("The game will randomly place a ship of 3-5 pieces on the board.");
    Console.WriteLine("You will have to guess where the ship is.");
    Console.WriteLine("Enter a letter and a number to guess a spot on the board.");
    Console.WriteLine("Good luck!");
      int boardSize;  
      while (!int.TryParse(Console.ReadLine(), out boardSize) || boardSize < 5 || boardSize > 10)
      {
          Console.WriteLine("Invalid input. Please enter a number between 5 and 10.");
      }

      char[,] actualBoard = new char[boardSize, boardSize];
      char[,] board = new char[boardSize, boardSize];

      for (int i = 0; i < board.GetLength(0); i++)
      {
          for (int x = 0; x < board.GetLength(1); x++)
          {
              board[i, x] = '.';
              actualBoard[i, x] = '.';
          }
      }


      Random random = new Random();

      //horizontal vs vertical
      int dir = random.Next(0, 2);

      //vertical ship
      if (dir == 0)
      {
          int x = random.Next(0, 3);
          int y = random.Next(0, 6);
          

          actualBoard[x, y] = 'X';
          actualBoard[x + 1, y] = 'X';
          actualBoard[x + 2, y] = 'X';

      }
      //horizontal ship
      else if (dir == 1)
      {
          int x = random.Next(0, 6);
          int y = random.Next(0, 3);

          actualBoard[x, y] = 'X';
          actualBoard[x, y + 1] = 'X';
          actualBoard[x, y + 2] = 'X';
      }

      int shipPieces = random.Next(3, 5);
      int shipHits = 0;
      int guesses = 0;

      while (true)
      {
        try
        {
          drawBoard(board);
          Console.Write("Enter a letter: ");
          string colLetter = Console.ReadLine();
          colLetter = colLetter.ToUpper();
          int row = 0;

          Console.Write("Enter a number: ");
          string rowInput = Console.ReadLine();
          int col = Int32.Parse(rowInput)-1;

          if (colLetter == "A")
          {
              row = 0;
          }
          else if (colLetter == "B")
          {
              row = 1;
          }
          else if (colLetter == "C")
          {
              row = 2;
          }
          else if (colLetter == "D")
          {
              row = 3;
          }
          else if (colLetter == "E")
          {
              row = 4;
          }
          else if (colLetter == "F")
          {
              row = 5;
          }


          
              if (board[row, col] == '.')
              {
                  guesses++;
                  if (actualBoard[row, col] == 'X')
                  {
                      board[row, col] = 'X';
                      //Console.WriteLine("Hit!");
                      shipHits++;
                      if (shipHits == shipPieces)
                      {
                          break;
                      }
                  }
                  else
                  {
                      board[row, col] = 'O';
                      //Console.WriteLine("Miss!");
                  }
              }
          }
          catch
          {
              Console.WriteLine("Bad input.");
          }

      }

      drawBoard(board);
      Console.WriteLine($"You won with {guesses} guesses!");


  }

  public static void drawBoard(char[,] arr)
  {
      Console.Clear();
      int asciiVal = 65;

      Console.Write(" \t");
      for (int i = 1; i < arr.GetLength(1) + 1; i++)
      {
          Console.Write($"{i}\t");
      }
      Console.WriteLine("\n");

      for (int i = 0; i < arr.GetLength(0); i++)
      {
          Console.Write($"{(char)asciiVal}\t");
          for (int x = 0; x < arr.GetLength(1); x++)
          {
              Console.Write($"{arr[i, x]}\t");
          }
          Console.WriteLine();
          asciiVal++;
      }
  }
}