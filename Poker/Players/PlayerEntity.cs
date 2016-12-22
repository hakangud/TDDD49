using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class PlayerEntity
    {

        private string playerName;
        private float betAmount;
        private bool folded;
        private Enum pAction;
        private Card[] hand;
        private float chips;

        protected string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
            }
        }

        protected float Chips
        {
            get
            {
                return Chips1;
            }

            set
            {
                Chips1 = value;
            }
        }

        public float Chips1
        {
            get
            {
                return chips;
            }

            set
            {
                chips = value;
            }
        }

        protected bool Folded
        {
            get
            {
                return folded;
            }

            set
            {
                folded = value;
            }
        }

        protected Enum PAction
        {
            get
            {
                return pAction;
            }

            set
            {
                pAction = value;
            }
        }

        protected float BetAmount
        {
            get
            {
                return betAmount;
            }

            set
            {
                betAmount = value;
            }
        }
    }

}
