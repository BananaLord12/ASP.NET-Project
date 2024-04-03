using BoardGamesWorld.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Costants
{
    public interface IBoardGameService
    {
        Task<IEnumerable<BoardGamesIndexServiceModel>> LastThreeBoardGamesAsync();

        Task<IEnumerable<BoardGamesAllServiceModel>> AllBoardGamesAsync();


    }
}
