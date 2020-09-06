using IshitoriLibrary.Logic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace IshitoriLibrary
{
    public class Game
    {
        GameStatus _actualStatus = new GameStatus();

        public GameStatus ActualStatus
        {
            get { return _actualStatus; }
            set { _actualStatus = value; }
        }


        public void MakeCpMove()
        {
            int piecesTaken = 0;
            if (_actualStatus.InitialPieces<30)
            {
                piecesTaken = _actualStatus.DummyComputerRetrieves();
            }
            else
            {
                piecesTaken = _actualStatus.SmartComputerRetrieves();
            }
            
            GameLogic.RecalculatePiecesLeft(piecesTaken, _actualStatus);
            _actualStatus.IsCpTurn = false;
            _actualStatus.CpRetrievedPieces = piecesTaken;
            IsGameFinished();
        }


        public bool IsGameFinished()
        {
            bool isFinished = false;
            isFinished=_actualStatus.PiecesLeft < 1;
            _actualStatus.IsGameOver = isFinished;
            return isFinished;
        }

        public Game(int[] intervalToPlay)
        {

            if (_actualStatus == null)
            {
                GameStatus newStatus = new GameStatus();
                _actualStatus = newStatus;
            }
            //Sort the actual values before trying to avoid errors
            Array.Sort(intervalToPlay);
            _actualStatus.PiecesLeft = new Random().Next(intervalToPlay[0], intervalToPlay[1]);
            _actualStatus.InitialPieces = ActualStatus.PiecesLeft;

        }

        

    }
}
