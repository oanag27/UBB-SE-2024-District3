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
            Console.WriteLine(filePath);
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
            Console.WriteLine("Reading highlights from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);
            XElement root = xDocument.Element("Highlights");
            if (root.HasElements)
            {
                foreach (var userElem in root.Elements("User"))
                {
                    string userId = (string)userElem.Attribute("userId");
                    foreach (var highlightElem in userElem.Elements("Highlight"))
                    {
                        Highlight highlight = new Highlight();
                        highlight.setUserId(Guid.Parse(userId));
                        highlight.setGuid(Guid.Parse((string)highlightElem.Attribute("guid")));
                        highlight.setName((string)highlightElem.Attribute("name"));
                        highlight.setListPosts(highlightElem.Element("posts").Elements("post").Select(e => Guid.Parse(e.Value)).ToList());
                        highlight.setCover((string)highlightElem.Attribute("cover"));

                        if (!userHighlights.ContainsKey(userId))
                        {
                            userHighlights[userId] = new Dictionary<string, Highlight>();
                        }
                        userHighlights[userId].Add(highlight.getHighlightId().ToString(), highlight);
                    }
                }
            }
        }


        public void SaveHighlightsToXml()
        {
            try
            {
                XDocument xDocument;

                if (File.Exists(filePath))
                {
                    xDocument = XDocument.Load(filePath);
                }
                else
                {
                    xDocument = new XDocument(new XElement("Highlights"));
                }

                XElement root = xDocument.Element("Highlights");
                root?.RemoveAll();

                foreach (var userHighlight in userHighlights)
                {
                    XElement userElement = new XElement("User", new XAttribute("userId", userHighlight.Key));

                    foreach (var highlight in userHighlight.Value)
                    {
                        Highlight highlight1 = highlight.Value;
                        XElement highlightElement = new XElement("Highlight",
                            new XAttribute("userId", userHighlight.Key), // Keep the userId attribute for the User element
                            new XAttribute("guid", highlight1.getHighlightId()), // Use the highlight's guid
                            new XAttribute("name", highlight1.getName()), // Use the highlight's name
                            new XElement("posts", highlight1.getPosts().Select(p => new XElement("post", p))),
                            new XAttribute("cover", highlight1.getCover()));

                        userElement.Add(highlightElement);
                    }

                    root.Add(userElement);
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
            post1.setPostId(new Guid("11111111-1111-1111-1111-111111111111"));
            MockPhotoPost post2 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 2", "Description 2", path2);
            post2.setPostId(new Guid("22222222-2222-2222-2222-222222222222"));
            MockPhotoPost post3 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 3", "Description 3", path3);
            post3.setPostId(new Guid("33333333-3333-3333-3333-333333333333"));
            MockPhotoPost post4 = new MockPhotoPost(user, new Dictionary<int, List<object>>(), new List<object>(), "Title 4", "Description 4", path4);
            post4.setPostId(new Guid("44444444-4444-4444-4444-444444444444"));

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
                    foreach (var post in GetConnectedUserPosts(new Guid("11111111-1111-1111-1111-111111111111")))
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
