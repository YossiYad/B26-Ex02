using System.Collections;

namespace BasicFacebookFeatures
{
    public interface IFriendsAnalyzer
    {
        bool UsingDummyData { get; }
        bool HasRealFriends { get; }
        bool IsAnalyzed { get; }

        void ResetAnalyzer();
        void AnalyzeInteractions();

        IEnumerable GetGhostFriends();
        IEnumerable GetActiveFriends(int i_FriendsAmount);
    }
}
