using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using System.Collections;

namespace BasicFacebookFeatures
{
    public class FacebookFacade
    {
        private readonly User r_LoggedInUser;
        private readonly IFriendsAnalyzer r_FriendAnalyzer;
        private readonly PhotoArchiver r_PhotoArchiver;
        private readonly AppActivityLogger r_Logger;

        public FacebookFacade(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
            r_FriendAnalyzer = new FriendsAnalyzerProxy(r_LoggedInUser);
            r_PhotoArchiver = new PhotoArchiver(r_LoggedInUser);
            r_Logger = AppActivityLogger.Instance;
        }

        public bool UsingDummyData
        {
            get { return r_FriendAnalyzer.UsingDummyData; }
        }

        public bool HasRealFriends
        {
            get { return r_FriendAnalyzer.HasRealFriends; }
        }

        public bool IsAnalyzed
        {
            get { return r_FriendAnalyzer.IsAnalyzed; }
        }

        public void AnalyzeInteractions()
        {
            if( !r_FriendAnalyzer.IsAnalyzed )
            {
                r_Logger.Log(eActionType.AnalyzeFriends, "Analyzing Friends Interactions had been started.");
                r_FriendAnalyzer.AnalyzeInteractions();
            }
        }

        public IEnumerable GetActiveFriends(int i_Amount)
        {
            r_Logger.Log(eActionType.AnalyzeFriends, string.Format("Finding top {0} Friends", i_Amount));
            return r_FriendAnalyzer.GetActiveFriends(i_Amount);
        }

        public IEnumerable GetGhostFriends()
        {
            r_Logger.Log(eActionType.AnalyzeFriends, "Finding Ghost Friends");
            return r_FriendAnalyzer.GetGhostFriends();
        }

        //public List<DummyFriend> GetDummyActiveFriends(int i_Amount)
        //{
        //    r_Logger.Log(eActionType.AnalyzeFriends, string.Format("Finding top {0} Friends", i_Amount));
        //    return r_FriendAnalyzer.GetDummyActiveFriends(i_Amount);
        //}

        //public List<DummyFriend> GetDummyGhostFriends()
        //{
        //    r_Logger.Log(eActionType.AnalyzeFriends, "Finding Ghost Friends");
        //    return r_FriendAnalyzer.GetDummyGhostFriends();
        //}

        public void ResetAnalyzer()
        {
            r_Logger.Log(eActionType.AnalyzeFriends, "Reset Friend Analyzis Data.");
            r_FriendAnalyzer.ResetAnalyzer();
        }

        public List<Photo> GetPhotosOlderThan(int i_Years)
        {
            r_Logger.Log(eActionType.ArchivePhotos, string.Format( "Searching for Photo Older Than {0} years.", i_Years));
            return r_PhotoArchiver.GetPhotosOlderThan(i_Years);
        }

        public void DownloadPhotos(List<Photo> i_Photos, string i_DestinationPath)
        {
            r_Logger.Log(eActionType.DownloadAlbum, string.Format("Downloading {0} Photos to {1}", i_Photos.Count, i_DestinationPath));
            r_PhotoArchiver.DownloadPhotos(i_Photos, i_DestinationPath);
        }
    }
}
