using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Common
{
    public abstract class DomainEvent
    {
        public DateTime Timestamp { get; } = DateTime.UtcNow;
    }
}