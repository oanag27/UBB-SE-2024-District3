using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using District_3_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace District_3_App.Service
{
    internal class SnapshotsService
    {
        private SnapshotsRepo snapshotsRepo;
        public SnapshotsService(SnapshotsRepo snapshotsRepo) {
            this.snapshotsRepo = snapshotsRepo;
        }

        public bool addHighlight(string newHighlightName, string newHighlightCover, List<Guid> guids)
        {
            HighlightsRepo repo = snapshotsRepo.GetHighlightsRepo();
            // aici ar trebui apelat din post repository

            Highlight h = new Highlight(newHighlightName, newHighlightCover);
           
            if (newHighlightName == null)
            {
                newHighlightName = "Highlight_" + h.getHighlightId().ToString().Replace("-", "_");
                h.setName(newHighlightName);
            }

            int rnd = new Random().Next(0, guids.Count());
            if (guids.Count == 0)
            {
                newHighlightCover = "../Images/black.png";
            }
            while (newHighlightCover == null)
            {
                foreach (MockPhotoPost photoPost in repo.GetConnectedUserPosts(new Guid("11111111-1111-1111-1111-111111111111")))
                {
                    if (photoPost != null)
                    {
                        if (photoPost.getPostId().Equals(guids[rnd]))
                        {
                            newHighlightCover = photoPost.getPhoto();
                            continue;
                        }
                    }
                }
            }
            snapshotsRepo.addHighlight(h);

            foreach (Guid postId in guids)
            {
                repo.AddPostToHighlight(postId, h.getHighlightId());
            }
            return true;
        }
        public bool removeHighlight(Highlight highlight)
        {
            return snapshotsRepo.removeHighlight(highlight);
        }
        public bool addPostToHighlight(Guid highlightId, Guid postId)
        {
            return snapshotsRepo.addPostToHighlight(postId, highlightId);
        }
        public bool removePostFromHighlight(Guid highlightId, Guid postId)
        {
            return snapshotsRepo.removePostFromHighlight(postId, highlightId);
        }
        public List<Highlight> getHighlightsOfUser(Guid guid)
        {
            return snapshotsRepo.GetHighlightsOfUser();
        }
        public Highlight GetHighlight(Guid highlightId)
        {
            return snapshotsRepo.GetHighlight(highlightId);
        }
    }
}
