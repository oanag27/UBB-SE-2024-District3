using fancierProfile.Entities;
using fancierProfile.Mocks;
using fancierProfile.Repository;
using fancierProfile.Service;
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

namespace fancierProfile.HighlightsFE
{
    /// <summary>
    /// Interaction logic for SeeHighlightPosts.xaml
    /// </summary>
    public partial class SeeHighlightPosts : UserControl
    {
        private List<MockPhotoPost> postsToShow = new List<MockPhotoPost>();
        HighlightsRepo highlightsRepo = new HighlightsRepo();
        private List<PhotoInfo> photosInfo = new List<PhotoInfo>();
    
        public SeeHighlightPosts(Guid highlightId)
        {
            InitializeComponent();
            Highlight h =highlightsRepo.getHighlight(highlightId);           
            postsToShow=highlightsRepo.getPostsOfHighlight(highlightId);
            foreach (MockPhotoPost post in postsToShow)
            {
               
                var photoInfo = new PhotoInfo(post.getPhoto(), post.getPostId());
                photoInfo.Description = post.getDescription();

                photosInfo.Add(photoInfo);
            }

            DataContext =photosInfo;
        }

    }
}
