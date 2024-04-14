using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Repository
{
    internal class SnapshotsRepo
    {
        private HighlightsRepo highlightsRepo;
        public SnapshotsRepo(HighlightsRepo highlightsRepo) {
            this.highlightsRepo = highlightsRepo;
        }



        public bool addHighlight(Highlight highlight){
            return highlightsRepo.AddHighlight(new Guid("11111111-1111-1111-1111-111111111111"), highlight);
        }
        public bool removeHighlight(Highlight highlight) {
            return highlightsRepo.RemoveHighlight(new Guid("11111111-1111-1111-1111-111111111111"), highlight.getHighlightId());
        }
        public bool addPostToHighlight(Guid highlightId, Guid postId){
            return highlightsRepo.AddPostToHighlight(new Guid("11111111-1111-1111-1111-111111111111"), highlightId, postId);
        }
        public bool removePostFromHighlight(Guid highlightId, Guid postId){
            return highlightsRepo.RemovePostFromHighlight(new Guid("11111111-1111-1111-1111-111111111111"), highlightId, postId);
        }
        public HighlightsRepo GetHighlightsRepo(){
            return highlightsRepo;
        }
        public List<Highlight> GetHighlightsOfUser(){
            return highlightsRepo.GetHighlightsOfUser(new Guid("11111111-1111-1111-1111-111111111111"));
        }
        public Highlight GetHighlight(Guid highlightId)
        {
            return highlightsRepo.GetHighlight(new Guid("11111111-1111-1111-1111-111111111111"),highlightId);
        }
    }
}
