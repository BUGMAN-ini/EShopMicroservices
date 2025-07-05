using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events
{
    public record IntegrationEvent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime OccuredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
