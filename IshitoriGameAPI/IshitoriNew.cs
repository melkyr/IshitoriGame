using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IshitoriLibrary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IshitoriGameAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class IshitoriNew : ControllerBase
    {
        // GET api/<IshitoriMoveController>/5
        [HttpGet("{lowValue}/{maxValue}")]
        public Game Get(int lowValue, int maxValue)
        {
            Game newGame = new Game(new int[] { lowValue, maxValue });
            return newGame;
        }
    }
}
