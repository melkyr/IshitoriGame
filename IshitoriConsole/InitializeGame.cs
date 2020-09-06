

using IshitoriLibrary;
using IshitoriLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace IshitoriConsole
{
    public static class InitializeGame
    {

        public static int[] AskDificultToUser()
        {
            bool canSelect = true;            
            int difficulty = 0;
            int[] selectedDificulty;

            Console.WriteLine("Please write the dificult to choose and press ENTER");
            Console.WriteLine("0-Easy, 1-Medium,3-Hard, default->easy");
            string selectedOption = Console.ReadLine();
            canSelect = int.TryParse(selectedOption, out difficulty);
            if (!canSelect)
            {
                Console.WriteLine("Invalid Number, selected easy");
            
            }
            return selectedDificulty = CalculateDificulty(difficulty);
        }
        public static Game CreateNewGame()
        {

            
            GameStatus currentStatus = new GameStatus();
            Game newGame = new Game(currentStatus, AskDificultToUser());
            return newGame;

        }
        private static int[] CalculateDificulty(int difficulty)
        {
            int[] selected= new int[] {0,0};
            switch (difficulty)
            {
                case 1:
                    selected = new int[] { 5, 21 };
                    break;
                case 2:
                    selected = new int[] { 22, 46 };
                    break;
                case 3:
                    selected = new int[] { 47, 95 };
                    break;
                default:
                    selected = new int[] { 5, 21 };
                    break;
            }
            return selected;

        }
    }
}
