using District_3_App.Enitities.Mocks;
using District_3_App.ExtraInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Service
{
    internal class CasualProfileService
    {
        private SnapshotsService snapshotsService { get; set; }
        private ProfileInfoSettings profileInfoSettings { get; set; }
        //private ExtraInfoService extraInfoService { get; set; }

        public CasualProfileService(SnapshotsService snapshotsService, ProfileInfoSettings profileInfoSettings)
        {
            this.snapshotsService = snapshotsService;
            this.profileInfoSettings = profileInfoSettings;
        }
        public List<MockPost> getConnectedUserPosts() {
            return null;
        }

        public SnapshotsService getSnapshotsService()
        {
            return snapshotsService;
        }
        public ProfileInfoSettings getProfileInfoSettings()
        {
            return profileInfoSettings;
        }
    }
}
