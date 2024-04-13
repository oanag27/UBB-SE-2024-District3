using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.entities
{
    public class CloseFriendProfile : IComparable<CloseFriendProfile>
    {
        public User user { get; set; }

        public CloseFriendProfile(User user)
        {
            this.user = user;
        }

        public int CompareTo(CloseFriendProfile other)
        {
            return this.user.CompareTo(other.user);
        }
    }
}
