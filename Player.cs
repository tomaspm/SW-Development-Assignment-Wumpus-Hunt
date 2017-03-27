using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WumpusHunt
{
    public class Player
    {
       
        private int playerNumber { get; set; }
        private string playerDetails{ get; set; }
       
        private string playerResult{get;set;}
        private   DateTime playedTime { get; set; }
        private int ArrowsLeft{ get; set;}
        private string KilledBy { get; set; }

        public Player(int playersNumber,string playerInfo, string playerStatus, DateTime playTime, int arrowBalance,string killedByWhom)
        {

            this.playerNumber = playersNumber;
            this.playerDetails = playerInfo;
            this.playerResult = playerStatus;
            this.playedTime = playTime;
            this.ArrowsLeft = arrowBalance;
            this.KilledBy = killedByWhom;
            
    
        }
        public Player()
        {
            

        }
        public string SetPlayer()
       
        {
            string playerInformation; 
            playerInformation = this.playerDetails;

            return (playerInformation);
        }
         public void  ViewPlayerHistory()
           {
               int recCount = 0;
               int i = 0;
               int playersArrayLength = 0;
               Console.Clear();
        
              OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Databases/WumpusData.accdb");
              OleDbCommand cmd = con.CreateCommand();
              cmd.CommandText = "select * from PlayerHistory";
              con.Open();
              OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
              DataSet dsPlayers = new DataSet();
              adapter.Fill(dsPlayers, "playersData");
              con.Close();
              recCount = dsPlayers.Tables["playersData"].Rows.Count;
              Player[] playersArray = new Player[recCount];
              foreach (DataRow PlayerData in dsPlayers.Tables["playersData"].Rows)
               {
                   playersArray[i] = new Player();
                   playersArray[i].playerNumber = Convert.ToInt32(PlayerData[0]);
                   playersArray[i].playerDetails= PlayerData[1].ToString();
                   playersArray[i].playerResult = PlayerData[2].ToString();
                   playersArray[i].playedTime = Convert.ToDateTime(PlayerData[3]);
                   playersArray[i].ArrowsLeft = Convert.ToInt32(PlayerData[4]);
                   playersArray[i].KilledBy = PlayerData[5].ToString();
                   ++i;
               }

            playersArrayLength = playersArray.Length;

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
            Console.WriteLine("                                                                          |                                        Players History                                  | ");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          |                                                                                         |");
            Console.WriteLine("                                                                          ==========================================================================================");


         
            Console.WriteLine();
            Console.WriteLine();
                 Console.WriteLine(String.Format("                                          {0,13}|{1,-30}|{2,-8}|{3,-30}|{4,15}|{5,-30}", "Player Number", "Player Details", "Result", "Date Played", "Arrows Left","Killed By"));
                 Console.WriteLine(String.Format("                                          {0,-126}","----------------------------------------------------------------------------------------------------------------------------------------"));

            for (i = 0; i < playersArrayLength; ++i)
            {
                Console.WriteLine(String.Format("                                          {0,13}|{1,-30}|{2,-8}|{3,-30}|{4,15}|{5,-30}", playersArray[i].playerNumber, playersArray[i].playerDetails, playersArray[i].playerResult, playersArray[i].playedTime, playersArray[i].ArrowsLeft,playersArray[i].KilledBy));
            }
                Console.WriteLine(String.Format("                                          {0,-126}", "----------------------------------------------------------------------------------------------------------------------------------------"));
            Console.WriteLine();  
            Console.WriteLine();
            Console.Write("                                                                                                       Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            

        }



    }
}
