using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Data;
using Poker.Game;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Poker.Players
{
    class PlayerEntity : Changeable
    {
    
    
        //public string playerName { get; set; }
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
        private float betAmount;
        public float BetAmount
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
        public Card[] hand { get; set; }
        public float chips { get; set; }
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
