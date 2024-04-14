using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository
{
    public class UsersRepository
    {
        public List<User> usersRepositoryList { get; set; }


        public UsersRepository() { }
        public UsersRepository(List<User> usersRepositoryList) { this.usersRepositoryList = usersRepositoryList; }



        public User GetUserByName(string username)
        {
            foreach (var user in usersRepositoryList)
            {
                if (user.username == username) return user;
            }

            return null;
        }

        public List<User> GetAllUsers() { return usersRepositoryList; }
    }
}
