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
            return highlightsRepo.addHighlight(highlight);
        }
        public bool removeHighlight(Highlight highlight) {
            return highlightsRepo.removeHighlight(highlight);
        }
        public bool addPostToHighlight(Guid highlightId, Guid postId){
            return highlightsRepo.addPostToHighlight(postId, highlightId);
        }
        public bool removePostFromHighlight(Guid highlightId, Guid postId){
            return highlightsRepo.removePostFromHighlight(postId, highlightId); 
        }
        public HighlightsRepo GetHighlightsRepo(){
            return highlightsRepo;
        }
        public List<Highlight> GetHighlightsOfUser(){
            return highlightsRepo.getHighlights();
        }
    }
}
