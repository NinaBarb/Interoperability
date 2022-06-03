using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Zadatak01.Models
{

    [DataContract(Namespace = "FreeGamesDatabase")]
    public class Game
    {
        public Game() { }
        public Game(int iDGame, string title, string thumbnail, string description, string gameUrl, string genre, string platform, string publisher, string developer, string releaseDate, string freeToGameProfileUrl)
        {
            IDGame = iDGame;
            Title = title;
            Thumbnail = thumbnail;
            Description = description;
            GameUrl = gameUrl;
            Genre = genre;
            Platform = platform;
            Publisher = publisher;
            Developer = developer;
            ReleaseDate = releaseDate;
            FreeToGameProfileUrl = freeToGameProfileUrl;
        }

        [DataMember(Order = 0)]
        public int IDGame { get; set; }

        [DataMember(Order = 1)]
        [Required(ErrorMessage = "* Title is required")]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        [Required(ErrorMessage = "* Thumbnail is required")]
        public string Thumbnail { get; set; }

        [DataMember(Order = 3)]
        [Required(ErrorMessage = "* Description is required")]
        public string Description { get; set; }

        [DataMember(Order = 4)]
        [Required(ErrorMessage = "* Game url is required")]
        public string GameUrl { get; set; }

        [DataMember(Order = 5)]
        [Required(ErrorMessage = "* Genre is required")]
        public string Genre { get; set; }

        [DataMember(Order = 6)]
        [Required(ErrorMessage = "* Platform is required")]
        public string Platform { get; set; }

        [DataMember(Order = 7)]
        [Required(ErrorMessage = "* Publisher is required")]
        public string Publisher { get; set; }

        [DataMember(Order = 8)]
        [Required(ErrorMessage = "* Developer is required")]
        public string Developer { get; set; }

        [DataMember(Order = 9)]
        [Required(ErrorMessage = "* Release date is required")]
        public string ReleaseDate { get; set; }

        [DataMember(Order = 10)]
        [Required(ErrorMessage = "* Free to game profile url is required")]
        public string FreeToGameProfileUrl { get; set; }
    }
}
