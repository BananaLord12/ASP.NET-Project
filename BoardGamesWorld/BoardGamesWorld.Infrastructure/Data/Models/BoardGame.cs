using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Information For Board Game")]
    public class BoardGame
    {
        [Key]
        [Comment("Board Game Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardGameNameMaxLength)]
        [Comment("Board Game Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(BoardGamesDescMaxLength)]
        [Comment("Board Game Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Board Game Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Board Game Price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Board Game Amount")]
        public int Quantity { get; set; }

        [Required]
        [Comment("Board Game Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
