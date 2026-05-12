using System.Collections;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class ActiveFriendFilter : FriendFilterBase
    {
        private const int k_TopFriendsCount = 10;

        public override string FilterName
        {
            get
            {
                return "Active Friends";
            }
        }

        public override List<string> ApplyFilter(User i_LoggedInUser)
        {
            List<string> activeFriendsNames = new List<string>();
            IFriendsAnalyzer analyzer = new FriendsAnalyzerProxy(i_LoggedInUser);

            analyzer.AnalyzeInteractions();

            IEnumerable activeFriends = analyzer.GetActiveFriends(k_TopFriendsCount);

            foreach (object friend in activeFriends)
            {
                if (friend is User user)
                {
                    activeFriendsNames.Add(user.Name);
                }
                else
                {
                    if (friend is DummyFriend dummy)
                    {
                        activeFriendsNames.Add(dummy.Name);
                    }
                }
            }

            return activeFriendsNames;
        }
    }
}
