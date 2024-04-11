using fancierProfile.Entities;
using fancierProfile.Repository;
using fancierProfile.Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace fancierProfile.HighlightsFE
{
    public class HighlightInfo
    {
        public string Name { get; set; }
        public string Cover { get; set; }
        public Guid HighlightId { get; set; }

        public HighlightInfo(string name, string cover, Guid highlightId)
        {
            Name = name;
            Cover = cover;
            HighlightId = highlightId;
        }
    }

    public partial class SelectHighlight : Window
    {
        public List<HighlightInfo> Highlights { get; set; }
        private List<Guid> selectedPostsGuid=new List<Guid>();
        private List<Guid> selectedHighlightsGUID=new List<Guid>();

        public SelectHighlight(List<Guid> selectedPostsGuids)
        {
            this.selectedPostsGuid = selectedPostsGuids;
            InitializeComponent();
            LoadHighlights();
        }

        private void LoadHighlights()
        {
            HighlightsRepo highlightsRepo = new HighlightsRepo();
            List<Highlight> highlights = highlightsRepo.getHighlights();
            if (highlights == null || highlights.Count == 0)
            {
                MessageBox.Show("No highlights found.");
            }

            Highlights = new List<HighlightInfo>();
            foreach (Highlight highlight in highlights)
            {
                Highlights.Add(new HighlightInfo(highlight.getName(), highlight.getCover(), highlight.getHighlightId()));
            }

            DataContext = Highlights;
        }
        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            HighlightInfo highlightInfo = (HighlightInfo)checkBox.DataContext;
            checkBox.Name = "CheckBox_" + highlightInfo.HighlightId.ToString().Replace("-", "_");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxName = checkBox.Name;
            if (checkBoxName.StartsWith("CheckBox_"))
            {
                string photoGuid = checkBoxName.Replace("CheckBox_", "");
                photoGuid = photoGuid.Replace("_", "-");
                if (!selectedHighlightsGUID.Contains(Guid.Parse(photoGuid)))
                {
                   selectedHighlightsGUID.Add(Guid.Parse(photoGuid));
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string checkBoxName = checkBox.Name;
            if (checkBoxName.StartsWith("CheckBox_"))
            {
                string photoGuid = checkBoxName.Replace("CheckBox_", "");
                photoGuid = photoGuid.Replace("_", "-");
                if (selectedHighlightsGUID.Contains(Guid.Parse(photoGuid)))
                {
                    selectedHighlightsGUID.Remove(Guid.Parse(photoGuid));
                }
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedHighlightsGUID.Count == 0) { return; }
            //CasualProfileService casualProfileService = new CasualProfileService();
            //foreach(Guid highlightGuid in  selectedHighlightsGUID)
            //{
            //    if (highlightGuid == Guid.Empty) { continue; }
            //    foreach (Guid postId in selectedPostsGuid)
            //    {
            //       //backend deja
            //    }
            //}
            this.Close();
        }

        private void createNewHighlightButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewHighlight createNewHighlight = new CreateNewHighlight(selectedPostsGuid);
            createNewHighlight.Show();
            this.Close();
        }
    }
}
