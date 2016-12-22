using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Game
{

	private Card card
    class PokerGame
    {
        protected int bigBlind = 20;
        protected int smallBlind = 10;
        protected float pot;
        protected float currentBet;

        List<PlayerEntity> players;
        List<Enum> allowedActionsList;

        public PokerGame(List<PlayerEntity> pl)
        {
            players = pl;
        }

        public void playRound()
        {
            List<PlayerEntity> playersInRound = players;
            postBlinds();
			dealCards();
			while (playersInRound.Count > 1) {

				//change this :D
				foreach (Player p in players)
            	{
                	p.yourTurn(allowedActionsList);
                	p.MinBet = currentBet;
            	}


				if (gameState.Equals(river)) {
					break;
				}

				addNewCard(gameState);

			}
			checkWinner(playersInRound);
		}

        private void makeBet(Player p, float betAmount)
        {
            p.Bet(betAmount);
        }

        private void postBlinds()
        {

        }
    }
}