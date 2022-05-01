using System;

namespace TestJSON
{
    public class MessageModel
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime DateTimeSend { get; set; }
        public string Text { get; set; }

        public MessageModel(string sender, string receiver, DateTime dateTimeSend, string text)
        {
            Sender = sender;
            Receiver = receiver;
            DateTimeSend = dateTimeSend;
            Text = text;
        }
    }
}
