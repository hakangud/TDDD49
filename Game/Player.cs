using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Game
{
    abstract class Player : PlayerEntity
    {
        private float minBet;

        public abstract void yourTurn(List<Enum> allowedActionsList);

        public float MinBet {
            get
            {
                return minBet;
            }
            set
            {
                minBet = value;
            }
            }
    }
}