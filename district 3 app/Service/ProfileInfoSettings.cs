using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fancierProfile.Service
{
    internal class ProfileInfoSettings
    {
        private Guid profileId;
        private string username;
        private string password;
        private DateTime birthday;
        private string email;
        private string phoneNumber;
        private string profileDescription;
        private string dailyMotto;
        private string links;


        public ProfileInfoSettings() { }
        public bool addLink(string newLink)
        {
            return true;
        }
        public bool removeLink(string linkToRemove) {  return false; }
        public bool updateLink(string link, string newLink) { return false; }

    }
}
