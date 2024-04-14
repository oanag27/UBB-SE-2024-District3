using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Service;
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

namespace District_3_App.Settings_Privacy_GUI
{
    /// <summary>
    /// Interaction logic for SettingsPrivacy_UserControl.xaml
    /// </summary>
    public partial class SettingsPrivacy_UserControl : UserControl
    {
        private User currentConnectedUser;
        private ProfileNetworkInfoService profileNetworkInfoService;
        public SettingsPrivacy_UserControl(User currentConnectedUser, ProfileNetworkInfoService profileNetworkInfoService)
        {
            InitializeComponent();

            this.currentConnectedUser = currentConnectedUser;
            this.profileNetworkInfoService = profileNetworkInfoService;


            PopulateGroupsForCurrentUser();
            PopulateRestrictedPostsAudienceForCurrentUser();
            PopulateRestrictedStoriesAudienceForCurrentUser();
            PopulateBlockedAccountsForCurrentUser();


            //this.profileNetworkInfoService = profileNetworkInfoService;
        }



        public void PopulateBlockedAccountsForCurrentUser()
        {
            blockedProfilesListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var blockedProfile in profile.blockedProfiles)
            {
                blockedProfilesListView.Items.Add(blockedProfile.user.username);
            }
        }

        public void PopulateRestrictedPostsAudienceForCurrentUser()
        {
            restrictedPostsAudienceListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var restrictedUser in profile.restrictedPostsAudience)
                restrictedPostsAudienceListView.Items.Add(restrictedUser.username);
        }

        public void PopulateRestrictedStoriesAudienceForCurrentUser()
        {
            restrictedStoriesAudienceListView.Items.Clear();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);


            foreach (var restrictedUser in profile.restrictedStoriesAudience)
                restrictedStoriesAudienceListView.Items.Add(restrictedUser.username);
        }


        public void PopulateGroupsForCurrentUser()
        {
            groupsListView.Items.Clear();
            //all groups for current user
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);

            //all the groups
            //List<Group> groupsRepo = profileNetworkInfoService.GetAllGroupsService();


            foreach (var group in profile.groups)
            {

                groupsListView.Items.Add(group.groupName);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }

        }

        private void leaveGroupButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedGroupName = groupsListView.SelectedItem.ToString();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);





            profileNetworkInfoService.RemoveGroupFromCurrentUser(profile, profileNetworkInfoService.GetGroupByName(selectedGroupName));

            groupsListView.Items.Clear(); //reset the list view



            foreach (var gr in profile.groups)
            {

                groupsListView.Items.Add(gr.groupName);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }



            //testSelectedItem.Text = selectedGroupName;
        }

        private void mantainGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            MantainGroups mantainGroupsUserControl = new MantainGroups(currentConnectedUser, profileNetworkInfoService);


            settingsPrivacyGrid.Children.Clear();
            settingsPrivacyGrid.Children.Add(mantainGroupsUserControl);
        }

        

        private void removeBlockedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedBlockedUsername = blockedProfilesListView.SelectedItem.ToString();
            UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(this.currentConnectedUser);



            profileNetworkInfoService.RemoveBlockedProfileFromCurrentUser(profile, profileNetworkInfoService.GetBlockedProfileByName(profile, selectedBlockedUsername));



            blockedProfilesListView.Items.Clear(); //reset the list view



            foreach (var blockedProfile in profile.blockedProfiles)
            {

                blockedProfilesListView.Items.Add(blockedProfile.user.username);
                //foreach (var groupMember in group.groupMembers)
                //{
                //    groupMembersListView.Items.Add(groupMember.username);
                //}

            }
        }

        private void addBlockedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (usernameToBlockTextBox.Text != "")
            {

                UserProfileSocialNetworkInfo profile = profileNetworkInfoService.GetProfileSocialNetworkInfoCurrentUser(currentConnectedUser);


                bool usernameExists = false;

                foreach (var user in profileNetworkInfoService.GetAllUsers())
                    if (user.username == usernameToBlockTextBox.Text)
                        usernameExists = true;

                if (!usernameExists)
                {
                    MessageBox.Show("Error: user with such username does not exist");

                }
                else
                {





                    bool alreadyExists = false;

                    foreach (var blockedProfile in profile.blockedProfiles)
                    {
                        if (blockedProfile.user.username == usernameToBlockTextBox.Text)
                            alreadyExists = true;
                    }

                    if (alreadyExists)
                    {
                        MessageBox.Show("User is already blocked by you", "Error");
                    }
                    else
                    {
                        DateTime newDate = DateTime.Now;
                        BlockedProfile profileToBlock = new BlockedProfile(profileNetworkInfoService.GetUserByName(usernameToBlockTextBox.Text), newDate);
                        profile.blockedProfiles.Add(profileToBlock);
                    }




                    blockedProfilesListView.Items.Clear();


                    foreach (var blockedProfile in profile.blockedProfiles)
                    {
                        blockedProfilesListView.Items.Add(blockedProfile.user.username);
                    }
                }

            }
        }
    }
}
