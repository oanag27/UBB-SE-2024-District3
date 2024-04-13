using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository
{
    public class ProfileNetworkInfoRepository<T>
    {

        private List<UserProfileSocialNetworkInfo> repositoryList;

        public ProfileNetworkInfoRepository(List<UserProfileSocialNetworkInfo> list)
        {
            repositoryList = list;
        }


        public List<UserProfileSocialNetworkInfo> getProfileRepositoryList()
        {
            return this.repositoryList;
        }
        public void setProfileRepositoryList(List<UserProfileSocialNetworkInfo> newList)
        {
            this.repositoryList = newList;
        }


        public bool AddProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToAdd)
        {
            foreach (var profile in this.getProfileRepositoryList())
            {
                if (profile.user.id == profileToAdd.user.id)
                    return false;
            }
            this.repositoryList.Add(profileToAdd);

            return true;
        }

        public bool RemoveProfileSocialNetworkInfo(UserProfileSocialNetworkInfo profileToRemove)
        {
            foreach (var profile in this.getProfileRepositoryList())
            {
                if (profile.user.id == profileToRemove.user.id)
                {
                    this.repositoryList.Remove(profile);
                    return true;
                }
            }

            return false;
        }
    }
}
