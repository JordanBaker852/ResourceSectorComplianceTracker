using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Events
{
    public class WorkerCreatedEvent(Worker worker) : BaseEvent
    {
        public Worker Worker { get; } = worker;
    }
}