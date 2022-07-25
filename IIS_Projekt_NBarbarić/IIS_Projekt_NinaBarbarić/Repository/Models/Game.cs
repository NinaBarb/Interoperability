using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository.Models
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
        [JsonProperty("id")]
        public int IDGame { get; set; }

        [DataMember(Order = 1)]
        [Required(ErrorMessage = "* Title is required")]
        [JsonProperty("title")]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        [Required(ErrorMessage = "* Thumbnail is required")]
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [DataMember(Order = 3)]
        [Required(ErrorMessage = "* Description is required")]
        [JsonProperty("short_description")]
        public string Description { get; set; }

        [DataMember(Order = 4)]
        [Required(ErrorMessage = "* Game url is required")]
        [JsonProperty("game_url")]
        public string GameUrl { get; set; }

        [DataMember(Order = 5)]
        [Required(ErrorMessage = "* Genre is required")]
        [JsonProperty("genre")]
        public string Genre { get; set; }

        [DataMember(Order = 6)]
        [Required(ErrorMessage = "* Platform is required")]
        [JsonProperty("platform")]
        public string Platform { get; set; }

        [DataMember(Order = 7)]
        [Required(ErrorMessage = "* Publisher is required")]
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [DataMember(Order = 8)]
        [Required(ErrorMessage = "* Developer is required")]
        [JsonProperty("developer")]
        public string Developer { get; set; }

        [DataMember(Order = 9)]
        [Required(ErrorMessage = "* Release date is required")]
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [DataMember(Order = 10)]
        [Required(ErrorMessage = "* Free to game profile url is required")]
        [JsonProperty("freetogame_profile_url")]
        public string FreeToGameProfileUrl { get; set; }

        public override string ToString() => $"{Title}, {Developer}";
    }
}
