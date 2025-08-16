using System;

namespace Abstractions;

public class QueueInfo
{
    public QueueInfo()
    {
    }

    public QueueInfo(string path)
    {
        Path = path;
    }

    public bool IsReadOnly { get; set; }

    public TimeSpan LockDuration{ get; set; }

    public long MaxSizeInMegabytes{ get; set; }

    public bool RequiresDuplicateDetection{ get; set; }

    public bool RequiresSession{ get; set; }

    public TimeSpan DefaultMessageTimeToLive{ get; set; }

    public TimeSpan AutoDeleteOnIdle{ get; set; }

    public bool EnableDeadLetteringOnMessageExpiration{ get; set; }

    // New Azure SDK property
    public bool DeadLetteringOnMessageExpiration { get; set; }

    public TimeSpan DuplicateDetectionHistoryTimeWindow { get; set; }

    public string Path { get; set; }

    // New Azure SDK property
    public string Name => Path;

    public int MaxDeliveryCount { get; set; }

    public bool EnableBatchedOperations { get; set; }

    public long SizeInBytes { get; }

    public long MessageCount { get; }

    public EntityMessageCountDetails MessageCountDetails { get; set; } = new EntityMessageCountDetails();

    public EntityAuthorizationRules Authorization { get; } = new EntityAuthorizationRules();

    // New Azure SDK property: public AuthorizationRules AuthorizationRules {get; }

    public bool IsAnonymousAccessible { get; set; }

    public bool SupportOrdering { get; set; }

    public BaseEntityStatus Status { get; set; }

    public string ForwardTo { get; set; }

    public string ForwardDeadLetteredMessagesTo { get; set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    public DateTime AccessedAt { get; }

    public bool EnablePartitioning { get; set; }

    public string UserMetadata { get; set; }

    public bool EnableExpress { get; set; }

}
