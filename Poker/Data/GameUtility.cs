using Poker.Game;
using Poker.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Poker.Data
{
    /// <summary>
    /// Static class that handles reads and writes to xml files.
    /// </summary>
    static class GameUtility
    {
        private static string filename = "table.xml";

        public static void SeedXML()
        {
            XElement table = new XElement("Table",
                new XElement("Pot", 0));
            XElement players = new XElement("Players");
            XElement cardsOnTable = new XElement("CardsOnTable");

            players.Add(new XElement("Player",
                new XElement("Name", "Fia"),
                new XElement("Chips", 2000),
                new XElement("BetAmount", 20),
                new XElement("Folded", false),
                new XElement("IsActive", true),
                new XElement("ControlledByUser", true),
                new XElement("Seat", 1),
                new XElement("Card1Suit", 1),
                new XElement("Card1Value", 2),
                new XElement("Card2Suit", 2),
                new XElement("Card2Value", 2)));

            players.Add(new XElement("Player",
                new XElement("Name", "Frans"),
                new XElement("Chips", 2000),
                new XElement("BetAmount", 20),
                new XElement("Folded", false),
                new XElement("IsActive", false),
                new XElement("ControlledByUser", false),
                new XElement("Seat", 2),
                new XElement("Card1Suit", 1),
                new XElement("Card1Value", 1),
                new XElement("Card2Suit", 2),
                new XElement("Card2Value", 1)));

            cardsOnTable.Add(new XElement("Card",
                new XElement("CardSuit", 4),
                new XElement("CardValue", 4)),
                new XElement("Card",
                new XElement("CardSuit", 5),
                new XElement("CardValue", 5)));

            table.Add(players);
            table.Add(cardsOnTable);
            table.Save(filename);
        }

        public static void SaveTableState(PokerTable table)
        {
            XDocument xd = XDocument.Load(filename);

            if (table.CardsOnTable == null || table.CardsOnTable.Count == 0)
            {
                xd.Descendants("CardsOnTable")
                    .Elements("Card")
                    .Remove();
            }
            else
            {
                var cards = from card in table.CardsOnTable
                            select new
                            {
                                CardSuit = card.MySuit,
                                CardValue = card.MyValue
                            };

                foreach (var card in table.CardsOnTable)
                {
                    xd.Root.Element("CardsOnTable").Add(new XElement("Card",
                        new XElement("CardSuit", (int)card.MySuit),
                        new XElement("CardValue", (int)card.MyValue)));
                }
            }

            xd.Root.SetElementValue("Pot", table.Pot);

            //xd.Element("Pot").SetElementValue("Pot", table.Pot);

            xd.Save(filename);
        }

        public static void SavePlayerState(Player player)
        {
            XDocument xd = XDocument.Load(filename);
            var items = from item in xd.Descendants("Player")
                        where item.Element("Name").Value == player.PlayerName
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("Active", player.Active);
                itemElement.SetElementValue("Folded", player.Folded);
                itemElement.SetElementValue("BetAmount", player.BetAmount);
                itemElement.SetElementValue("Chips", player.Chips);
            }

            xd.Save(filename);
        }

        public static void SavePlayerHands(List<Player> pl)
        {
            XDocument xd = XDocument.Load(filename);
            foreach (var player in pl)
            {
                var items = from item in xd.Descendants("Player")
                            where item.Element("Name").Value == player.PlayerName
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetElementValue("Card1Suit", (int)player.cards[0].MySuit);
                    itemElement.SetElementValue("Card1Value", (int)player.cards[0].MyValue);
                    itemElement.SetElementValue("Card2Suit", (int)player.cards[1].MySuit);
                    itemElement.SetElementValue("Card2Value", (int)player.cards[1].MyValue);
                }
            }

            xd.Save(filename);
        }

        public static PokerTable LoadTable()
        {
            XDocument xd = XDocument.Load(filename);
            PokerTable pt = new PokerTable();
            List<Player> pl = LoadPlayers();
            List<Card> cl = LoadCardsOnTable();

            pt.Pot = (int)xd.Root.Element("Pot");
            pt.players = pl;
            pt.CardsOnTable = cl;

            return pt;
        }

        public static List<Card> LoadCardsOnTable()
        {
            XDocument xd = XDocument.Load(filename);
            List<Card> cl = new List<Card>();
            try
            {
                var elements = from e in xd.Descendants("CardsOnTable")
                               select new
                               {
                                   CardSuit = (int)e.Element("CardSuit"),
                                   CardValue = (int)e.Element("CardValue")
                               };

                foreach (var e in elements)
                {
                    cl.Add(new Card { MySuit = (Card.SUIT)e.CardSuit, MyValue = (Card.VALUE)e.CardValue });
                }
            }
            catch (ArgumentNullException e)
            {

            }
            return cl;
        }

        public static List<Player> LoadPlayers()
        {
            XDocument xd = XDocument.Load(filename);
            List<Player> pl = new List<Player>();

            var elements = from e in xd.Descendants("Player")
                        select new
                        {
                            Name = (string)e.Element("Name"),
                            Chips = (int)e.Element("Chips"),
                            BetAmount = (int)e.Element("BetAmount"),
                            Folded = (bool)e.Element("Folded"),
                            Active = (bool)e.Element("IsActive"),
                            ControlledByUser = (bool)e.Element("ControlledByUser"),
                            Seat = (int)e.Element("Seat"),
                            Card1Suit = (int)e.Element("Card1Suit"),
                            Card1Value = (int)e.Element("Card1Value"),
                            Card2Suit = (int)e.Element("Card2Suit"),
                            Card2Value = (int)e.Element("Card2Value"),
                        };

            foreach (var e in elements)
            {
                Player p;
                List<Card> cards = new List<Card>();
                if (e.ControlledByUser) { p = new HumanPlayer(); }
                else { p = new AIPlayer(); }

                p.PlayerName = e.Name;
                p.Chips = e.Chips;
                p.BetAmount = e.BetAmount;
                p.Folded = e.Folded;
                p.Active = e.Active;
                p.controlledByUser = e.ControlledByUser;
                p.Seat = e.Seat;

                Card c1 = new Card { MySuit = (Card.SUIT)e.Card1Suit, MyValue = (Card.VALUE)e.Card1Value };
                Card c2 = new Card { MySuit = (Card.SUIT)e.Card2Suit, MyValue = (Card.VALUE)e.Card2Value };
                cards.Add(c1);
                cards.Add(c2);
                p.cards = cards;

                pl.Add(p);
            }

            return pl;
        }
    }
}
