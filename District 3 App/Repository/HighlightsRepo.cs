using District_3_App.Enitities;
using District_3_App.Enitities.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.Repository
{
    internal class HighlightsRepo
    {
        private List<Highlight> highlights;
        public List<MockPhotoPost> getConnectedUserPosts(Object user)
        {
            List<MockPhotoPost> posts = new List<MockPhotoPost>();

            MockPhotoPost post1 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", "\\images\\bee1.jpg");
            MockPhotoPost post2 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", "\\images\\bee2.jpg");
            MockPhotoPost post3 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", "\\images\\bee3.jpg");

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);

            return posts;

        }
        public HighlightsRepo()
        {
            this.highlights = new List<Highlight>();
            var post1 = new MockPhotoPost(null, null, null, "Post 1", "Description 1", "\\images\\bee1.jpg");
            var post2 = new MockPhotoPost(null, null, null, "Post 2", "Description 2", "\\images\\bee2.jpg");
            var post3 = new MockPhotoPost(null, null, null, "Post 3", "Description 3", "\\images\\bee3.jpg");

            var highlight1 = new Highlight("Highlight 1", "\\images\\bee2.jpg");
            var highlight2 = new Highlight("Highlight 2", "\\images\\bee3.jpg");
            var highlight3 = new Highlight("Highlight 1", "\\images\\bee1.jpg");
            var highlight4 = new Highlight("Highlight 2", "\\images\\bee2.jpg");

            highlight1.addPostToHighlight(post1.getPostId());
            highlight1.addPostToHighlight(post2.getPostId());
            highlight2.addPostToHighlight(post3.getPostId());
            highlight3.addPostToHighlight(post2.getPostId());
            highlight4.addPostToHighlight(post3.getPostId());


            highlights.Add(highlight1);
            highlights.Add(highlight2);
            highlights.Add(highlight3);
            highlights.Add(highlight4);
            highlights.Add(highlight3);
            highlights.Add(highlight4);
            highlights.Add(highlight3);
            highlights.Add(highlight4);
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
            MockPhotoPost post1 = new MockPhotoPost(new Object(), new Dictionary<int, List<object>>(), new List<object>(), "Title 1", "Description 1", "\\images\\bee1.jpg");
            MockPhotoPost post2 = new MockPhotoPost(new Object(), new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", "\\images\\bee2.jpg");
            MockPhotoPost post3 = new MockPhotoPost(new Object(), new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", "\\images\\bee3.jpg");

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            return posts;
        }
    }
}
