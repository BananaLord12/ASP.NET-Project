using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BoardGamesWorld.Infrastructure.Constants.DataConstants;

namespace BoardGamesWorld.Infrastructure.Data.Models
{
    [Comment("Website Contributor")]
    public class Contributor
    {
        [Key]
        [Comment("Contributor Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ContributorNameMaxLength)]
        [Comment("Contributor Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ContributorPhoneNumberMaxLength)]
        [Comment("Contributor's Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
