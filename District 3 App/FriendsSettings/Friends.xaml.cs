using District_3_App.ProfileSocialNetworkInfoStuff.entities;
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

namespace District_3_App.FriendsSettings
{
    /// <summary>
    /// Interaction logic for Friends.xaml
    /// </summary>
    public partial class Friends : UserControl
    {
        // Getting mock lists
        private static Dictionary<string, User> getContacts()
        {
            var contacts = new Dictionary<string, User>();

            // Create User objects with usernames and add them to the dictionary
            contacts["0752111222"] = new User("@patri.stoica", "0752111222");
            contacts["0743111222"] = new User("@delia.gherasim", "0743111222");

            return contacts;
        }

        private static Dictionary<string, User> getViewers()
        {
            var contacts = new Dictionary<string, User>();

            // Create User objects with usernames and add them to the dictionary
            contacts["0752111222"] = new User("@patri.stoica", "0752111222");
            contacts["0743111222"] = new User("@delia.gherasim", "0743111222");
            contacts["0755111222"] = new User("@anita.gorog", "0755111222");

            return contacts;
        }

        private static Dictionary<string, User> getFriends()
        {
            return new Dictionary<string, User> { };
        }

        private Dictionary<string, User> syncContacts = getContacts();

        private Dictionary<string, User> usernames_viewers = getViewers();

        private Dictionary<string, User> friends = getFriends();
        public Friends()
        {
            InitializeComponent();
        }

        private void LoadUsernamesContacts_Click(object sender, RoutedEventArgs e)
        {
            usernamesContactsComboBox.Items.Clear();

            foreach (User user in syncContacts.Values)
            {
                usernamesContactsComboBox.Items.Add(user.username);
            }
        }

        private void LoadUsernamesViewers_Click(object sender, RoutedEventArgs e)
        {
            usernamesViewersComboBox.Items.Clear();

            foreach (User user in usernames_viewers.Values)
            {
                usernamesViewersComboBox.Items.Add(user.username);
            }
        }

        private bool addSyncContact(User contactToAdd, string key)
        {
            if (friends.ContainsKey(key))
            {
                Console.WriteLine("User already added.");
                return false;
            }
            else
            {
                friends[key] = contactToAdd;

                Console.WriteLine($"User added: {contactToAdd.username}");
            }
            return true;
        }

        private bool removeSyncContact(string key)
        {
            friends.Remove(key);
            return true;
        }

        private void ItemButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Grid grid = (Grid)VisualTreeHelper.GetParent(clickedButton);
            TextBlock textBlock = (TextBlock)grid.Children[0];
            string username = textBlock.Text;
            bool added = false;
            foreach (User user in syncContacts.Values)
            {
                if (user.username == username)
                {
                    string phoneNumber = user.phoneNumber;
                    added = addSyncContact(user, phoneNumber);
                    if (added)
                    {
                        MessageBox.Show($"Username added to friends: {username}");
                    }
                    else
                    {
                        removeSyncContact(user.phoneNumber);
                        MessageBox.Show($"Username removed from friends: {username}");
                    }
                }
            }


            //friends.Add(username);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (User friend in friends.Values)
            {
                stringBuilder.AppendLine(friend.username + ',' + friend.phoneNumber);
            }
            string friendsList = stringBuilder.ToString();
            MessageBox.Show("Friends List:\n\n" + friendsList);
        }

    }
}
