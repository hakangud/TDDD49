using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Poker.Players;
using Poker.Game;
using System.Xml.Linq;
using System.Xml;
using System.Data;

namespace Poker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player p, p2;
        private PokerTable pt;
        private XDocument xdoc;
        private static GameContext db = new GameContext();
        public MainWindow()
        {
            PlayerEntity pe = new PlayerEntity();

            List<PlayerEntity> pl = new List<PlayerEntity>();
            foreach (DataRow o1 in pl.Tables[0].Rows)
            InitializeComponent();
            p = new HumanPlayer();
            pe.PlayerName = "Klara";
            p = (HumanPlayer)pe;
            player1NameTextBlock.Text = p.PlayerName;
            /*
            p.PlayerName = "Hans";
            //DataContext = p;
            p2 = new HumanPlayer();
            p2.PlayerName = "Satan";
            pt = new PokerTable();
            player1NameTextBlock.DataContext = p;
            player2NameTextBlock.DataContext = p2;

            XElement ge = new XElement("Test");
            XElement p1 = new XElement("Player", p);
            XElement info = new XElement("Info", "Jag är sämst");
            ge.Add(p1);
            ge.Add(info);
            ge.Save("test.xml");
            xdoc = XDocument.Load("test.xml");
            XDocument tablee = new XDocument(
                new XElement("Table",
                new XAttribute("ID", 1),
                new XElement("Players",
                new XElement("Names",
                new XAttribute("Name", "Hans"),
                new XAttribute("Name1", "Peter")))));
            XElement table = new XElement("Table",
                new XElement("Table",
                new XAttribute("ID", 1)));

            XElement players = new XElement("Players");
            players.Add(new XElement("Player",
                new XElement("Name", "Petter"),
                new XElement("Chips", 1000)));
            players.Add(new XElement("Player",
                new XElement("Name", "Frans")));

            //XElement drawnCards = new XElement("Drawn Cards");


            table.Add(players);
            table.Save("table.xml");

            List<PlayerEntity> pl = new List<PlayerEntity>();
            XDocument xd = XDocument.Load("table.xml");

            // set data to xml
            var items = from item in xd.Descendants("Player")
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("Name", "Fia");
            }

            // get data from xml
            var player = from p in xd.Descendants("Player")
                         select new
                         {
                             Name = (string)p.Element("Name")
                         };
            foreach (var p in player)
            {
                pl.Add(new HumanPlayer { PlayerName = p.Name });
            }

            xd.Save("table.xml");
            

            player1NameTextBlock.Text = pl[0].PlayerName;
            player2NameTextBlock.Text = pl[1].PlayerName;*/
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            p.PlayerName = xdoc.ToString();
        }
    }
}
