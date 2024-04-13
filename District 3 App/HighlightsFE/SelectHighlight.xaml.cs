using District_3_App.Enitities;
using District_3_App.Repository;
using District_3_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace District_3_App.HighlightsFE
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
        private List<Guid> selectedPostsGuid = new List<Guid>();
        private List<Guid> selectedHighlightsGUID = new List<Guid>();
       
        private SnapshotsService snapshotsService;

        public SelectHighlight(List<Guid> selectedPostsGuids)
        {
            this.selectedPostsGuid = selectedPostsGuids;
            HighlightsRepo highlightsRepo = new HighlightsRepo();
            SnapshotsRepo snapshotsRepo =new SnapshotsRepo(highlightsRepo);
            this.snapshotsService=new SnapshotsService(snapshotsRepo);
            InitializeComponent();
            LoadHighlights();
        }
        private void LoadHighlights()
        {
            List<Highlight> highlights=snapshotsService.getHighlightsOfUser(new Guid("11111111-1111-1111-1111-111111111111"));
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

            foreach (Guid highlightGuid in selectedHighlightsGUID)
            {
                if (highlightGuid == Guid.Empty) { continue; }
                foreach (Guid postId in selectedPostsGuid)
                {
                    snapshotsService.addPostToHighlight(highlightGuid, postId);
                }
            }
            this.Close();
        }

        private void createNewHighlightButton_Click(object sender, RoutedEventArgs e)
        {
            CreateNewHighlight createNewHighlight = new CreateNewHighlight(selectedPostsGuid);
            //navigationFrame.Navigate(createNewHighlight);
            createNewHighlight.Show();
            this.Close();
        }
    }
}

