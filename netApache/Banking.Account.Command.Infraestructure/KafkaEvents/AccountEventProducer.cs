using Banking.Account.Command.Application.Models;
using Banking.Cqrs.Core.Event;
using Banking.Cqrs.Core.Producer;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Banking.Account.Command.Infraestructure.KafkaEvents
{
    public class AccountEventProducer : EventProducer
    {
        public KafkaSettings _KafkaSettings;

        public AccountEventProducer(IOptions<KafkaSettings> kafkaSettings)
        {
            _KafkaSettings = kafkaSettings.Value;
        }

        public void Produce(string topic, BaseEvent @event)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = $"{_KafkaSettings.Hostname}:{_KafkaSettings.Port}"
            };

            using (var producer = new ProducerBuilder<Null,string>(config).Build()) 
            {
                var classEvent = @event.GetType;
                string value = JsonConvert.SerializeObject(@event);
                var message = new Confluent.Kafka.Message<Null, string> { Value = value };
                producer.ProduceAsync(topic, message).GetAwaiter().GetResult();
            }
        }
    }
}
