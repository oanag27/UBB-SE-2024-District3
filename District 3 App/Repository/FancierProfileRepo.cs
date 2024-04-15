using District_3_App.Enitities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace District_3_App.Repository
{
    public class FancierProfile
    {
        public Guid ProfileId { get; set; }
        public List<string> Links { get; set; }
        public string DailyMotto { get; set; }
        public DateTime RemoveMottoDate { get; set; }
        public int FrameNumber { get; set; }
        public string Hashtag { get; set; }
    }

    class FancierProfileRepo
    {
        private Dictionary<Guid, FancierProfile> profileRepo = new Dictionary<Guid, FancierProfile>();
        private string filePath;

        public FancierProfileRepo()
        {
            filePath = GenerateDefaultFilePath();
            Console.WriteLine(filePath);
            if (!File.Exists(filePath))
            {
                CreateXml(filePath);
            }
            Load(filePath);
        }

        private string GenerateDefaultFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FancierProfile.xml");
        }

        private void CreateXml(string filePath)
        {
            XDocument xDocument = new XDocument(new XElement("FancierProfiles"));
            xDocument.Save(filePath);
        }

        private void Load(string filePath)
        {
            Console.WriteLine("Reading profile info fancy settings from file: " + filePath);

            XDocument xDocument = XDocument.Load(filePath);
            XElement root = xDocument.Element("FancierProfiles");
            if (root != null && root.HasElements)
            {
                foreach (var userElem in root.Elements("FancierProfile"))
                {
                    Guid userId;
                    if (!Guid.TryParse((string)userElem.Attribute("ProfileId"), out userId))
                    {
                        continue;
                    }

                    foreach (var elem in userElem.Elements("Settings"))
                    {
                        FancierProfile profile = new FancierProfile();
                        try
                        {
                            profile.ProfileId = userId;
                            profile.DailyMotto = (string)elem.Attribute("DailyMotto");
                            profile.RemoveMottoDate = (DateTime)elem.Attribute("RemoveMottoDate");

                            var linksElem = elem.Element("Links");
                            if (linksElem != null)
                            {
                                profile.Links = linksElem.Elements("Link")
                                    .Select(e => e.Value)
                                    .Where(e => !string.IsNullOrEmpty(e))
                                    .ToList();
                            }

                            profile.FrameNumber = (int)elem.Attribute("FrameNumber");
                            profile.Hashtag = (string)elem.Attribute("Hashtag");

                            profileRepo.Add(userId, profile);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error parsing profile: {ex.Message}");
                        }
                    }
                }
            }
        }

        public void SaveToXml()
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
                    xDocument = new XDocument(new XElement("FancierProfiles"));
                }

                XElement root = xDocument.Element("FancierProfiles");
                root?.RemoveAll();

                foreach (var profileId in profileRepo.Keys)
                {
                    FancierProfile profile = profileRepo[profileId];

                    XElement profileElement = new XElement("FancierProfile",
                        new XAttribute("ProfileId", profile.ProfileId),
                        new XAttribute("DailyMotto", profile.DailyMotto),
                        new XAttribute("RemoveMottoDate", profile.RemoveMottoDate),
                        new XAttribute("FrameNumber", profile.FrameNumber),
                        new XAttribute("Hashtag", profile.Hashtag));

                    if (profile.Links != null && profile.Links.Any())
                    {
                        XElement linksElement = new XElement("Links");
                        foreach (var link in profile.Links)
                        {
                            linksElement.Add(new XElement("Link", link));
                        }
                        profileElement.Add(linksElement);
                    }

                    root.Add(profileElement);
                }

                xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving profiles to XML: " + ex.Message);
            }
        }

        public bool AddDailyMotto(Guid userId, string newMotto)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].DailyMotto = newMotto;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDailyMotto(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].DailyMotto = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDailyMotto(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].DailyMotto;
            }
            else
            {
                return null;
            }
        }
        public bool AddLink(Guid userId, string newLink)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].Links.Add(newLink);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteLink(Guid userId, string linkToDelete)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].Links.Remove(linkToDelete);
            }
            else
            {
                return false;
            }
        }

        public List<string> GetLinks(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].Links;
            }
            else
            {
                return null;
            }
        }

        public bool SetFrameNumber(Guid userId, int newFrameNumber)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].FrameNumber = newFrameNumber;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteFrameNumber(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].FrameNumber = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetFrameNumber(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].FrameNumber;
            }
            else
            {
                return -1;
            }
        }

        public bool SetHashtag(Guid userId, string newHashtag)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].Hashtag = newHashtag;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteHashtag(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                profileRepo[userId].Hashtag = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetHashtag(Guid userId)
        {
            if (profileRepo.ContainsKey(userId))
            {
                return profileRepo[userId].Hashtag;
            }
            else
            {
                return null;
            }

        }
    }
}

