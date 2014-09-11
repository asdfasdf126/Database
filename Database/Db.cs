using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Game.Player;

namespace Game.Database
{
    public static class Db
    {
        //Needs a difficulty to be passed to it to find which set
        //of requirments to sort by
        //retrieves top 10 users based on based on wins and difficulty
        public static LinkedList<Profile> getTopTen()
        {
            LinkedList<Profile> profiles = new LinkedList<Profile>();
            String difficulty = "eWin";

            profiles = query("Select Top 10 userID, icon, eWin, eLoss, mWin, mLoss, hWin, hLoss From Users order by " + difficulty + " Desc;");

            //Debug for printing all profiles to console window
            for (int x = 0; x < profiles.Count; x++)
                Console.WriteLine(profiles.ElementAt(x) + "\n");

            return profiles;
        }

        //retrieves a single profile based on a unique userID
        public static Profile getUser(String userID)
        {
            try
            {
                //unique userID is found
                return query("Select Top 10 userID, icon, eWin, eLoss, mWin, mLoss, hWin, hLoss From Users Where userID = \'" + userID + "\';").ElementAt(0);
            }
            catch(Exception)
            {
                //unique UserID is not found
                return null;
            }
        }

        //takes a query to grab profiles and
        //returns an LinkedList containing those records
        private static LinkedList<Profile> query(String cmd)
        {
            LinkedList<Profile> result = new LinkedList<Profile>();


            //Connects to a local server using windows authentication
            //destroys sqlconnection on completion of this block
            using (SqlConnection myConnection = new SqlConnection("Server = localhost; database = Game; Integrated Security=SSPI;"))
            {
                //opens connection to database and initializes 
                //and executes query
                myConnection.Open();
                SqlCommand command = new SqlCommand(cmd, myConnection);
                SqlDataReader reader = command.ExecuteReader();

                //Grabs one record at a time
                while (reader.Read())
                {
                    Profile newProfile = new Profile();

                    //goes through the record adding each field
                    //to the player profile
                    for (int x = 0; x < reader.VisibleFieldCount; x++)
                        newProfile.addNext(reader[x]);

                    //adds each profile to the linkedlist
                    //containing all profiles
                    result.AddLast(newProfile);
                }

                //closes open connection to database
                myConnection.Close();
            }

            //return list of profiles
           return result;
        }
    }
}
