using fancierProfile.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fancierProfile.Entities
{
    public class Highlight
    {
        private Guid highlightId;
        private List<Guid> postsIds;
        private string Name;
        private string coverFilePath;
      
        public Highlight(string newName, string newCover) {
            this.highlightId = Guid.NewGuid();
            this.postsIds = new List<Guid>(); 
            this.Name = newName;
            this.coverFilePath = newCover;
        }
        public Guid getHighlightId()
        {
            return highlightId;
        }
        public List<Guid> getPosts()
        {
            return postsIds;
        }
        public string getName()
        {
            return Name;
        }
        public string getCover()
        {
            return coverFilePath;
        }
        public bool addPostToHighlight(Guid postId) {
            this.postsIds.Add(postId); 
            return true; 
        }

        public bool removePostFromHighlight(Guid postId)
        {
            this.postsIds.Remove(postId);
            return true;
        }
        public void setName(string newName)
        {
            this.Name = newName;
        }
        
    }
}
