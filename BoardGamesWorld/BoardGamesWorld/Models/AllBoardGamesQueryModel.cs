using BoardGamesWorld.Core.Models.Home;

namespace BoardGamesWorld.Models
{
    public class AllBoardGamesQueryModel
    {
        public const int BoardGamesPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public BoardGameSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalBoardGamesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<BoardGameServiceModel> BoardGames { get; set; } = Enumerable.Empty<BoardGameServiceModel>();
    }
}
