using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormActivityLog : Form
    {
        public FormActivityLog()
        {
            InitializeComponent();
            listBoxLog.DataSource = AppActivityLogger.Instance.LogEntries;
            comboBoxFilter.Items.Add("All");
            
            foreach (eActionType actionType in Enum.GetValues(typeof(eActionType)))
            {
                comboBoxFilter.Items.Add(actionType);
            }

            comboBoxFilter.SelectedIndex = 0;

            AppActivityLogger.Instance.LogEntries.ListChanged += LogEntries_ListChanged;
            updateStatus();
        }

        private void LogEntries_ListChanged(object sender, ListChangedEventArgs e)
        {
            updateStatus();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            AppActivityLogger.Instance.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateStatus()
        {
            labelStatus.Text = string.Format("Status: {0} entries", AppActivityLogger.Instance.LogEntries.Count);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            updateStatus();
        }
    }
}