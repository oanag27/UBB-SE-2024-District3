using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Statistics
{
    class StatisticsService
    {
        int timeSpentOnApp;
        User friend;
        int streakNb;
        public StatisticsService() { }

        public StatisticsService(int timeSpentOnApp, User friend, int streakNb)
        {
            this.timeSpentOnApp = timeSpentOnApp;
            this.streakNb = streakNb;
            this.friend = friend;
        }

        public int seeAverageTimeSpent()
        {
            return 1;
        }

        public string getFriendName()
        {
            return "@newusername";
        }
        //TO DO:
        /*
         * Create a list of users
         * Create a function that checks the consecutivity of texts 
         */

    }
}
