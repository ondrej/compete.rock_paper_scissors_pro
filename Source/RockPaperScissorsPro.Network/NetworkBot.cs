using System;
using System.Collections.Generic;
using Compete.Bot;
using System.Net;

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
        Uri url;

        public NetworkBot(string url)
        {
            this.url = new Uri(url);
        }

        public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules, IGameLog log)
        {
            /*using (HttpWebRequest request = WebRequest.Create(uri))
            {
            }*/

            return Round1Move.Rock;
        }
    }
}