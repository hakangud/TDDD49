using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AIPlayer : Player
    {
        public override void yourTurn(List<Enum> allowedActionsList)
        {
            Random r = new Random();
            PAction = allowedActionsList.ElementAt(r.Next(0, allowedActionsList.Count - 1));
           
            if (PAction.Equals(Enum.bet) {
                BetAmount = r.Next((int)MinBet, (int)Chips);
            }
        }
    }
}
