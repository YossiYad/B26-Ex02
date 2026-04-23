using System.ComponentModel;

namespace BasicFacebookFeatures
{
    public class AppActivityLogger
    {
        private static readonly AppActivityLogger sr_Instance = new AppActivityLogger();
        private readonly BindingList<LogEntry> r_LogEntries;

        private AppActivityLogger()
        {
            r_LogEntries = new BindingList<LogEntry>();
        }

        public static AppActivityLogger Instance
        {
            get
            {
                return sr_Instance;
            }
        }

        public BindingList<LogEntry> LogEntries
        {
            get
            {
                return r_LogEntries;
            }
        }

        public void Log(eActionType i_ActionType, string i_Description)
        {
            r_LogEntries.Add(new LogEntry(i_ActionType, i_Description));
        }

        public void Clear()
        {
            r_LogEntries.Clear();
        }
    }
}