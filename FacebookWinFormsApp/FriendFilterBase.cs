using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public abstract class FriendFilterBase
    {
        public abstract string FilterName
        { 
            get;
        }

        public abstract List<string> ApplyFilter(User i_LoggedInUser);
    }
}
