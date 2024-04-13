using District_3_App.Enitities.Mocks;
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

        public CasualProfileService(SnapshotsService snapshotsService) {
            this.snapshotsService = snapshotsService;
        }
        public List<MockPost> getConnectedUserPosts() {
            return null;
        }

        public SnapshotsService getSnapshotsService()
        {
            return snapshotsService;
        }
    }
}
