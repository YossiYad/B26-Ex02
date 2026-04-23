using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class GhostFriendFilter : FriendFilterBase
    {
        public override string FilterName
        {
            get
            {
                return "Ghost Friends";
            }
        }

        public override List<string> ApplyFilter(User i_LoggedInUser)
        {
            List<string> ghostFriendsNames = new List<string>();
            FriendsAnalyzer analyzer = new FriendsAnalyzer(i_LoggedInUser);

            analyzer.AnalyzeInteractions();

            if (analyzer.UsingDummyData && !analyzer.HasRealFriends)
            {
                List<DummyFriend> dummyGhost = analyzer.GetDummyGhostFriends();
                foreach (DummyFriend friend in dummyGhost)
                {
                    ghostFriendsNames.Add(friend.Name);
                }
            }
            else
            {
                List<User> ghostFriends = analyzer.GetGhostFriends();
                foreach (User friend in ghostFriends)
                {
                    ghostFriendsNames.Add(friend.Name);
                }
            }

            return ghostFriendsNames;
        }
    }
}