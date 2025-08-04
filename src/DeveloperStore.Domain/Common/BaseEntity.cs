
using DeveloperStore.Common.Validation;
using Validator = DeveloperStore.Common.Validation.Validator;

namespace DeveloperStore.Domain.Common
{
    public class BaseEntity 
    {
        public int Id { get; protected set; }

        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}