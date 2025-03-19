using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace TestAboutCapitals
{
    public static class Operations {

        public static readonly string CAPITALS_FILE_PATH = "assets\\files\\dboCapitals.txt";
        public static readonly string SCOREBOARD_FILE_PATH = "assets\\files\\dboScoreboard.txt";
        private static int higherIdPlayer = 0;

        public static void RetrieveAllData()
        {
            //Retrieve the data UserName and Score from the table dbo.Scoreboard and Add it to the Global Variables TopUserName and TopScore
            string directory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory + "\\TestAboutCapitals\\"));
            StreamReader reader = new StreamReader(directory + Operations.CAPITALS_FILE_PATH, Encoding.Default, true);
            string line = reader.ReadLine();
            int start = 0;
            int at = 0;
            int end = line.Length;
            while ((start < end) && (at > -1))
            {
                at = line.IndexOf("|", start, end - start);
                Program.AllIDsCountries.Add(Convert.ToInt32(line.Substring(start, at - start)));
                start = at + 1;
                at = line.IndexOf("|", start, end - start);
                Program.AllCountries.Add(line.Substring(start, at - start));
                start = at + 1;
                at = line.IndexOf(";", start, end - start);
                Program.AllCapitals.Add(line.Substring(start, at - start));
                start = at + 1;
            }
        }

        public static int getMaxIdPlayer()
        {
            return Operations.higherIdPlayer;
        }

        public static void GetScoreboard()
        {
            Program.AllIDsScoreboard.Clear();
            Program.AllUserScoreboard.Clear();
            Program.AllScoreScoreboard.Clear();
            Program.AllGameModesScoreboard.Clear();
            Program.AllEntryDatesScoreboard.Clear();
            {
                string directory = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"TestAboutCapitals\\"));
                string line = System.IO.File.ReadAllText(@directory + SCOREBOARD_FILE_PATH);
                int start = 0;
                int at = 0;
                int end = line.Length;
                while ((start < end) && (at > -1))
                {
                    at = line.IndexOf("|", start, end - start);
                    //id of score registry
                    Program.AllIDsScoreboard.Add(Convert.ToInt32(line.Substring(start, at - start)));
                    start = at + 1;
                    //name of player
                    at = line.IndexOf("|", start, end - start);
                    Program.AllUserScoreboard.Add(line.Substring(start, at - start));
                    start = at + 1;
                    //score
                    at = line.IndexOf("|", start, end - start);
                    Program.AllScoreScoreboard.Add(Convert.ToInt32(line.Substring(start, at - start)));
                    start = at + 1;
                    //at what level (10, 20, 30)
                    at = line.IndexOf("|", start, end - start);
                    Program.AllGameModesScoreboard.Add(Convert.ToInt32(line.Substring(start, at - start)));
                    start = at + 1;
                    //time stamp
                    at = line.IndexOf(";", start, end - start);
                    Program.AllEntryDatesScoreboard.Add(Convert.ToDateTime(line.Substring(start, at - start)));
                    start = at + 1;
                }
                Operations.higherIdPlayer = Program.AllIDsScoreboard.Max();
            }
        }

        public static void Randomize()
        {
            //Declaration of General Variables of Control
            int numEntriesOnDataBase = Program.NumTotalCountriesDataBase;
            Random random = new Random();

            //Randomizing the order of the options
            for (int i = 1; i <= 4;)
            {
                int randomTemp = random.Next(4);
                if (!Program.RandomOrder.Contains(randomTemp))
                {
                    Program.RandomOrder.Add(randomTemp);
                    i++;
                }
            }
            //Randomizing the actual IDs of the Capitals options
            bool firstCountryAlready = false;
            int randomCapTemp;
            for (int y = 1; y <= 4;)
            {                    
                randomCapTemp = random.Next(1, numEntriesOnDataBase);
                while (firstCountryAlready == false)
                {
                    if (!Program.AlreadyCountries.Contains(randomCapTemp))
                    {
                        Program.AlreadyCountries.Add(randomCapTemp);
                        Program.FourCountries.Add(Program.AllCountries[randomCapTemp]);

                        firstCountryAlready = true;
                        continue;
                    }
                    else
                    {
                        randomCapTemp = random.Next(1, numEntriesOnDataBase + 1);
                    }
                    
                }
                
                if (!Program.RandomIDs.Contains(randomCapTemp) && firstCountryAlready == true)
                {
                    Program.RandomIDs.Add(randomCapTemp);
                    Program.FourCapitals.Add(Program.AllCapitals[randomCapTemp]);
                    y++;
                }
            }
        }
    }
}
