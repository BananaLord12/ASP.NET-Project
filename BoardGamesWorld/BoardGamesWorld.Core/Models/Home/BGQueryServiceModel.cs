using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Home
{
    public class BGQueryServiceModel
    {
        public int TotalBoardGamesCount { get; set; }

        public IEnumerable<BoardGameServiceModel> BoardGames { get; set; }
        = new List<BoardGameServiceModel>();
    }
}
