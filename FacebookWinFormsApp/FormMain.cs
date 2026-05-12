using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Collections;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser;
        private FacebookWrapper.LoginResult m_LoginResult;
        private FacebookFacade m_FacebookFacade;

        public FormMain()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (m_LoginResult == null)
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                textBoxAppID.Text,
                "email",
                "public_profile",
                "user_photos",
                "user_posts",
                "user_friends");

            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage) && m_LoginResult.LoggedInUser != null)
            {
                afterLogin();
            }
        }

        private void buttonConnectAsDesig_Click(object sender, EventArgs e)
        {
            try
            {
                m_LoginResult = FacebookService.Connect("EAAUm6cZC4eUEBQ89SIPgqvUNRPYwshVbzNFtykREi0CbEUsssHsY0ceBnLKHx9uOtmH5ClGksE6EzWZBRylGglQToWaaqV2QWsOcus79byyncz93TDesQvzX2pv2kllZA8mEg5iDMiYktoptWXySLSrS4Y2ATeDyEEFsJLZBmyshcy464jImETOhjyGYYKxJDZBWhxzRWLsRZApkMmJiEG742LGjEq486o9RgdhFrkuTLT0xup5efuMsJNL8ENsJqZC");

                afterLogin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed");
            }
        }

        private void afterLogin()
        {
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            m_FacebookFacade = new FacebookFacade(m_LoggedInUser);

            buttonLogin.Text = string.Format("Logged in as {0}", m_LoginResult.LoggedInUser.Name);
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;

            pictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            this.Text = string.Format("Logged in as {0}", m_LoggedInUser.Name);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.Image = null;
            m_FacebookFacade = null;
        }

        private void buttonFindActiveFriends_Click(object sender, EventArgs e)
        {
            if (m_FacebookFacade == null)
            {
                MessageBox.Show("Please login first");
                return;
            }

            prepareUIForAnalyzis(true);

            new System.Threading.Thread(() => { analyzeFriends(true); }).Start();
        }

        private void prepareUIForAnalyzis(bool i_IsActiveFriends)
        {
            listBoxFriends.Items.Clear();

            if (i_IsActiveFriends)
            {
                if (!m_FacebookFacade.IsAnalyzed)
                {
                    labelStatus.Text = "Status: Analyzing Facebook data...";
                    labelStatus.ForeColor = Color.AliceBlue;
                }
                else
                {
                    labelStatus.Text = "Status: Fetching data from memory...";
                    labelStatus.ForeColor = Color.Green;
                }

                buttonFindActiveFriends.Enabled = false;
            }
            else
            {
                labelStatus.Text = "Status: Searching for Ghost Friends...";
                labelStatus.ForeColor = Color.Blue;
                buttonFindGhostFriends.Enabled = false;
            }
        }

        private void buttonFindGhostFriends_Click(object sender, EventArgs e)
        {
            if (m_FacebookFacade == null)
            {
                return;
            }

            prepareUIForAnalyzis(false);

            new System.Threading.Thread(() => { analyzeFriends(false); }).Start();
        }

        private void analyzeFriends(bool i_IsActiveFriends)
        {
            try
            {
                m_FacebookFacade.AnalyzeInteractions();

                bool isDummy = m_FacebookFacade.UsingDummyData;
                IEnumerable friendsToDisplay = null;

                if (i_IsActiveFriends)
                {
                    friendsToDisplay = m_FacebookFacade.GetActiveFriends(10);

                    if (isDummy)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("The Facebook API currently restricts access to friends, likes and comments.\nDisplaying generated Dummy Data for demonstration purposes.",
                                            "API Limitation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                }
                else
                {
                    friendsToDisplay = m_FacebookFacade.GetGhostFriends();
                }

                this.Invoke(new Action(() => { displayFriendsResult(friendsToDisplay, isDummy, i_IsActiveFriends); }));
            }
            catch (Exception e)
            {
                this.Invoke(new Action(() => MessageBox.Show("An error occurred: " + e.Message)));
            }
            finally
            {
                this.Invoke(new Action(() =>
                {
                    buttonFindActiveFriends.Enabled = true;
                    buttonFindGhostFriends.Enabled = true;
                }));
            }
        }

        private void displayFriendsResult(IEnumerable i_FriendsList, bool i_IsDummy, bool i_IsActiveFriends)
        {
            if (i_IsDummy && i_IsActiveFriends)
            {
                listBoxFriends.DisplayMember = "";
            }
            else
            {
                listBoxFriends.DisplayMember = "Name";
            }

            foreach (object friend in i_FriendsList)
            {
                listBoxFriends.Items.Add(friend);
            }

            if (i_IsActiveFriends)
            {
                labelStatus.Text = i_IsDummy ? "Status: Analysis Complete (Dummy Data)" : "Status: Analysis Complete";
            }
            else
            {
                labelStatus.Text = i_IsDummy ? "Status: Found Dummy Ghost Friends" : "Status: Found Ghost Friends";
            }

            labelStatus.ForeColor = Color.Green;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (m_FacebookFacade != null)
            {
                m_FacebookFacade.ResetAnalyzer();
                listBoxFriends.Items.Clear();
                pictureBoxFriend.Image = null;

                labelStatus.Text = "Status: Waiting for scan";
                labelStatus.ForeColor = Color.Black;

                MessageBox.Show("Data reset successfully!");
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItem is User selectedFriend)
            {
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
                }
            }
            else
            {
                pictureBoxFriend.Image = null;
            }
        }

        private void buttonLoadAlbums_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            foreach (Album album in m_LoggedInUser.Albums)
            {
                listBoxAlbums.Items.Add(album);
            }
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAlbums.SelectedItem is Album selectedAlbum)
            {
                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxAlbumCover.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
                else
                {
                    pictureBoxAlbumCover.Image = null;
                }
            }
        }

        private void buttonDownloadAlbum_Click(object sender, EventArgs e)
        {
            if (listBoxAlbums.SelectedItem == null)
            {
                MessageBox.Show("Please select an album first");
                return;
            }

            Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = folderDialog.SelectedPath;
                buttonDownloadAlbum.Enabled = false;

                List<Photo> photosToDownload = new List<Photo>();

                foreach (Photo photo in selectedAlbum.Photos)
                {
                    photosToDownload.Add(photo);
                }

                new System.Threading.Thread(() => downloadPhotos(photosToDownload, destinationPath, buttonDownloadAlbum, "Album downloaded successfully")).Start();
            }
        }

        private void downloadPhotos(List<Photo> i_PhotosToDownload, string i_DestinationPath, Button i_SenderButton, string i_Message)
        {
            try
            {
                m_FacebookFacade.DownloadPhotos(i_PhotosToDownload, i_DestinationPath);

                this.Invoke(new Action(() => MessageBox.Show(i_Message)));
            }
            catch (Exception e)
            {
                this.Invoke(new Action(() => MessageBox.Show("Error: " + e.Message)));
            }
            finally
            {
                this.Invoke(new Action(() => i_SenderButton.Enabled = true));
            }
        }

        private void buttonMoveToArchive_Click(object sender, EventArgs e)
        {
            if (m_FacebookFacade == null)
            {
                return;
            }

            int yearsToArchive = (int)numericUpDownYears.Value;
            List<Photo> oldPhotos = m_FacebookFacade.GetPhotosOlderThan(yearsToArchive);

            if (oldPhotos.Count == 0)
            {
                MessageBox.Show("Did not find any photos older than " + yearsToArchive + " years.");
                return;
            }

            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = folderDialog.SelectedPath;
                buttonMoveToArchive.Enabled = false;

                string successMsg = "Finished archiving " + oldPhotos.Count + " photos!";

                new System.Threading.Thread(() => downloadPhotos(oldPhotos, destinationPath, buttonMoveToArchive, successMsg)).Start();
            }
        }

        private void buttonShowActivityLog_Click(object sender, EventArgs e)
        {
            FormActivityLog activityLogForm = new FormActivityLog();

            activityLogForm.Show();
        }

        private void buttonShowFriendFilter_Click(object sender, EventArgs e)
        {
            if (m_LoggedInUser == null)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            FormFriendFilter friendFilterForm = new FormFriendFilter(m_LoggedInUser);

            friendFilterForm.Show();
        }
    }
}
