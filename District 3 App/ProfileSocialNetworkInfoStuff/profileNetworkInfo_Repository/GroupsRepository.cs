using District_3_App.ProfileSocialNetworkInfoStuff.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District_3_App.ProfileSocialNetworkInfoStuff.profileNetworkInfo_Repository
{
    public class GroupsRepository
    {
        public List<Group> groupsRepository { get; set; }


        public GroupsRepository()
        {
            this.groupsRepository = new List<Group>();
        }
        public GroupsRepository(List<Group> groupsRepository)
        {
            this.groupsRepository = groupsRepository;
        }




        public List<Group> GetAllGroups()
        {
            return this.groupsRepository;
        }




        public bool AddGroup(Group groupToAdd)
        {
            foreach (var group in groupsRepository)
            {
                if (group.Id == groupToAdd.Id)
                {
                    return false;
                }
            }

            this.groupsRepository.Add(groupToAdd);
            return true;
        }


        public bool RemoveGroup(Group groupToRemove)
        {
            foreach (var group in groupsRepository)
            {
                if (group.Id == groupToRemove.Id)
                {
                    groupsRepository.Remove(group);
                    return true;
                }
            }
            return false;
        }

        public Group GetGroupByGroupName(string groupName)
        {
            foreach (var group in groupsRepository)
            {
                if (groupName == group.groupName)
                {
                    return group;

                }
            }
            return null;
        }

        public bool AddMemberToGroup(string groupName, User memberToAdd)
        {
            foreach (var group in groupsRepository)
            {
                if (group.groupName == groupName)
                {
                    foreach (var currentMember in group.groupMembers)
                        if (currentMember.username == memberToAdd.username)
                            return false;

                    group.groupMembers.Add(memberToAdd);
                    return true;
                }
            }
            return false;
        }


        public bool RemoveMemberFromGroup(string groupName, User memberToRemove)
        {
            foreach (var group in groupsRepository)
            {
                if (group.groupName == groupName)
                {
                    foreach (var currentMember in group.groupMembers)
                        if (currentMember.username == memberToRemove.username)
                        {
                            group.groupMembers.Remove(memberToRemove);
                            return true;
                        }

                    return false;
                }
            }
            return false;
        }

    }
}
