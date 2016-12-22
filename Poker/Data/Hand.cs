using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poker.Data
{
    class Hand : Card
    {
        private Card[] cards;
        private int rank;
        private int rankDifferator;
        private int highestCard;
        private int secondHighestCard;
        private int thirdHighestCard;
        private int fourthHighestCard;
        private int fifthHighestCard;


        private enum HANDTYPES
        {
            Nothing,
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush
        }


        public Hand(Card[] l)
        {
            cards = l;

            calculateHandRank();
        }


        public void calculateHandRank()
        {

            //sortCards(cards);

            //if (straightFlush())
            //{
            //    rank = (int)(HANDTYPES.StraightFlush);
            //}
            if (FourOfAKind())
            {
                rank = (int)(HANDTYPES.FourOfAKind);
            }
            else if (FullHouse())
            {
                rank = (int)(HANDTYPES.FullHouse);
            }
            else if (Flush())
            {
                rank = (int)(HANDTYPES.Flush);
            }
            //else if (Straight())
            //{
            //    rank = (int)(HANDTYPES.Straight);
            //}
            else if (ThreeOfAKind())
            {
                rank = (int)(HANDTYPES.ThreeOfAKind);
            }
            else if (TwoPairs())
            {
                rank = (int)(HANDTYPES.TwoPairs);
            }
            else if (OnePair())
            {
                rank = (int)(HANDTYPES.OnePair);
            }
            else
            {
                rank = (int)(HANDTYPES.Nothing);
            }
        }



        public bool OnePair()
        {
            return Enumerable.Any(
            from x in cards
            group x by x.MyValue into g
            where g.Count() == 2
            select g
            );
        }

        public bool TwoPairs()
        {
            var v = from x in cards
                    group x by x.MyValue into g
                    where g.Count() == 2
                    select g;

            return (v.Count() >= 2);
        }


        public bool ThreeOfAKind()
        {
            return Enumerable.Any(
            from x in cards
            group x by x.MyValue into g
            where g.Count() == 3
            select g
            );
        }

        public bool DoubleThreeOfAKind()
        {
            var v = from x in cards
                    group x by x.MyValue into g
                    where g.Count() == 3
                    select g;

            return (v.Count() >= 2);
        }

        public bool Flush()
        {
            return Enumerable.Any(
            from x in cards
            group x by x.MySuit into g
            where g.Count() == 5
            select g
            );
        }

        public bool FullHouse()
        {
            if ((ThreeOfAKind() && OnePair()) || DoubleThreeOfAKind())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool FourOfAKind()
        {
            return Enumerable.Any(
            from x in cards
            group x by x.MyValue into g
            where g.Count() == 4
            select g
            );
        }





        public static bool operator <(Hand h1, Hand h2)
        {
            if (h1.rank != h2.rank)
            {
                return h1.rank > h2.rank;
            }
            else if (h1.rankDifferator != h2.rankDifferator)
            {
                return h1.rankDifferator > h2.rankDifferator;
            }
            else if (h1.highestCard != h2.highestCard)
            {
                return h1.highestCard > h2.highestCard;
            }
            else if (h1.highestCard != h2.highestCard)
            {
                return h1.highestCard > h2.highestCard;
            }
            else if (h1.secondHighestCard != h2.secondHighestCard)
            {
                return h1.secondHighestCard > h2.secondHighestCard;
            }
            else if (h1.thirdHighestCard != h2.thirdHighestCard)
            {
                return h1.thirdHighestCard > h2.thirdHighestCard;
            }
            else if (h1.fourthHighestCard != h2.fourthHighestCard)
            {
                return h1.fourthHighestCard > h2.fourthHighestCard;
            }
            else if (h1.fifthHighestCard != h2.fifthHighestCard)
            {
                return h1.fifthHighestCard > h2.fifthHighestCard;
            }
            else
            {
                throw new canNotDifferHandsException();
            }



        }

        public static bool operator >(Hand h1, Hand h2)
        {
            if (h1.rank != h2.rank)
            {
                return h1.rank < h2.rank;
            }
            else if (h1.rankDifferator != h2.rankDifferator)
            {
                return h1.rankDifferator < h2.rankDifferator;
            }
            else if (h1.highestCard != h2.highestCard)
            {
                return h1.highestCard < h2.highestCard;
            }
            else if (h1.highestCard != h2.highestCard)
            {
                return h1.highestCard < h2.highestCard;
            }
            else if (h1.secondHighestCard != h2.secondHighestCard)
            {
                return h1.secondHighestCard < h2.secondHighestCard;
            }
            else if (h1.thirdHighestCard != h2.thirdHighestCard)
            {
                return h1.thirdHighestCard < h2.thirdHighestCard;
            }
            else if (h1.fourthHighestCard != h2.fourthHighestCard)
            {
                return h1.fourthHighestCard < h2.fourthHighestCard;
            }
            else if (h1.fifthHighestCard != h2.fifthHighestCard)
            {
                return h1.fifthHighestCard < h2.fifthHighestCard;
            }
            else
            {
                throw new canNotDifferHandsException();
            }
        }
    }

}