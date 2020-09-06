using System;
using System.Collections.Generic;
using System.Text;

namespace IshitoriLibrary.Logic
{
    public class GameStatus
    {
        public bool IsCpTurn { get; set; }
        public int PiecesLeft { get; set; }
        public int LastPlayerRetrieval { get; set; } = 0;
        public int LastCpRetrieval { get; set; } = 0;
        public int InitialPieces { get; set; }
        public int CpRetrievedPieces { get; set; }
    }
}
