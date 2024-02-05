namespace Banking.Cqrs.Core.Message
{
    public abstract class Message
    {
        public string Id { set; get; } = string.Empty;

        public Message(string id) 
        {
            Id = id;
        }
    }
}
