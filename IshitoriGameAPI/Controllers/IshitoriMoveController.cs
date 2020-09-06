using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using IshitoriLibrary;
using IshitoriLibrary.Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IshitoriGameAPI.Con
{
    [Route("api/[controller]")]
    [ApiController]
    public class IshitoriMoveController : ControllerBase
    {
        /// <summary>
        /// The player Api for the game
        /// </summary>
        /// <param name="piecesLeft">How much pieces left there are befor the move</param>
        /// <param name="initialPieces">The game Initial Pieces(to use Smart or Normal Engine)</param>
        /// <param name="lastCpMove">The last cp retrieval</param>
        /// <param name="lastPlayerMove">The last player retrieval</param>
        /// <returns></returns>
        [HttpGet]
        [HttpGet("{piecesLeft}/{initialPieces}/{lastCpMove}/{lastPlayerMove}")]
        public Game Get(int piecesLeft, int initialPieces, int lastCpMove,int lastPlayerMove)
        {
            Game currentGame = new Game(new int[] { 1, initialPieces });
            currentGame.ActualStatus.IsCpTurn = true;
            currentGame.ActualStatus.LastPlayerRetrieval = lastPlayerMove;
            currentGame.ActualStatus.LastCpRetrieval = lastCpMove;
            currentGame.ActualStatus.PiecesLeft = piecesLeft;
            currentGame.ActualStatus.InitialPieces = initialPieces;
            currentGame.MakeCpMove();
            return currentGame;
        }
    }
}
