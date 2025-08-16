namespace Abstractions;

public class EntityMessageCountDetails
{
    public EntityMessageCountDetails() : this(0L, 0L, 0L, 0L, 0L)
    {
    }

    public EntityMessageCountDetails(long activeMessageCount, long deadLetterMessageCount, long scheduledMessageCount, long transferMessageCount, long transferDeadLetterMessageCount)
    {
        this.ActiveMessageCount = activeMessageCount;
        this.DeadLetterMessageCount = deadLetterMessageCount;
        this.ScheduledMessageCount = scheduledMessageCount;
        this.TransferMessageCount = transferMessageCount;
        this.TransferDeadLetterMessageCount = transferDeadLetterMessageCount;
    }

    public long ActiveMessageCount { get; }
    
    public long DeadLetterMessageCount { get; }
    
    public long ScheduledMessageCount { get; }
        
    public long TransferMessageCount { get; }
    
    public long TransferDeadLetterMessageCount { get; }
}
