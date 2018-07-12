using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkCommands.Data;
using VkSearch.Profiles;
using VkSearch.Profiles.Impl;
using VkCommands.Data.Impl;
using VkCommands.Helpers.Impl;
using VkAuthorization;
using VK_COM.Enums;
using System.Reflection;
using VkSearch.Events;
using VkSearch.Events.EventsImpl;
using System.Text.RegularExpressions;

namespace VkSearch.Strategy.Impl
{
    class BalancedTreesSearchStrategy : ITreeSearchStrategy
    {
        private List<VkCommands.Data.IData> searchPeople(ISearchProfile sProfile, 
            int currentDepth, ISearchSubscriber subscriber)
        { 
            List<IData> tergetUsers = new List<IData>();
            Friends friends = FriendsHelper.getFriends(CoreId);
            User user = null;
            bool isTarget = true;
                if (OnFirstStep)
                {
                    for (int i = 0; i < friends.Users.Count; i++)
                    {
                        if (isStopped)
                        {
                            return tergetUsers;
                        }

                        user = friends.Users[i];
                        isTarget = detectTargetUser(sProfile, user);
                        if (isTarget)
                        {
                            if (sProfile.CheckFriends)
                            {
                                if (!FriendsHelper.areFriends(user.Id,
                                    AuthFactory.getCurrentAuth().InitialUser).GetAreFriends)
                                {
                                    tergetUsers.Add(user);
                                    subscriber.onItemFoundEvent(new ItemUpdatedEvent(user.Id));
                                }
                            }
                            else
                            {
                                tergetUsers.Add(user);
                                subscriber.onItemFoundEvent(new ItemUpdatedEvent(user.Id));
                            }
                        }
                        if (currentDepth < Depth)
                        {
                            //if (sProfile.Criteria[NextIterationCriteria].Equals(user.NextIterationCriteria))
                            //{
                                CoreId = user.Id;
                                tergetUsers.AddRange(searchPeople(sProfile, currentDepth + 1, subscriber));
                            //}
                        }
                    }
                }
            return tergetUsers;
        }

        private bool isInInterval(string bDate, string bDateInterval)
        {
            string[] bDateArr = bDate.Split('.');
            if (bDateArr.Length != 3)
                return false;

            bDate = bDateArr[2];
            string from = bDateInterval.Split(new string[] { "---" }, StringSplitOptions.None)[0];
            string to = bDateInterval.Split(new string[] { "---" }, StringSplitOptions.None)[1];

            if (Int32.Parse(bDate) > Int32.Parse(from) &&
                Int32.Parse(bDate) < Int32.Parse(to))
                return true;
            else
                return false;
        }

        private bool detectTargetUser(ISearchProfile sProfile, User user)
        {
            object temp = null;
            string criteria = string.Empty;
            bool isTarget = true;
            foreach (KeyValuePair<string, string> entry in sProfile.Criteria)
            {
                PropertyInfo[] propertyInfos = typeof(User).GetProperties();
                for (int j = 0; j < propertyInfos.Length; j++)
                {
                    if (propertyInfos[j].Name.Equals(entry.Key))
                    {
                        temp = propertyInfos[j].GetValue(user, null);
                        if (temp == null)
                        {
                            isTarget = false;
                            break;
                        }
                        criteria = temp.ToString();
                        if (entry.Key.Equals("BDate"))
                        {
                            if (!isInInterval(criteria, entry.Value))
                            {
                                isTarget = false;
                                break;
                            }
                        }
                        else if (entry.Key.Equals("Status"))
                        {
                            string keywordsStr = Regex.Replace(entry.Value, @"\s+", "");
                            string[] keywords = null;
                            if (keywordsStr.Contains(","))
                                keywords = keywordsStr.Split(',');
                            else
                                keywords = new string[] { keywordsStr };
                            foreach (string keyword in keywords)
                            {
                                if (!criteria.Contains(keyword))
                                {
                                    isTarget = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (!criteria.Equals(entry.Value))
                            {
                                isTarget = false;
                                break;
                            }
                        }
                    }
                }
            }

            return isTarget;
        }

        private List<VkCommands.Data.IData> searchGroup(ISearchProfile sProfile, int currentDepth)
        { 
            return null;
        }

        public override List<VkCommands.Data.IData> search(ISearchProfile sProfile, ISearchSubscriber subscriber)
        {
            isStopped = false;
            subscriber.onSearchStarted();
            if (sProfile.GetType() == typeof(PeopleSearchProfile))
            {
                List<IData> data = searchPeople(sProfile, 0, subscriber);
                subscriber.onSearchFinished();
                return data;
            }
            else if (sProfile.GetType() == typeof(GroupSearchProfile))
                return searchGroup(sProfile, 0);
            else
                return null;
        }
    }
}
