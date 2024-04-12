using District_3_App.Enitities;
using District_3_App.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace District_3_App.HighlightsFE
{
    /// <summary>
    /// Interaction logic for HighlightsOnMain.xaml
    /// </summary>
    public partial class HighlightsOnMain : UserControl
    {
        public List<HighlightInfo> Highlights { get; set; }
        private List<Guid> selectedPostsGuid = new List<Guid>();
        private List<Guid> selectedHighlightsGUID = new List<Guid>();
        private Guid? currentlyOpenHighlightId = null;

        public HighlightsOnMain()
        {
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

        private void SelectHighlight_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = e.OriginalSource as Button;
            HighlightInfo highlightInfo = clickedButton.DataContext as HighlightInfo;
            Guid highlightId = highlightInfo.HighlightId;

            if (highlightId == currentlyOpenHighlightId)
            {
                navigationFrame.Content = null;
                currentlyOpenHighlightId = null;
            }
            else
            {
                navigationFrame.Navigate(new SeeHighlightPosts(highlightId));
                currentlyOpenHighlightId = highlightId;
            }
        }
    }
}
