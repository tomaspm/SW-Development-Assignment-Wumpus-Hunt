using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusHunt
{
    class Program
    {
        public static string playerInfo = "";
       

        static void Main(string[] args)
        {
            string choice = "0";

            string playerName = "Unregistered";
            string playerEmail = "";
            string playerDetails;
            playerDetails = playerName + "   " + playerEmail;
            Player player1 = new Player(0, playerDetails, "", DateTime.Now, 0, "");
            playerInfo = player1.SetPlayer();

            do
            {
              
              /*  string playerName = "Unregistered";
                string playerEmail = "";
                string playerDetails;
                playerDetails = playerName + "   " + playerEmail;
                Player player1 = new Player(0, playerDetails, "", DateTime.Now, 0, "");
                playerInfo = player1.SetPlayer();*/
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                                          ==========================================================================================");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                        Hunt the Wumpus                                  | ");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                    Game Developed by : DevOps                           | ");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          ==========================================================================================");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                   Your Options                                          |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               1. View Players History                                   |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               2. Read Instructions                                      |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               3. Register Player                                        |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               4. Hunt Wumpus                                            |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               5. Exit                                                   |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          ==========================================================================================");

                Console.WriteLine();
                Console.Write("                                                                                                             Enter your choice:(1/2/3/4/5) : ");
                choice = Console.ReadLine();
               
        
                
                switch (choice)
                {

                    case "1":
                        Player playerHist = new Player();
                        playerHist.ViewPlayerHistory();
                        break;
                    case "2":
                        ReadInstrcutions();
                        break;
                    case "3":
                                Console.Clear();
                               Console.WriteLine();
                               Console.WriteLine();
                               Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("                                                                          ==========================================================================================");
                                Console.WriteLine("                                                                          |                                                                                         |");
                                Console.WriteLine("                                                                          |                                        Hunt the Wumpus                                  | ");
                                Console.WriteLine("                                                                          |                                                                                         |");
                                Console.WriteLine("                                                                          |                                        Register Player                                  | ");
                                Console.WriteLine("                                                                          |                                                                                         |");
                                Console.WriteLine("                                                                          |                                                                                         |");
                                Console.WriteLine("                                                                          ==========================================================================================");
                                Console.Write("                                                                                                                 Enter player name      :");
                                playerName = Console.ReadLine();
                                Console.Write("                                                                                                                 Enter player email id  :");
                                playerEmail = Console.ReadLine();
                                Console.WriteLine("                                                                          ==========================================================================================");
                                playerDetails = playerName + "   " + playerEmail;
                                Player huntPlayer = new Player(0, playerDetails, "", DateTime.Now, 0, "");
                                playerInfo = huntPlayer.SetPlayer();
                                
                        break;
                    case "4":
                        Rooms newRoom = new Rooms("", "", "", "", "",false,false,false);
                        newRoom.LoadRooms();
                        newRoom.PlayWumpus(playerInfo);
                        playerName = "Unregistered";
                       playerEmail = "";
                        playerDetails="";
                        playerDetails = playerName + "   " + playerEmail;
                        Player newPlayer = new Player(0, playerDetails, "", DateTime.Now, 0, "");
                        playerInfo = newPlayer.SetPlayer();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine();
                        Console.Write("                                                                                                         Invlaid Choce...Please re-enter");
                        Console.ReadKey();
                        break;
                }

            } while (choice != "5");
         
        }
      static  void  ReadInstrcutions()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                                          ==========================================================================================");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                        Hunt the Wumpus                                  | ");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                    Game Developed by : DevOps                           | ");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                         Instructions                                    |");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          ==========================================================================================");
            Console.WriteLine();
            Console.WriteLine(" You are a mighty warrior, and armed with your trusty bow and 3 arrows, you enter The Caves in search of the mighty Wumpus.If you shoot the Wumpus, you are victorious and the masses will praise you, but if you stumble upon the Wumpus unaware, it will eat you!Also, beware of the webs of the giant poisonous spiders and the bottomless pits! Your senses of smell and hearing will aid you on your quest, for the Wumpus does not bathe and can be smelled one room away.Also, the clicking mandibles of the poisonous spiders can be heard one room away, and the foul odor of a bottomless pit can be smelled one room away.");
            Console.WriteLine();
            Console.Write("                                                                                                       Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}












