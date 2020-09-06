﻿using IshitoriLibrary.Logic;
using System;
using System.Collections.Generic;
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
            
            RecalculatePiecesLeft(piecesTaken);
            _actualStatus.IsCpTurn = false;
            CpRetrievedPieces = piecesTaken;
        }
        public void RecalculatePiecesLeft(int grabbedPieces)
        {

           _actualStatus.PiecesLeft-= grabbedPieces;
        }

        public bool IsGameFinished()
        {
            return _actualStatus.PiecesLeft <1;
        }

        public Game(GameStatus status,int[] intervalToPlay)
        {
            
            _actualStatus = status;
            _actualStatus.PiecesLeft = new Random().Next(intervalToPlay[0], intervalToPlay[1]);
            _actualStatus.InitialPieces = ActualStatus.PiecesLeft;

        }

        public int CpRetrievedPieces { get; set; }

    }
}
