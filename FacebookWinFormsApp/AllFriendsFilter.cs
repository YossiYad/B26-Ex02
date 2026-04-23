using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class AllFriendsFilter : FriendFilterBase
    {
        public override string FilterName
        {
            get
            {
                return "All Friends";
            }    
        }

        public override List<string> ApplyFilter(User i_LoggedInUser)
        {
            List<string> allFriendsNames = new List<string>();

            if (i_LoggedInUser.Friends != null)
            {
                foreach (User friend in i_LoggedInUser.Friends)
                {
                    allFriendsNames.Add(friend.Name);
                }
            }

            return allFriendsNames;
        }
    }
}
