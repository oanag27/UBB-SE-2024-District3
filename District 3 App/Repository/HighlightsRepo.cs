using District_3_App.Enitities.Mocks;
using District_3_App.Enitities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace District_3_App.Repository
{
    internal class HighlightsRepo
    {
        private Dictionary<string, Dictionary<string, Highlight>> userHighlights = new Dictionary<string, Dictionary<string, Highlight>>();
        private string filePath;

        public HighlightsRepo()
        {
            filePath = generateDefaultFilePath();
            if (!File.Exists(filePath))
            {
                createXml(filePath);
            }
            loadHighlights(filePath);
        }

        private string generateDefaultFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Highlights.xml");
        }

        private void createXml(string filePath)
        {
            XDocument xDocument = new XDocument(new XElement("Highlights"));
            xDocument.Save(filePath);
        }

        private void loadHighlights(string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath);
            XElement root = xDocument.Element("Highlights");
            if (root.HasElements)
            {
                foreach (var elem in root.Elements("Highlight"))
                {
                    Highlight highlight = new Highlight();
                    highlight.setUserId (Guid.Parse((string)elem.Attribute("userId")));
                    highlight.setGuid( Guid.Parse((string)elem.Attribute("guid")));
                    highlight.setName ( (string)elem.Attribute("name"));
                    highlight.setListPosts( elem.Element("posts").Elements("post").Select(e => e.Value).ToList());
                    highlight.setCover( (string)elem.Attribute("cover"));

                    string userId = highlight.getUserId().ToString();
                    if (!userHighlights.ContainsKey(userId))
                    {
                        userHighlights[userId] = new Dictionary<string, Highlight>();
                    }
                    userHighlights[userId].Add(userId, highlight);
                }
            }
        }

        public void SaveHighlightsToXml()
        {
            try
            {
                XDocument xDocument = new XDocument(new XElement("Highlights"));
                XElement root = xDocument.Element("Highlights");
                root.RemoveAll();
                foreach (var userHighlight in userHighlights)
                {
                    foreach (var highlight in userHighlight.Value)
                    {
                        Highlight highlight1 = highlight.Value;
                        XElement highlightElement = new XElement("Highlight",
                            new XAttribute("userId", highlight1.getUserId()),
                            new XAttribute("guid", highlight1.getUserId()),
                            new XAttribute("name", highlight1.getUserId()),
                            new XElement("posts", highlight1.getPosts().Select(p => new XElement("post", p))),
                            new XAttribute("cover", highlight1.getCover()));

                        root.Add(highlightElement);
                    }
                }
                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving highlights to XML: " + ex.Message);
            }
        }

        public List<MockPhotoPost> GetConnectedUserPosts(object user)
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

        public bool AddHighlight(Highlight highlight)
        {
            string userId = highlight.getUserId().ToString();
            if (!userHighlights.ContainsKey(userId))
            {
                userHighlights[userId] = new Dictionary<string, Highlight>();
            }
            userHighlights[userId].Add(userId, highlight);
            SaveHighlightsToXml();
            return true;
        }

        public bool RemoveHighlight(Guid highlightId)
        {
            foreach (var userHighlight in userHighlights.Values)
            {
                if (userHighlight.ContainsKey(highlightId.ToString()))
                {
                    userHighlight.Remove(highlightId.ToString());
                    SaveHighlightsToXml();
                    return true;
                }
            }
            return false;
        }

        public bool AddPostToHighlight(Guid postId, Guid highlightId)
        {
            foreach (var userHighlight in userHighlights.Values)
            {
                if (userHighlight.ContainsKey(highlightId.ToString()))
                {
                    List<Guid> listfPosts = userHighlight[highlightId.ToString()].getPosts();
                    if (!listfPosts.Contains(postId))
                    {
                        listfPosts.Add(postId);
                        userHighlight[highlightId.ToString()].setListPosts(listfPosts);
                    }
                    SaveHighlightsToXml();
                    return true;
                }
            }
            return false;
        }

        public bool RemovePostFromHighlight(Guid postId, Guid highlightId)
        {
            foreach (var userHighlight in userHighlights.Values)
            {
                if (userHighlight.ContainsKey(highlightId.ToString()))
                {
                    List<Guid> listfPosts = userHighlight[highlightId.ToString()].getPosts();
                    if (listfPosts.Contains(postId))
                    {
                        listfPosts.Remove(postId);
                        userHighlight[highlightId.ToString()].setListPosts(listfPosts);
                    }
                    SaveHighlightsToXml();
                    return true;
                }
            }
            return false;
        }

        public List<Highlight> GetHighlights()
        {
            return userHighlights.Values.SelectMany(dict => dict.Values).ToList();
        }

        public List<Highlight> GetHighlightsOfUser(Guid userId)
        {
            if (userHighlights.ContainsKey(userId.ToString()))
            {
                return userHighlights[userId.ToString()].Values.ToList();
            }
            else
            {
                return new List<Highlight>();
            }
        }

        public Highlight GetHighlight(Guid highlightId)
        {
            foreach (var userHighlight in userHighlights.Values)
            {
                if (userHighlight.ContainsKey(highlightId.ToString()))
                {
                    return userHighlight[highlightId.ToString()];
                }
            }
            return null;
        }

        public List<MockPhotoPost> GetPostsOfHighlight(Guid highlightId)
        {
            List<MockPhotoPost> postsOfHighlight = new List<MockPhotoPost>();

            foreach (var userHighlight in userHighlights.Values)
            {
                if (userHighlight.ContainsKey(highlightId.ToString()))
                {
                    Highlight highlight = userHighlight[highlightId.ToString()];
                    foreach (var post in GetConnectedUserPosts(null))
                    {
                        if (highlight.getPosts().Contains(post.getPostId()))
                        {
                            postsOfHighlight.Add(post);
                        }
                    }
                    break;
                }
            }
            return postsOfHighlight;
        }

    }
}
