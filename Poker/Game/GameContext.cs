using Poker.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Poker.Game
{
    class GameContext : DbContext
    {
        //public GameContext() : base()
        //{
        //    //Database.SetInitializer(new CreateDatabaseIfNotExists<GameContext>());
        //    //PokerTable pt = new PokerTable();
        //    //pt.Pot = 20;
        //    //Table.Add(pt);
        //    //SaveChanges();
        //    //SaveChanges();
        //}

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<PokerTableEntity> Table { get; set; }
    }
}
