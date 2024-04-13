using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using System.IO.Packaging;
using District_3_App.ExtraInfo;
using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System.Windows.Shapes;

namespace District_3_App.Repository
{
    internal class HighlightsRepo
    {
        private List<Highlight> highlights;

        public List<MockPhotoPost> getConnectedUserPosts(Object user)
        {
            List<MockPhotoPost> posts = new List<MockPhotoPost>();
            string path1 = "/Images/snow.jpg";
            string path2 = "/Images/peeta.jpeg";
            string path3 = "/Images/katniss.jpg";
            string path4 = "/Images/poster.jpeg";

            MockPhotoPost post1 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", path1);
            MockPhotoPost post2 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", path2);
            MockPhotoPost post3 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", path3);
            MockPhotoPost post4 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 4", "Description 4", path4);

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);

            return posts;

        }
        public HighlightsRepo()
        {
            this.highlights = new List<Highlight>();
            
            string bee1Path = "/Images/bee1.jpg";
            string bee2Path = "/Images/bee2.jpg";
            string bee3Path = "/Images/bee3.jpg";
            string path1 = "/Images/snow.jpg";
            string path2 = "/Images/peeta.jpeg";
            string path3 = "/Images/katniss.jpg";
            string path4 = "/Images/poster.jpeg";

            MockPhotoPost post1 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", path1);
            MockPhotoPost post2 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", path2);
            MockPhotoPost post3 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", path3);
            MockPhotoPost post4 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 4", "Description 4", path4);


            var highlight1 = new Highlight("Highlight 1", bee1Path);
            var highlight2 = new Highlight("Highlight 2", bee2Path);
            var highlight3 = new Highlight("Highlight 1", bee3Path);

            highlight1.addPostToHighlight(post1.getPostId());
            highlight2.addPostToHighlight(post1.getPostId());
            highlight2.addPostToHighlight(post2.getPostId());
            highlight3.addPostToHighlight(post1.getPostId());
            highlight3.addPostToHighlight(post2.getPostId());
            highlight3.addPostToHighlight(post3.getPostId());


            highlights.Add(highlight1);
            highlights.Add(highlight2);
            highlights.Add(highlight3);
           
        }
        public bool addHighlight(Highlight highlight)
        {
            this.highlights.Add(highlight);
            return true;
        }
        public bool removeHighlight(Highlight highlight)
        {
            this.highlights.Remove(highlight);
            return true;
        }
        public bool addPostToHighlight(Guid postId, Guid highlightId)
        {
            foreach (var highlight in this.highlights)
            {
                if (highlight.getHighlightId().Equals(highlightId))
                {
                    highlight.addPostToHighlight(postId);
                    return true;
                }
            }
            return false;
        }
        public bool removePostFromHighlight(Guid postId, Guid highlightId)
        {
            foreach (var highlight in this.highlights)
            {
                if (highlight.getHighlightId().Equals(highlightId))
                {
                    highlight.removePostFromHighlight(postId);
                    return true;
                }
            }
            return false;
        }
        public List<Highlight> getHighlights() { return this.highlights; }
        public Highlight getHighlight(Guid highlightId)
        {
            foreach (var highlight in this.highlights)
            {
                if (highlight.getHighlightId().Equals(highlightId))
                {
                    return highlight;
                }
            }
            return null;
        }

        public List<MockPhotoPost> getPostsOfHighlight(Guid highlightId)
        {
            //List<Guid> posts = new List<Guid>();
            //foreach (var highlight in this.highlights)
            //{
            //    if (highlight.getHighlightId().Equals(highlightId))
            //    {
            //        posts = highlight.getPosts();
            //        continue;
            //    }
            //}
            //List<MockPhotoPost> mockPhotoPosts = new List<MockPhotoPost>();
            //foreach(Guid guid in posts)
            //{
            //    mockPhotoPosts.Add(GetUserPosts(guid));
            //}
            List<MockPhotoPost> posts = new List<MockPhotoPost>();

            string path1 = "/Images/snow.jpg";
            string path2 = "/Images/peeta.jpeg";
            string path3 = "/Images/katniss.jpg";
            string path4 = "/Images/poster.jpeg";

            MockPhotoPost post1 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", path1);
            MockPhotoPost post2 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", path2);
            MockPhotoPost post3 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", path3);
            MockPhotoPost post4 = new MockPhotoPost(new User(), new Dictionary<int, List<object>>(), new List<object>(), "Title 4", "Description 4", path4);

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            return posts;
        }
    }
}
