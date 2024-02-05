using Banking.Account.Command.Domain.Common;
using Banking.Cqrs.Core.Event;
using MongoDB.Bson.Serialization.Attributes;

namespace Banking.Account.Command.Domain
{
    [BsonCollection("eventStore")]
    public class EventModel : Document
    {
        [BsonElement("timestamp")]
        public DateTime TimesTamp { get; set; }
        [BsonElement("aggregateIdentifier")]
        public string AggregateIdentifier { get; set; } = string.Empty;
        [BsonElement("aggregateType")]
        public string AggregateType { get; set; } = string.Empty;
        [BsonElement("version")]
        public string Version { get; set; } = string.Empty;
        [BsonElement("eventType")]
        public string EventType { get; set; } = string.Empty;

        [BsonElement("eventData")]
        public BaseEvent EventData { get; set; }
    }
}
