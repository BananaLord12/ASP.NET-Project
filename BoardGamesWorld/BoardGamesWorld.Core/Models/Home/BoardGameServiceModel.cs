using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesWorld.Core.Models.Home
{
    public class BoardGameServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [DisplayName("Price")]
        public decimal Price { get; set; }
    }
}
