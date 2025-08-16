using System.Linq;
using Abstractions;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusExplorer.WindowsAzure;

/// <summary>
/// Extension methods for converting to and from the WindowsAzure SDK types.
/// </summary>
public static class QueueInfoExtensions
{
    public static QueueDescription ToWindowsAzure(this QueueInfo queueInfo)
    {
        QueueDescription description = new QueueDescription(queueInfo.Path)
        {
            AutoDeleteOnIdle = queueInfo.AutoDeleteOnIdle,
            DefaultMessageTimeToLive = queueInfo.DefaultMessageTimeToLive,
            DuplicateDetectionHistoryTimeWindow = queueInfo.DuplicateDetectionHistoryTimeWindow,
            EnableBatchedOperations = queueInfo.EnableBatchedOperations,
            EnableDeadLetteringOnMessageExpiration = queueInfo.EnableDeadLetteringOnMessageExpiration,
            EnableExpress = queueInfo.EnableExpress,
            EnablePartitioning = queueInfo.EnablePartitioning,
            ForwardDeadLetteredMessagesTo = queueInfo.ForwardDeadLetteredMessagesTo,
            ForwardTo = queueInfo.ForwardTo,
            IsAnonymousAccessible = queueInfo.IsAnonymousAccessible,
            LockDuration = queueInfo.LockDuration,
            MaxDeliveryCount = queueInfo.MaxDeliveryCount,
            MaxSizeInMegabytes = queueInfo.MaxSizeInMegabytes,
            // MessageCountDetails property should not be needed here
            Path = queueInfo.Path,
            RequiresDuplicateDetection = queueInfo.RequiresDuplicateDetection,
            RequiresSession = queueInfo.RequiresSession,
            Status = queueInfo.Status.ToWindowsAzure(),
            SupportOrdering = queueInfo.SupportOrdering,
            UserMetadata = queueInfo.UserMetadata,
        };
        foreach (var rule in queueInfo.Authorization)
        {
            description.Authorization.Add(rule.ToWindowsAzure());
        }

        return description;
    }

    internal static QueueInfo ToInfo(this QueueDescription queueDescription)
    {
        QueueInfo info = new QueueInfo(queueDescription.Path)
        {
            AutoDeleteOnIdle = queueDescription.AutoDeleteOnIdle,
            DefaultMessageTimeToLive = queueDescription.DefaultMessageTimeToLive,
            DuplicateDetectionHistoryTimeWindow = queueDescription.DuplicateDetectionHistoryTimeWindow,
            EnableBatchedOperations = queueDescription.EnableBatchedOperations,
            EnableDeadLetteringOnMessageExpiration = queueDescription.EnableDeadLetteringOnMessageExpiration,
            EnableExpress = queueDescription.EnableExpress,
            EnablePartitioning = queueDescription.EnablePartitioning,
            ForwardDeadLetteredMessagesTo = queueDescription.ForwardDeadLetteredMessagesTo,
            ForwardTo = queueDescription.ForwardTo,
            IsAnonymousAccessible = queueDescription.IsAnonymousAccessible,
            IsReadOnly = queueDescription.IsReadOnly,
            LockDuration = queueDescription.LockDuration,
            MaxDeliveryCount = queueDescription.MaxDeliveryCount,
            MaxSizeInMegabytes = queueDescription.MaxSizeInMegabytes,
            MessageCountDetails = queueDescription.MessageCountDetails.ToInfo(),
            Path = queueDescription.Path,
            RequiresDuplicateDetection = queueDescription.RequiresDuplicateDetection,
            RequiresSession = queueDescription.RequiresSession,
            Status = queueDescription.Status.ToInfo(),
            SupportOrdering = queueDescription.SupportOrdering,
            UserMetadata = queueDescription.UserMetadata,
        };
        foreach (var rule in queueDescription.Authorization)
        {
            var rights = rule.Rights.Select(ToInfo);
            if (rule is SharedAccessAuthorizationRule)
            {
                SharedAccessAuthorizationRule r = rule as SharedAccessAuthorizationRule;
                info.Authorization.AddSharedAccessRule(r.KeyName, r.PrimaryKey, r.SecondaryKey, rights);
            }
            else
            {
                info.Authorization.AddAllowRule(rule.IssuerName, rule.ClaimType, rule.ClaimValue, rights);
            }
        }

        return info;
    }

    public static AuthorizationRule ToWindowsAzure(this EntityAuthorizationRule rule)
    {
        var rights = rule.Rights.Select(ToWindowsAzure);
        if (rule is EntitySharedAccessAuthorizationRule)
        {
            EntitySharedAccessAuthorizationRule r = rule as EntitySharedAccessAuthorizationRule;
            return new SharedAccessAuthorizationRule(r.KeyName, r.PrimaryKey, r.SecondaryKey, rights);
        }
        else
        {
            return new AllowRule(rule.IssuerName, rule.ClaimType, rule.ClaimValue, rights);
        }
    }

    private static EntityMessageCountDetails ToInfo(this MessageCountDetails messageCount)
    {
        return new EntityMessageCountDetails(
            messageCount.ActiveMessageCount,
            messageCount.DeadLetterMessageCount,
            messageCount.ScheduledMessageCount,
            messageCount.TransferMessageCount,
            messageCount.TransferDeadLetterMessageCount);
    }

    public static MessageCountDetails ToWindowsAzure(this EntityMessageCountDetails messageCount)
    {
        return new MessageCountDetails(
            messageCount.ActiveMessageCount,
            messageCount.DeadLetterMessageCount,
            messageCount.ScheduledMessageCount,
            messageCount.TransferMessageCount,
            messageCount.TransferDeadLetterMessageCount);
    }

    private static EntityStatus ToWindowsAzure(this BaseEntityStatus entityStatus)
    {
        switch (entityStatus)
        {
            case BaseEntityStatus.Active:
                return EntityStatus.Active;
            case BaseEntityStatus.Disabled:
                return EntityStatus.Disabled;
            case BaseEntityStatus.Restoring:
                return EntityStatus.Restoring;
            case BaseEntityStatus.SendDisabled:
                return EntityStatus.SendDisabled;
            case BaseEntityStatus.ReceiveDisabled:
                return EntityStatus.ReceiveDisabled;
            case BaseEntityStatus.Creating:
                return EntityStatus.Creating;
            case BaseEntityStatus.Deleting:
                return EntityStatus.Deleting;
            case BaseEntityStatus.Renaming:
                return EntityStatus.Renaming;
            case BaseEntityStatus.Unknown:
            default:
                return EntityStatus.Unknown;
        }
    }

    private static BaseEntityStatus ToInfo(this EntityStatus entityStatus)
    {
        switch (entityStatus)
        {
            case EntityStatus.Active:
                return BaseEntityStatus.Active;
            case EntityStatus.Disabled:
                return BaseEntityStatus.Disabled;
            case EntityStatus.Restoring:
                return BaseEntityStatus.Restoring;
            case EntityStatus.SendDisabled:
                return BaseEntityStatus.SendDisabled;
            case EntityStatus.ReceiveDisabled:
                return BaseEntityStatus.ReceiveDisabled;
            case EntityStatus.Creating:
                return BaseEntityStatus.Creating;
            case EntityStatus.Deleting:
                return BaseEntityStatus.Deleting;
            case EntityStatus.Renaming:
                return BaseEntityStatus.Renaming;
            case EntityStatus.Unknown:
            default:
                return BaseEntityStatus.Unknown;
        }
    }

    private static AccessRights ToWindowsAzure(this EntityAccessRights right)
    {
        switch (right)
        {
            case EntityAccessRights.Manage:
                return AccessRights.Manage;
            case EntityAccessRights.Send:
                return AccessRights.Send;
            case EntityAccessRights.Listen:
                return AccessRights.Listen;
            case EntityAccessRights.ManageNotificationHub:
                return AccessRights.ManageNotificationHub;
            default:
                return AccessRights.Listen;
        }
    }

    internal static EntityAccessRights ToInfo(this AccessRights right)
    {
        switch (right)
        {
            case AccessRights.Manage:
                return EntityAccessRights.Manage;
            case AccessRights.Send:
                return EntityAccessRights.Send;
            case AccessRights.Listen:
                return EntityAccessRights.Listen;
            case AccessRights.ManageNotificationHub:
                return EntityAccessRights.ManageNotificationHub;
            default:
                return EntityAccessRights.Listen;
        }
    }
}
