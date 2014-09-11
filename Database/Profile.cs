using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player
{

    public class Profile
    {
        private enum Stat 
        {
            UserID,
            icon,
            eWin,
            eLoss,
            mWin,
            mLoss,
            hWin,
            hLoss
        };
        private String userID;
        private int eWin = 0;
        private int eLoss = 0;
        private int mWin = 0;
        private int mLoss = 0;
        private int hWin = 0;
        private int hLoss = 0;
        private Stat count;

        public Profile()
        { count = Stat.UserID; }

        public String getUserID()
        { return userID; }

        public int getTotalWins()
        { return eWin + mWin + hWin; }

        public int getTotalLoss()
        { return eLoss + mLoss + hLoss; }

        //Need to create a game difficulty ENUM
        //Within game engine?
        public void incWins() //public void incWins(Difficulty diff)
        { eWin++; }

        public void incLosses() //public void incLoss(Difficulty diff)
        { eLoss++;}

        public void addNext(Object add)
        {
            switch (count)
            {
                case Stat.UserID: userID = Convert.ToString(add);
                    break;
                case Stat.eWin: eWin = Convert.ToInt32(add);
                    break;
                case Stat.eLoss: eLoss = Convert.ToInt32(add);
                    break;
                case Stat.mWin: mWin = Convert.ToInt32(add); ;
                    break;
                case Stat.mLoss: mLoss = Convert.ToInt32(add); ;
                    break;
                case Stat.hWin: hWin = Convert.ToInt32(add); ;
                    break;
                case Stat.hLoss: hLoss = Convert.ToInt32(add); ;
                    break;
            }

            count++;
        }

        public override String ToString()
        {
            int winPer = (eWin * 100) / (eWin + eLoss);

            return "Username: " + userID + "\nWins: " + eWin + "\nLosses: " + eLoss + "\nWin %: " + winPer + "%";
        }
    }
}
