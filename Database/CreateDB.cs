using System;
using System.Data.SqlClient;

namespace Game.Database
{
    //DEBUG class to show database
    internal static class CreateDB
    {
        //Delete and recreate database to have a fresh
        //instance to work with
        public static void createDB()
        {
            String cmd = "Drop table users; " +
                         "Create table users (userID varchar(15) primary key not null, " +
                         "pw varchar(15) not null, " +
                         "icon varchar(15) not null, " +
                         "eWin int not null, " +
                         "eLoss int not null, " +
                         "mWin int not null, " +
                         "mLoss int not null, " +
                         "hWin int not null, " +
                         "hLoss int not null);";

            query(cmd);
        }

        //Execute Query
        private static void query(String cmd)
        {
            using (SqlConnection myConnection = new SqlConnection("Server = localhost; database = Game; Integrated Security=SSPI;"))
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand(cmd, myConnection);

                try
                {
                    command.ExecuteNonQuery();
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                myConnection.Close();
            }
        }

        //Sets random values in the database
        public static void populateDB()
        {
            Random r = new Random();
            String[] names = { "Jackson", "Aiden", "Liam", "Lucas", "Noah", "Mason",
                               "Jayden", "Ethan", "Jacob", "Jack", "Caden", "Logan",
                               "Benjamin", "Michael", "Caleb", "Ryan", "Alexander", 
                               "Elijah", "James", "William", "Oliver", "Connor", "Matthew",
                               "Daniel", "Luke", "Brayden", "Jayce", "Henry", "Carter",
                               "Dylan", "Gabriel", "Joshua", "Nicholas", "Isaac", "Owen", 
                               "Nathan", "Grayson", "Eli", "Landon", "Andrew", "Max",
                               "Samuel", "Gavin", "Wyatt", "Christian", "Hunter",
                               "Cameron", "Evan", "Charlie", "David" 
                             };

            for(int x = 0; x < names.Length; x++)
            {
                String cmd = "Insert into users (userID, pw, icon, eWin, eLoss, mWin, mLoss, hWin, hLoss) Values (" +
                             "\'" + names[x] + "\', '" + names[x] + "\', \'Default.gif\', \'" + r.Next() % 256 + "\', \'" + 
                             r.Next() % 256 + "\', \'" + r.Next() % 256 + "\', \'" + r.Next() % 256 + "\', \'" +
                             r.Next() % 256 + "\', \'" + r.Next() % 256 + "\');";

                query(cmd);
            }

        }
    }
}
