using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Players;
using Poker.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Poker.Game
{
    public class PokerTableEntity : Changeable
    {
        public PokerTableEntity()
        {

        }

        List<PlayerEntity> players;
        int tableID;
        Deck deck;
        private int pot;
        public int Pot
        {
            get { return Pot; }
            set
            {
                if (Pot != value)
                {
                    Pot = value;
                    OnpropertyChanged("Pot");
                }
            }
        }

    }
}
