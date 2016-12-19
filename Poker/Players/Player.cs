using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Players
{
    abstract class Player : PlayerEntity
    {
        private float minBet;
        public abstract void yourTurn(List<Enum> allowedActionsList);
    }
}