using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FacebookWrapper.ObjectModel;
using System.Collections;

namespace BasicFacebookFeatures
{
    public interface IFriendsAnalyzer
    {
        bool UsingDummyData { get; }
        bool HasRealFriends {  get; }
        bool IsAnalyzed {  get; }

        void ResetAnalyzer();
        void AnalyzeInteractions();

       IEnumerable GetGhostFriends();
       IEnumerable GetActiveFriends(int i_FriendsAmount);

        //List<DummyFriend> GetDummyGhostFriends();
        //List<DummyFriend> GetDummyActiveFriends(int i_FriendsAmount);
    }
}
