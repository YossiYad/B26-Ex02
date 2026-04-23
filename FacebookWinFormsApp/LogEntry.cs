using System;

namespace BasicFacebookFeatures
{
    public class LogEntry
    {
        private readonly DateTime r_Timestamp;
        private readonly eActionType r_ActionType;
        private readonly string r_Description;

        public LogEntry(eActionType i_ActionType, string i_Description)
        {
            r_Timestamp = DateTime.Now;
            r_ActionType = i_ActionType;
            r_Description = i_Description;
        }

        public DateTime Timestamp
        {
            get
            {
                return r_Timestamp;
            }
        }

        public eActionType ActionType
        {
            get
            {
                return r_ActionType;
            }
        }

        public string Description
        {
            get
            {
                return r_Description;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0:HH:mm:ss}] {1}: {2}", r_Timestamp, r_ActionType, r_Description);
        }
    }
}