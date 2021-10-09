using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models.PlayerCard
{
    class PlayerCardModel
    {
        private readonly string savepath = @"C:\Users\" + Environment.UserName + @"\Documents\TrackerApp\Public\PlayerCard\PlayerCard.json";

        public string defaultSavePath { get { return savepath; } }
        public string SavePath { get; set; }
        public string NickName { get; set; }
        public string GamesPlayed { get; set; }
        public string GamesWon { get; set; }
        public string GamesLost { get; set; }
        public string MostGamesPlayerWith { get; set; }//Has to be a playername
        public int MostGamesPlayedWithNum { get; set; }
        public string MostGamesWonWith { get; set; }//playerName
        public int MostGamesWonWithNum { get; set; }
        public string MostGamesLostWith { get; set; }//playername
        public int MostGamesLostWithNum { get; set; }

        public string AccountName { get; set; }
    }
}
