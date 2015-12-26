using System;
using MessagesClientWpfApp.Common;

namespace MessagesClientWpfApp.Model
{

    /// <summary>
    /// Used to get and set the message to send.
    /// </summary>
    public class MessageModel : BindableBase
    {

        private String _content;

        /// <summary>
        /// Get and Set the message to send.
        /// </summary>
        public String Content
        {
            get { return _content; }
            set { this.SetProperty(ref _content, value); }
        }

        private String _to;

        /// <summary>
        /// Get and Set the user/destination of the message.
        /// </summary>
        public String To
        {
            get { return _to; }
            set { this.SetProperty(ref _to, value); }
        }
    }
}
