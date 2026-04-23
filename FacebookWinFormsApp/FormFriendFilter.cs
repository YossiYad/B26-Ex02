using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormFriendFilter : Form
    {
        private readonly User r_LoggedInUser;
        private readonly FilterSettings r_FilterSettings;

        public FormFriendFilter(User i_LoggedInUser)
        {
            InitializeComponent();
            r_LoggedInUser = i_LoggedInUser;
            r_FilterSettings = new FilterSettings();

            foreach (eFriendFilterType filterType in Enum.GetValues(typeof(eFriendFilterType)))
            {
                comboBoxFilterType.Items.Add(filterType);
            }
            comboBoxFilterType.SelectedIndex = 0;

            textBoxSearchName.DataBindings.Add(
                "Text",
                r_FilterSettings,
                "SearchText",
                false,
                DataSourceUpdateMode.OnPropertyChanged);

            labelCurrentSearch.DataBindings.Add(
                "Text",
                r_FilterSettings,
                "SearchText");
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (r_LoggedInUser == null)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            eFriendFilterType selectedType = (eFriendFilterType)comboBoxFilterType.SelectedItem;
            FriendFilterBase filter = FriendFilterFactory.CreateFilter(selectedType);
            List<string> results = filter.ApplyFilter(r_LoggedInUser);

            if (!string.IsNullOrEmpty(r_FilterSettings.SearchText))
            {
                List<string> filtered = new List<string>();
                foreach (string name in results)
                {
                    if (name.ToLower().Contains(r_FilterSettings.SearchText.ToLower()))
                    {
                        filtered.Add(name);
                    }
                }
                results = filtered;
            }

            listBoxResults.Items.Clear();

            foreach (string name in results)
            {
                listBoxResults.Items.Add(name);
            }

            labelStatus.Text = string.Format("Status: {0} results", results.Count);
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            r_FilterSettings.SearchText = string.Empty;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
