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
        Dictionary<User, int> friends = new Dictionary<User, int>();

        public StatisticsService()
        {

            User user1 = new User(Guid.NewGuid(), "username1", "password1", "user1@yahoo.ro", new DateTime(2020, 4, 21, 19, 20, 29));
            User user2 = new User(Guid.NewGuid(), "username2", "password2", "username2@gmail.ro", new DateTime(2012, 3, 22, 21, 10, 11));
            User user3 = new User(Guid.NewGuid(), "username3", "password3", "user3@yahoo.com", new DateTime(2021, 4, 5, 23, 32, 58));
            User user4 = new User(Guid.NewGuid(), "username4", "password4", "username4@stud.ubbcluj.ro", new DateTime(2022, 8, 30, 21, 28, 39));
            User user5 = new User(Guid.NewGuid(), "username5", "password5", "username4@gmail.es", new DateTime(2023, 11, 22, 13, 44, 55));
            User user6 = new User(Guid.NewGuid(), "username6", "password6", "username6@stud.ubbcluj.ro", new DateTime(2022, 8, 30, 21, 28, 39));
            User user7 = new User(Guid.NewGuid(), "username7", "password7", "username7@gmail.es", new DateTime(2023, 11, 22, 13, 44, 55));
            friends.Add(user1, 45);
            friends.Add(user2, 60);
            friends.Add(user3, 12);
            friends.Add(user4, 30);
            friends.Add(user5, 120);
            friends.Add(user6, 1);
            friends.Add(user7, 33);
            var sortedSequence = friends.OrderByDescending(pair => pair.Value);
            Dictionary<User, int> sortedDictionary = sortedSequence.ToDictionary(pair => pair.Key, pair => pair.Value);

            friends = sortedDictionary;

        }

        public StatisticsService(int timeSpentOnApp, Dictionary<User, int> friends)
        {
            this.timeSpentOnApp = timeSpentOnApp;
            this.friends = friends;
        }

        public int seeAverageTimeSpent()
        {
            return 1;
        }



        public List<string> GetFriendNames()
        {
            List<string> friendNames = new List<string>();
            int contor = 5;
            foreach (User user in friends.Keys)
            {
                contor--;
                friendNames.Add(user.username);
                if (contor == 0)
                    return friendNames;
            }

            return friendNames;
        }
        public List<int> GetUserStreaks()
        {
            List<int> friendStreaks = new List<int>();
            int contor = 5;
            foreach (User user in friends.Keys)
            {
                contor--;
                friendStreaks.Add(friends[user]);
                if (contor == 0)
                    return friendStreaks;
            }

            return friendStreaks;

        }

        //TO DO:
        /*
         * A more efficient method to select top 5 values from dictionary
         * Create a function that checks the consecutivity of texts 
         * Compute the time the app runs
         */

    }
}
