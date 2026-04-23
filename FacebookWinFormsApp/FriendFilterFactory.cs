using System;

namespace BasicFacebookFeatures
{
    public static class FriendFilterFactory
    {
        public static FriendFilterBase CreateFilter(eFriendFilterType i_FilterType)
        {
            FriendFilterBase filter;

            switch (i_FilterType)
            {
                case eFriendFilterType.All:
                    filter = new AllFriendsFilter();
                    break;

                case eFriendFilterType.Active:
                    filter = new ActiveFriendFilter();
                    break;

                case eFriendFilterType.Ghost:
                    filter = new GhostFriendFilter();
                    break;

                default:
                    throw new ArgumentException("Unknown filter type: " + i_FilterType);
            }

            return filter;
        }
    }
}