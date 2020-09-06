using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IshitoriLibrary.Logic
{
    public static class GameLogic
    {
        public static int DummyComputerRetrieves(this GameStatus currentGame)
        {
            int piecesToGrab = 1;
            if (currentGame.PiecesLeft == 1)
            {
                piecesToGrab = 1;
            }
            else if (currentGame.PiecesLeft > 8)
            {
                piecesToGrab = new Random().Next(1, 4);
            }
            else if (currentGame.PiecesLeft>4)
            {
                piecesToGrab = currentGame.PiecesLeft - 5;
            }
            else if (currentGame.PiecesLeft<=4)
            {
                piecesToGrab = currentGame.PiecesLeft - 1;
            }
            return piecesToGrab;
        }

        public static int SmartComputerRetrieves(this GameStatus currentGame)
        {
            int piecesToGrab=0;
            if (currentGame.PiecesLeft==1)
            {
                piecesToGrab = 1;
            }
            //Lets try our best to get into the closer mult*4 integer
            if ((currentGame.PiecesLeft-1)%4==0 && currentGame.LastPlayerRetrieval==0)
            {
                piecesToGrab = new Random().Next(1, 4);

            }
            //If last turn we were on a special number
            else if((currentGame.PiecesLeft+currentGame.LastPlayerRetrieval+currentGame.LastCpRetrieval)%4 == 0 && currentGame.PiecesLeft>8)
            {
                piecesToGrab=4-currentGame.LastPlayerRetrieval;
            }
            else if ((currentGame.PiecesLeft + currentGame.LastPlayerRetrieval) % 4 != 0 && currentGame.PiecesLeft > 8)
            {
                piecesToGrab = currentGame.PiecesLeft % 4;
            }
            else if (currentGame.PiecesLeft > 4)
            {
                piecesToGrab = currentGame.PiecesLeft - 4;
            }
            else if (currentGame.PiecesLeft == 4)
            {
                piecesToGrab = 3;
            }
            else if (currentGame.PiecesLeft < 4 && currentGame.PiecesLeft>1)
            {
                piecesToGrab = currentGame.PiecesLeft - 1;
            }

            if (piecesToGrab==0||piecesToGrab==4)
            {
                piecesToGrab = new Random().Next(1, 4);
            }
            return piecesToGrab;
        }

        public static void RecalculatePiecesLeft(int grabbedPieces, GameStatus status)
        {

            status.PiecesLeft -= grabbedPieces;
        }
    }
}
