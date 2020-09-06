using IshitoriLibrary;
using System;
using System.Collections.Generic;

namespace IshitoriConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlay();
            
        }
        public static void GamePlay()
        {
            
            _currentGame = InitializeGame.CreateNewGame();
            Console.WriteLine($"Pieces Left:{_currentGame.ActualStatus.PiecesLeft}");
            SetFirstTurn();
            StartGame();
        }
        public static Game _currentGame;
        private static void SetFirstTurn()
        {
            string option = "";
            Console.WriteLine("Do you want to be the first to start? [y]/[n] - default [y]");
            option = Console.ReadLine();
            _currentGame.ActualStatus.IsCpTurn = (option == "n");

        }
        private static void StartGame()
        {
            while (!_currentGame.IsGameFinished())
            {
                Console.WriteLine($"Now there are {_currentGame.ActualStatus.PiecesLeft} Pieces Left");
                if (_currentGame.ActualStatus.IsCpTurn)
                {
                    _currentGame.MakeCpMove();
                    Console.WriteLine($"Master Ishitori retrieves {_currentGame.CpRetrievedPieces}");
                }
                else
                {
                    int retrieval = ParsePlayerRetrievedPieces();
                    _currentGame.RecalculatePiecesLeft(retrieval);
                    _currentGame.ActualStatus.LastPlayerRetrieval = retrieval;
                    _currentGame.ActualStatus.IsCpTurn = true;
                }

            }

            if (_currentGame.ActualStatus.IsCpTurn == true)
            {
                Console.WriteLine("YOU LOSE!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("YOU WIN!");
                Console.WriteLine();

            }
        }
        private static int ParsePlayerRetrievedPieces()
        {
            bool success = false;
            int grabbedPieces = 0;
            while (!success)
            {
                
                Console.WriteLine("Write the pieces to retrieve(1-3) and Press ENTER");
                string pieces = Console.ReadLine();
                grabbedPieces= ValidateNumber(pieces);
                if(grabbedPieces >0 && grabbedPieces < 4)
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine("You typed more than 3 pieces or less than 1!");
                }
            }
            return grabbedPieces;
        }
        private static int ValidateNumber(string retrieval)
        {
            bool canRetrieve = true;
            int piecesToRetrieve = 0;
            canRetrieve = int.TryParse(retrieval, out piecesToRetrieve);
            if (!canRetrieve)
            {
                Console.WriteLine("Invalid Number, try again");
            }
            return piecesToRetrieve;
        }
        
    }
}
