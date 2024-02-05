using Banking.Cqrs.Core.Event;

namespace Banking.Cqrs.Core.Domain
{
    public abstract class AggregateRoot
    {
        public string Id { get; set; } = string.Empty;
        private int Version = -1;
        List<BaseEvent> changes = new List<BaseEvent>();

        public int GetVersion() 
        {
            return Version;
        }

        public void SetVersion(int version)
        {
            Version = version;
        }

        public List<BaseEvent> GeUncommmitedChange() 
        {
            return changes;
        }

        public void MarkChangeAsCommited()
        {
            changes.Clear();
        }

        public void ApplyChange(BaseEvent @event, bool isNewEvent)
        {
            try
            {
                var ClaseDeEvento = @event.GetType();
                var method = GetType().GetMethod("Apply", new[] { ClaseDeEvento });
                method.Invoke(this, new[] { @event });
            }catch (Exception ex)
            {

            }
            finally
            {
                if (isNewEvent)
                {
                    changes.Add(@event);
                }
            }
        }

        public void RaiseEvent(BaseEvent @event)
        {
            ApplyChange(@event, true);
        }

        public void ReplayEvents(IEnumerable<BaseEvent> events)
        {
            foreach (var even in events)
            {
                ApplyChange(even, false);
            }
        }
    }
}
