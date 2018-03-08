namespace Exp.Domain.Core.Notifications
{
    public class Message
    {
        public string Type { get; private set; }
        public string Value { get; private set; }

        public Message(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
