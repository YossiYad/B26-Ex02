using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FriendsAnalyzerProxy : IFriendsAnalyzer
    {
        private readonly RealFriendsAnalyzer r_RealFriendsAnalyzer;
        private bool m_UsingDummyData;
        private List<DummyFriend> m_DummyActiveFriends;
        private List<DummyFriend> m_DummyGhostFriends;

        public FriendsAnalyzerProxy(User i_LoggedInUser)
        {
            r_RealFriendsAnalyzer = new RealFriendsAnalyzer(i_LoggedInUser);
            m_UsingDummyData = false;
            m_DummyActiveFriends = new List<DummyFriend>();
            m_DummyGhostFriends = new List<DummyFriend>();
        }
        public bool UsingDummyData
        {
            get { return m_UsingDummyData; }
        }

        public bool HasRealFriends
        {
            get { return r_RealFriendsAnalyzer.HasRealFriends; }
        }

        public bool IsAnalyzed
        {
            get { return r_RealFriendsAnalyzer.IsAnalyzed || m_UsingDummyData; }
        }

        public void AnalyzeInteractions()
        {
            if (IsAnalyzed) 
                return;

            try
            {
                r_RealFriendsAnalyzer.AnalyzeInteractions();
            }
            catch (Exception)
            {
                m_UsingDummyData = true;
                generateDummyFriends(new Random());
            }
        }

        public IEnumerable GetActiveFriends(int i_FriendsAmount)
        {
            if (m_UsingDummyData)
            {
                return m_DummyActiveFriends.GetRange(0, Math.Min(i_FriendsAmount, m_DummyActiveFriends.Count));
            }

            return r_RealFriendsAnalyzer.GetActiveFriends(i_FriendsAmount);
        }

        public IEnumerable GetGhostFriends()
        {
            if (m_UsingDummyData)
            {
                return m_DummyGhostFriends;
            }

            return r_RealFriendsAnalyzer.GetGhostFriends();
        }

        public void ResetAnalyzer()
        {
            m_UsingDummyData = false;
            m_DummyGhostFriends.Clear();
            m_DummyActiveFriends.Clear();
            r_RealFriendsAnalyzer.ResetAnalyzer();
        }

        private void generateDummyFriends(Random i_Random)
        {
            string[] activeNames = new string[]
            {
                "Yael Cohen", "Omer Levi", "Noa Mizrahi", "Itai Peretz",
                "Shira Friedman", "Alon Katz", "Maya Goldberg", "Eitan Shapira",
                "Tal Avraham", "Lior Rosenberg", "Dana Ben-David", "Noam Golan",
                "Roni Schwartz", "Ori Blum", "Hila Stern", "Yonatan Klein",
                "Inbar Levy", "Ido Bar", "Tamar Wolf", "Rotem Fischer",
                "Amit Dahan", "Gal Hadid", "Yarin Azulay", "Sapir Ohana",
                "Ofir Ben-Ami", "Tomer Malka", "Noy Elbaz", "Yuval Shaked",
                "Matan Zohar", "Keren Nahmias"
            };

            string[] ghostNames = new string[]
            {
                "David Silberstein", "Rachel Gutman", "Moshe Abramov",
                "Sivan Harari", "Elad Pinto", "Michal Yosef",
                "Benny Tsarfati", "Liora Ashkenazi", "Nadav Bitton",
                "Ayelet Rosen", "Gil Hasson", "Efrat Koren"
            };

            List<KeyValuePair<string, int>> activeFriendScores = new List<KeyValuePair<string, int>>();

            foreach (string name in activeNames)
            {
                int score = i_Random.Next(5, 80);
                activeFriendScores.Add(new KeyValuePair<string, int>(name, score));
            }

            foreach (string name in ghostNames)
            {
                activeFriendScores.Add(new KeyValuePair<string, int>(name, 0));
            }

            activeFriendScores.Sort(delegate (KeyValuePair<string, int> first, KeyValuePair<string, int> second)
            {
                return second.Value.CompareTo(first.Value);
            });

            m_DummyActiveFriends.Clear();
            m_DummyGhostFriends.Clear();

            foreach (KeyValuePair<string, int> friendScore in activeFriendScores)
            {
                if (friendScore.Value == 0)
                {
                    m_DummyGhostFriends.Add(new DummyFriend(friendScore.Key, friendScore.Value));
                }
                else
                {
                    m_DummyActiveFriends.Add(new DummyFriend(friendScore.Key, friendScore.Value));
                }
            }
        }
    }
}
