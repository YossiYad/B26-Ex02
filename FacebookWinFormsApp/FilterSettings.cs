using System.ComponentModel;

namespace BasicFacebookFeatures
{
    public class FilterSettings : INotifyPropertyChanged
    {
        private string m_SearchText;

        public string SearchText
        {
            get
            {
                return m_SearchText;
            }
            set
            {
                if (m_SearchText != value)
                {
                    m_SearchText = value;
                    OnPropertyChanged("SearchText");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string i_PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(i_PropertyName));
            }
        }
    }
}