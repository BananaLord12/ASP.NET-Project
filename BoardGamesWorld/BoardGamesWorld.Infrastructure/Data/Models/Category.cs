using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Board Game Category ")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category Name")]
        public string Name { get; set; } = string.Empty;

        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
