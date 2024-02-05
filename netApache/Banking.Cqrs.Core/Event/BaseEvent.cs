using Banking.Cqrs.Core.Message;

namespace Banking.Cqrs.Core.Event
{
    public class BaseEvent : Banking.Cqrs.Core.Message.Message
    {
        public int version { get; set; }
        public BaseEvent(string id) : base(id)
        {
            
        }
    }
}
