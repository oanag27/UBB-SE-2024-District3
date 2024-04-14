using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using District_3_App.Repository;
using District_3_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace District_3_App.HighlightsFE
{
    public partial class SeeHighlightPosts : UserControl
    {
        private List<PhotoInfo> photosInfo = new List<PhotoInfo>();
        private SnapshotsService snapshotsService;


        public SeeHighlightPosts(Guid highlightId)
        {
            HighlightsRepo highlightsRepo = new HighlightsRepo();
            SnapshotsRepo snapshotsRepo = new SnapshotsRepo(highlightsRepo);
            SnapshotsService snapshotsService1 = new SnapshotsService(snapshotsRepo);
            CasualProfileService casualProfileService = new CasualProfileService(snapshotsService1);
            snapshotsService = casualProfileService.getSnapshotsService();

            InitializeComponent();
            Highlight h = snapshotsService.GetHighlight(highlightId);
            List<MockPhotoPost> postsToShow = highlightsRepo.GetPostsOfHighlight(new Guid("11111111-1111-1111-1111-111111111111"), highlightId);

            foreach (MockPhotoPost post in postsToShow)
            {

                var photoInfo = new PhotoInfo(post.getPhoto(), post.getPostId());
                photoInfo.Description = post.getDescription();

                photosInfo.Add(photoInfo);
            }

            DataContext = photosInfo;
        }
    }
}
