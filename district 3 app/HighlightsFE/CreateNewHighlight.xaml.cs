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
using System.Windows.Shapes;

namespace fancierProfile.HighlightsFE
{
    /// <summary>
    /// Interaction logic for CreateNewHighlight.xaml
    /// </summary>
    public partial class CreateNewHighlight : Window
    {
        private List<Guid> guids = new List<Guid>();
        private string newHighlightName;
        private string newHighlightCover;

        public CreateNewHighlight(List<Guid> selectedPostsGuids)
        {
            InitializeComponent();
            guids=selectedPostsGuids;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            newHighlightName = textInputBox.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Highlight h=new Highlight(newHighlightName, newHighlightCover);
            if (newHighlightName == null) {
                newHighlightName = "Highlight_" + h.getHighlightId().ToString().Replace("-", "_");
                h.setName(newHighlightName);
            }
            int rnd = new Random().Next(0, guids.Count());
            HighlightsRepo repo = new HighlightsRepo(); 
            if(guids.Count == 0)
            {
                newHighlightCover = "../Images/black.png";
            }
            while (newHighlightCover == null)
            {
                foreach(MockPhotoPost photoPost in repo.getConnectedUserPosts(null))
                {
                    if (photoPost != null)
                    {
                        if (photoPost.getPostId().Equals(guids[rnd]))
                        {
                            newHighlightCover =photoPost.getPhoto();
                            continue;
                        }
                    }
                }
            }
            foreach (Guid postId in guids)
            {
               // casualProfileService.GetSnapshotsService().getSnapshotsRepo().getHighlightsRepo().addPostToHighlight(postId, h.getHighlightId());
            }
           
            this.Close();

        }
    }
}
