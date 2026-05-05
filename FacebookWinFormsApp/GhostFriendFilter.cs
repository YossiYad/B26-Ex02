using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using System.Collections;

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
            IFriendsAnalyzer analyzer = new FriendsAnalyzerProxy(i_LoggedInUser);

            analyzer.AnalyzeInteractions();

            IEnumerable ghostFriends = analyzer.GetGhostFriends();

            foreach (object friend in ghostFriends)
            {
                if (friend is User user)
                {
                    ghostFriendsNames.Add(user.Name);
                }
                else if (friend is DummyFriend dummy)
                {
                    ghostFriendsNames.Add(dummy.Name);
                }
            }

            return ghostFriendsNames;
            //if (analyzer.UsingDummyData && !analyzer.HasRealFriends)
            //{
            //    List<DummyFriend> dummyGhost = analyzer.GetDummyGhostFriends();
            //    foreach (DummyFriend friend in dummyGhost)
            //    {
            //        ghostFriendsNames.Add(friend.Name);
            //    }
            //}
            //else
            //{
            //    List<User> ghostFriends = analyzer.GetGhostFriends();
            //    foreach (User friend in ghostFriends)
            //    {
            //        ghostFriendsNames.Add(friend.Name);
            //    }
            //}
        }
    }
}