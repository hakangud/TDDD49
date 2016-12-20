using Poker.Data;
using Poker.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Players
{
    abstract class Player : Changeable
    {
        private float minBet;
        public abstract void yourTurn(List<Enum> allowedActionsList);

        public bool controlledByUser { get; set; }

        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set
            {
                if (playerName != value)
                {
                    playerName = value;
                    OnpropertyChanged("PlayerName");
                }
            }
        }
        private int betAmount;
        public int BetAmount
        {
            get { return betAmount; }
            set
            {
                if (betAmount != value)
                {
                    betAmount = value;
                    OnpropertyChanged("BetAmount");
                }
            }
        }

        public bool folded;
        public bool Folded
        {
            get { return folded; }
            set
            {
                if (folded != value)
                {
                    folded = value;
                    OnpropertyChanged("Folded");
                }
            }
        }
        //public Enum pAction { get; set; }
        private bool active;
        public bool Active
        {
            get { return active; }
            set
            {
                if (active != value)
                {
                    active = value;
                    OnpropertyChanged("Active");
                }
            }
        }

        public List<Card> cards { get; set; }
        private int chips;
        public int Chips
        {
            get { return chips; }
            set
            {
                if (chips != value)
                {
                    chips = value;
                    OnpropertyChanged("Chips");
                }
            }
        }
        public PokerTable table { get; set; }
        private int seat;
        public int Seat
        {
            get { return seat; }
            set
            {
                if (seat != value)
                {
                    seat = value;
                    OnpropertyChanged("Seat");
                }
            }
        }
    }
}
