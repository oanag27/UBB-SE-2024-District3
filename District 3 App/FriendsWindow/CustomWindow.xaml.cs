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

namespace District_3_App.FriendsWindow
{
    /// <summary>
    /// Interaction logic for CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        // Mock friends list
        private static Dictionary<string, UserInfo> getFriends()
        {
            var contacts = new Dictionary<string, UserInfo>();

            // Create User objects with usernames and add them to the dictionary
            contacts["0752111222"] = new UserInfo("@patri.stoica", "0752111222");
            contacts["0743111222"] = new UserInfo("@delia.gherasim", "0743111222");
            contacts["0755111222"] = new UserInfo("@anita.gorog", "0755111222");

            return contacts;
        }

        // Mock posts
        private static List<Post> getPosts()
        {
            List<Post> posts = new List<Post>();
            Post post = new Post(9);
            posts.Add(post);
            return posts;
        }
        private static Dictionary<Post, List<UserInfo>> makePostDictionary()
        {
            Dictionary<Post, List<UserInfo>> posts = new Dictionary<Post, List<UserInfo>>();
            foreach (Post post in getPosts())
            {
                posts[post] = new List<UserInfo>();
            }
            return posts;
        }

        private Post getCurrentPost() { return allowedProfiles.Keys.First(); }


        private Dictionary<string, UserInfo> friends = getFriends();

        private Dictionary<Post, List<UserInfo>> allowedProfiles = makePostDictionary();

        private List<string> allowedNames = new List<string>();

        //private List<Post> listPosts = getPosts();

        private void LoadUsernames()
        {
            listBox.Items.Clear();

            foreach (UserInfo user in friends.Values)
            {
                listBox.Items.Add(user.username);
            }
        }

        public CustomWindow()
        {
            InitializeComponent();
            //listBox.ItemsSource = getUsernames();
            LoadUsernames();
        }

        private void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            string searchText = textBox.Text.ToLower();
            if (searchText != "")
            {
                List<string> filteredUsernames = friends.Values
                                                     .Where(user => user.username.ToLower().Contains(searchText))
                                                     .Select(user => user.username)
                                                     .ToList();
                listBox.Items.Clear();

                foreach (string user in filteredUsernames)
                {
                    listBox.Items.Add(user);
                }
            }
            else
            {
                LoadUsernames();
            }
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
        }

        private bool addAllowedUserToSeePost(UserInfo user, Post key)
        {
            allowedProfiles[key].Add(user);
            return true;
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            foreach (UserInfo user in friends.Values)
            {
                if (allowedNames.Contains(user.username))
                {
                    addAllowedUserToSeePost(user, getCurrentPost());
                }
            }

            MessageBox.Show("Restricted Usernames: " + string.Join(", ", allowedNames));
        }

        private void CheckedFunction(object sender, RoutedEventArgs e)
        {
            CheckBox clickedButton = (CheckBox)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[1];
            string username = textBlock.Text;
            allowedNames.Add(username);
            MessageBox.Show("Restricted: " + username);
        }

        private void UnCheckedFunction(object sender, RoutedEventArgs e)
        {
            CheckBox clickedButton = (CheckBox)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[1];
            string username = textBlock.Text;
            allowedNames.Remove(username);
            MessageBox.Show("Removed from restricted: " + username);
        }
    }
}
