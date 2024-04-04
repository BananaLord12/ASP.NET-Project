using BoardGamesWorld.Core.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Services.BoardGames
{
    public class BoardGamesDetailsServiceModel : BoardGameServiceModel
    {

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
