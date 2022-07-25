using Repository.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace Zadatak03
{
    /// <summary>
    /// Summary description for Soap
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Soap : System.Web.Services.WebService
    {
        List<Game> games = new List<Game>();

        [WebMethod]
        public XmlNode Search(string query)
        {
            fillList();
            XmlDocument doc = createXml();
            CrateXmlDocument(doc);
            XmlNode node = doc.SelectSingleNode("/games/game/title[text() = '" + query + "']/parent::game");
            return node;
        }

        private static void CrateXmlDocument(XmlDocument doc)
        {
            string path = HttpContext.Current.Server.MapPath(@"~/Schemas");
            doc.Save(path + "\\game.xml");
        }

        private XmlDocument createXml()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode gamesNode = doc.CreateElement("games");
            doc.AppendChild(gamesNode);
            foreach (Game game in games)
            {
                XmlNode gameNode = doc.CreateElement("game");
                gamesNode.AppendChild(gameNode);

                XmlNode idGameNode = doc.CreateElement("idGame");
                idGameNode.AppendChild(doc.CreateTextNode(game.IDGame.ToString()));
                gameNode.AppendChild(idGameNode);

                XmlNode titleNode = doc.CreateElement("title");
                titleNode.AppendChild(doc.CreateTextNode(game.Title));
                gameNode.AppendChild(titleNode);

                XmlNode descriptionNode = doc.CreateElement("description");
                descriptionNode.AppendChild(doc.CreateTextNode(game.Description));
                gameNode.AppendChild(descriptionNode);

                XmlNode thumbnailNode = doc.CreateElement("thumbnail");
                thumbnailNode.AppendChild(doc.CreateTextNode(game.Thumbnail));
                gameNode.AppendChild(thumbnailNode);

                XmlNode gameUrlNode = doc.CreateElement("gameUrl");
                gameUrlNode.AppendChild(doc.CreateTextNode(game.GameUrl));
                gameNode.AppendChild(gameUrlNode);

                XmlNode genreNode = doc.CreateElement("genre");
                genreNode.AppendChild(doc.CreateTextNode(game.Genre));
                gameNode.AppendChild(genreNode);

                XmlNode platformNode = doc.CreateElement("platform");
                platformNode.AppendChild(doc.CreateTextNode(game.Platform));
                gameNode.AppendChild(platformNode);

                XmlNode publisherNode = doc.CreateElement("publisher");
                publisherNode.AppendChild(doc.CreateTextNode(game.Publisher));
                gameNode.AppendChild(publisherNode);

                XmlNode developerNode = doc.CreateElement("developer");
                developerNode.AppendChild(doc.CreateTextNode(game.Developer));
                gameNode.AppendChild(developerNode);

                XmlNode releaseDateNode = doc.CreateElement("releaseDate");
                releaseDateNode.AppendChild(doc.CreateTextNode(game.ReleaseDate));
                gameNode.AppendChild(releaseDateNode);

                XmlNode freeToGameProfileUrlNode = doc.CreateElement("freeToGameProfileUrl");
                freeToGameProfileUrlNode.AppendChild(doc.CreateTextNode(game.FreeToGameProfileUrl));
                gameNode.AppendChild(freeToGameProfileUrlNode);
            }

            return doc;
        }

        private void fillList()
        {
            games.Add(new Game(1, "Prototype", "Thumbnail image", "Description", "GameUrl", "Genre", "Platform", "Publisher", "Developer", "ReleaseDate", "freeToGameProfileUrl"));
            games.Add(new Game(2, "Assassins creed", "Thumbnail image", "Description", "GameUrl", "Genre", "Platform", "Publisher", "Developer", "ReleaseDate", "freeToGameProfileUrl"));
            games.Add(new Game(3, "Darksiders", "Thumbnail image", "Description", "GameUrl", "Genre", "Platform", "Publisher", "Developer", "ReleaseDate", "freeToGameProfileUrl"));
        }
    }
}
