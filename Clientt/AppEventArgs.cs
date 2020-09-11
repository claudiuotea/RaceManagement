using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public enum AppEvent
    {
        ParticipantAdded
    };
    public class AppEventArgs : EventArgs
    {
        private readonly AppEvent appEvent;
        private readonly Object data;

        public AppEventArgs(AppEvent appEvent, object data)
        {
            this.appEvent = appEvent;
            this.data = data;
        }

        public AppEvent EventType
        {
            get { return appEvent; }
        }

        public Object Data
        {
            get { return data; }
        }
    }
}
