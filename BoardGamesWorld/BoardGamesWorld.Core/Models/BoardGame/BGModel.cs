using BoardGamesWorld.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;
using BoardGamesWorld.Core.Models.Home;

namespace BoardGamesWorld.Core.Models.BoardGame
{
    public class BGModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BoardGameNameMaxLength,
            MinimumLength = BoardGameNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(BoardGamesDescMaxLength,
            MinimumLength = BoardGmaesDescMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Price")]
        [Range(0.00,300.00, ErrorMessage = "Price must be a positive number and less that {2} leva")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Board Game Amount")]
        public int Quantity { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<BoardGameCategoryModel> BoardGameCategories { get; set; } = new List<BoardGameCategoryModel>();
    }
}
