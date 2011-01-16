using System;
using System.Collections.Generic;
using Compete.Bot;
using System.Net;
using System.IO;

namespace RockPaperScissorsPro.Network
{
    public class NetworkPlayerFactory : INetworkBotFactory
    {
        public IBot CreateBot(string url)
        {
            return new NetworkBot(url);
        }
    }

    public class NetworkBot : IRockPaperScissorsBot
    {
        const string template = "{0}?round={1}" +
            "&you_last_move={2}&you_points={3}&you_team_name={4}" +
            "&opp_last_move={5}&opp_points={6}&opp_team_name={7}" +
            "&max_games={8}&points_to_win={9}";

        string teamUrl;
        string roundGuid;

        public NetworkBot(string teamUrl)
        {
            this.teamUrl = teamUrl;
            this.roundGuid = Guid.NewGuid().ToString("N");
        }

        public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules, IGameLog log)
        {
            string youLastMove = you.LastMove == null ? String.Empty : you.LastMove.ToString().Trim();
            string opponentLastMove = opponent.LastMove == null ? String.Empty : opponent.LastMove.ToString().Trim();

            string url = String.Format(template, this.teamUrl, this.roundGuid,
                youLastMove, you.Points, you.TeamName,
                opponentLastMove, opponent.Points, opponent.TeamName,
                rules.MaximumGames, rules.PointsToWin);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    string move = new StreamReader(stream).ReadToEnd();
                    return Round1Move.Moves[move];
                }
            }
        }
    }
}
