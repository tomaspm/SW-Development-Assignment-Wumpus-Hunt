using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WumpusHunt
{
    public class Rooms
    {
        Rooms[] roomsArray = new Rooms[10];
      
        int wumpusPosition = 0;
        int spiderposition = 0;
        int bottomlessPitPosition = 0;

        private string currentRoomNumber { get; set; }
        private string adjacentRoom1 { get; set; }
        private string adjacentRoom2 { get; set; }
        private string adjacentRoom3 { get; set; }
        private string currentRoomDescription { get; set; }
        private bool isWumpus { get; set; }
        private bool isSpider { get; set; }
        private bool isPit { get; set; }
        public Rooms(string currentRoom, string adjacentOne, string adjacentTwo, string adjacentThree, string roomDescription, bool hasWumpus,bool hasSpider,bool hasPit)
        {
            this.currentRoomNumber = currentRoom;
            this.adjacentRoom1 = adjacentOne;
            this.adjacentRoom2 = adjacentTwo;
            this.adjacentRoom3 = adjacentThree;
            this.currentRoomDescription = roomDescription;
            this.isWumpus = hasWumpus;
            this.isSpider = hasSpider;
            this.isPit = hasPit;
        }

        public void LoadRooms()
        {

            int i = 0;
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Databases/WumpusData.accdb");
                Console.Clear();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from RoomsTable";
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet dsRooms = new DataSet();
                adapter.Fill(dsRooms, "caveRoom");
                con.Close();
                foreach (DataRow RoomData in dsRooms.Tables["caveRoom"].Rows)
                {
                    roomsArray[i] = new Rooms("", "", "", "", "", false, false, false);
                    roomsArray[i].currentRoomNumber = RoomData[0].ToString();
                    roomsArray[i].adjacentRoom1 = RoomData[1].ToString();
                    roomsArray[i].adjacentRoom2 = RoomData[2].ToString();
                    roomsArray[i].adjacentRoom3 = RoomData[3].ToString();
                    roomsArray[i].currentRoomDescription = RoomData[4].ToString();
                    roomsArray[i].isWumpus = Convert.ToBoolean(RoomData[5]);
                    roomsArray[i].isSpider = Convert.ToBoolean(RoomData[6]);
                    roomsArray[i].isPit = Convert.ToBoolean(RoomData[7]);
                    ++i;
                }

            }
            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }
          

            
           
       


        }

        public void PlayWumpus(string player)
        {
            int maxArrows = 3;
            string currentRoom = "1";
            string adjRoom1 = "";
            string adjRoom2 = "";
            string adjRoom3 = "";
            string moveShootChoice = "";
            string roomToMove = "";
            string roomToShoot = "";
            bool isPlayerKilled = false;
            bool isWumpusKilled = false;
            string playerResult = "";
            string killedByWhat = "";
            DateTime playTime = DateTime.Now;
            Console.Clear();
            do
            {
                FixWumpusSpiderPitPosition();
              
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                                          ==========================================================================================");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                    You are in room {0,1}                                    |",  currentRoom);
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                               You have {0,1} arroes left                                    |", maxArrows);
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          |                                                                                         |");
                Console.WriteLine("                                                                          ==========================================================================================");
                Console.WriteLine();
                Console.WriteLine();


                for (int i = 0; i <= 9; ++i)
                {

                    if (roomsArray[i].currentRoomNumber == currentRoom)
                    {
                        Console.WriteLine("                                                                                                {0}                                             ",roomsArray[i].currentRoomDescription);
                        Console.WriteLine();
                        Console.WriteLine("                                                                                    There are tunnels to rooms {0,4} , {1,4} and {2,4}                       ", roomsArray[i].adjacentRoom1, roomsArray[i].adjacentRoom2,roomsArray[i].adjacentRoom3);
                        Console.WriteLine();
                Console.WriteLine("                                                                            ==========================================================================================");

                        adjRoom1 = roomsArray[i].adjacentRoom1;
                        adjRoom2 = roomsArray[i].adjacentRoom2;
                        adjRoom3 = roomsArray[i].adjacentRoom3;



                        for (int j= 0; j <= 9; ++j)
                        {
                            if (roomsArray[j].currentRoomNumber.ToString() == adjRoom1 || roomsArray[j].currentRoomNumber.ToString() == adjRoom2 || roomsArray[j].currentRoomNumber.ToString() == adjRoom3)
                            {
                                if(roomsArray[j].isWumpus==true)
                                {
                                    Console.WriteLine("                                                                                         You smell some nasty Wumpus!                                     ");
                                }
                                if (roomsArray[j].isSpider == true)
                                {
                                    Console.WriteLine("                                                                                         You hear a faint clicking noise..                                    ");
                                }
                                if (roomsArray[j].isPit == true)
                                {
                                    Console.WriteLine("                                                                                                 You smell a dank odor..                                    ");
                                }
                            }
                          


                        }
                           
                        }





                    
                    
                    }
               
                
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("                                                                                                            Move or Shoot(M/S) :");
                moveShootChoice = Console.ReadLine().ToUpper();
                switch(moveShootChoice)
                {
                    case "M":
                        Console.Write("                                                                                                   Move to which room ? : ");
                        roomToMove = Console.ReadLine();
                        Console.WriteLine("                                                                           ==========================================================================================");
                        Console.WriteLine();
                        if (roomToMove!=adjRoom1 && roomToMove!=adjRoom2 && roomToMove != adjRoom3 )
                        {
                            Console.WriteLine("                                                                                    Dimwit! You can't get to there from here.");
                            Console.WriteLine();
                            Console.Write("                                                                                        Press a key to continue...    ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                   
                        for (int i = 0; i <= 9; ++i)
                        {

                            if (roomsArray[i].currentRoomNumber == roomToMove)
                            {
                                if(roomsArray[i].isWumpus==true || roomsArray[i].isSpider==true || roomsArray[i].isPit==true)
                                {
                                    
                                    isPlayerKilled = true;
                                    if(roomsArray[i].isWumpus ==true)
                                    {
                                        Console.WriteLine("                                                              Wumpus in Room {0,2}...UNLUCKY ....Palyer   {1,4} ,..  You are Killed",roomToMove,player);
                                        playerResult = "Lost";
                                        killedByWhat = "Wumpus";
                                        Console.WriteLine();
                                        Console.Write("                                                                                        Press a key to continue...    ");
                                        Console.ReadKey();

                                    }
                                    if (roomsArray[i].isSpider  == true)
                                    {
                                        Console.WriteLine("                                                             Spider in Room {0,2}...UNLUCKY ....Palyer    {1,4} ,..You are Killed", roomToMove,player);
                                        playerResult = "Lost";
                                        killedByWhat = "Spider";
                                        Console.WriteLine();
                                        Console.Write("                                                                                        Press a key to continue...    ");
                                        Console.ReadKey();

                                    }
                                    if (roomsArray[i].isPit == true)
                                    {
                                        Console.WriteLine("                                                             Bottomless Pit in Room {0,2}...UNLUCKY ....Palyer   {1,4} ,..You are Killed", roomToMove,player);
                                        playerResult = "Lost";
                                        killedByWhat = "Bottomless Pit";
                                        Console.WriteLine();
                                        Console.Write("                                                                                        Press a key to continue...    ");
                                        Console.ReadKey();

                                    }
                                    
                                

                                }
                               
                            }

                        }
                        currentRoom = roomToMove;
                        break;
                    case "S":
                        Console.Write("                                                                                                         Shoot to which room ? : ");
                        roomToShoot = Console.ReadLine();
                       
                        if (roomToShoot != adjRoom1 && roomToShoot != adjRoom2 && roomToShoot != adjRoom3)
                        {
                            Console.WriteLine("                                                                                        Dimwit! You can't shoot to there from here.");
                            Console.WriteLine();
                            Console.Write("                                                                                        Press a key to continue...    ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                  
                        for (int i = 0; i <= 9; ++i)
                        {

                            if (roomsArray[i].currentRoomNumber == roomToShoot)
                            {
                                if (roomsArray[i].isWumpus == true) 
                                {

                                    isWumpusKilled= true;
                                    playerResult = "Won";
                                    maxArrows--;
                                    killedByWhat = "Not Applicable(Player Won)";
                                    Console.WriteLine();
                                    Console.WriteLine("                                                                   ==========================================================================================");

                                    Console.WriteLine("                                                                                  Your arrow goes down the tunnel and finds its mark!");
                                    Console.WriteLine();

                                    Console.WriteLine("                                                                               Player    {0,4}   shot the Wumpus! ** You Win! **                             ",player);
                                    Console.WriteLine();
                                    Console.WriteLine("                                                                                                 Enjoy your fame!");
                                    Console.WriteLine();
                                    Console.WriteLine("                                                                   ==========================================================================================");
                                    Console.WriteLine();
                                    Console.Write (   "                                                                                        Press a key to continue...    ");
                                    Console.ReadKey();
                                }
                                else
                                {

                                    Console.WriteLine("                                                                                 Your arrow goes down the tunnel and is lost.You missed..");
                                    maxArrows--;

                                    Console.WriteLine();
                                    Console.Write("                                                                                        Press a key to continue...    ");
                                    Console.ReadKey();
                                }

                            }

                        }
                        
                        break;
                    default:
                        Console.Write("                                                                                                           Invlaid option...Please Re-enter");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }


                ReFixWumpusSpiderPitPosition();

            } while (maxArrows > 0 && isPlayerKilled == false  &&  isWumpusKilled  == false);

       if(maxArrows==0 && isWumpusKilled == false)
            {
                Console.WriteLine("                                                                                                Your arrows exhausted....and player  {0,4} you LOST the game ",player);
                playerResult = "Lost";
                killedByWhat = "Not Killed..but arrows exhausted";

                Console.WriteLine();
                Console.Write("                                                                                                                 Press a key to continue...    ");
                Console.ReadKey();
              
            }

           




            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Databases/WumpusData.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Insert into PlayerHistory(playerInfo,playerResult,playedTime,ArrowsLeft,killedBy) Values('" + player + "','" + playerResult + "','" + playTime + "'," + maxArrows + ",'" + killedByWhat + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }


            catch (OleDbException e)
            {
                Console.WriteLine("Error: {0}", e.Errors[0].Message);
            }




        }

        public void FixWumpusSpiderPitPosition()
        {
            Random rnd = new Random();

           do
            {

                wumpusPosition = rnd.Next(2, 11);
                spiderposition = rnd.Next(2, 11);
                bottomlessPitPosition = rnd.Next(2, 11);


            } while (wumpusPosition == spiderposition|| wumpusPosition == bottomlessPitPosition || spiderposition ==  bottomlessPitPosition);

          
            

       

            for(int i=0;i<=9;++i)
            {
                if (roomsArray[i].currentRoomNumber.ToString()==wumpusPosition.ToString())
                {
                    roomsArray[i].isWumpus = true;

                }
                if (roomsArray[i].currentRoomNumber.ToString() == spiderposition.ToString())
                {
                    roomsArray[i].isSpider = true;

                }
                if (roomsArray[i].currentRoomNumber.ToString() == bottomlessPitPosition.ToString())
                {
                    roomsArray[i].isPit = true;

                }

            }
       


         }

       public void  ReFixWumpusSpiderPitPosition()

        {

            for (int i = 0; i <= 9; ++i)
            {
                roomsArray[i].isWumpus = false;
                roomsArray[i].isSpider = false;
                roomsArray[i].isPit = false;
               
            }

       
        }

        

    }
    }

   






