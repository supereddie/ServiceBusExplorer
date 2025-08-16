namespace Abstractions;

public enum BaseEntityStatus
{
    //
    // Summary:
    //     The status of the messaging entity is active.
    
    Active = 0,
    //
    // Summary:
    //     The status of the messaging entity is disabled.
    
    Disabled = 1,
    //
    // Summary:
    //     Resuming the previous status of the messaging entity.
    
    Restoring = 2,
    //
    // Summary:
    //     The sending status of the messaging entity is disabled.
    
    SendDisabled = 3,
    //
    // Summary:
    //     The receiving status of the messaging entity is disabled.
    
    ReceiveDisabled = 4,
    //
    // Summary:
    //     Indicates that the resource is still being created. Any creation attempt on the
    //     same resource path will result in a Microsoft.ServiceBus.Messaging.MessagingException
    //     exception (HttpCode.Conflict 409).
    
    Creating = 5,
    //
    // Summary:
    //     Indicates that the system is still attempting cleanup of the entity. Any additional
    //     deletion call will be allowed (the system will be notified). Any additional creation
    //     call on the same resource path will result in a Microsoft.ServiceBus.Messaging.MessagingException
    //     exception (HttpCode.Conflict 409).
    
    Deleting = 6,
    //
    // Summary:
    //     The messaging entity is being renamed.
    
    Renaming = 7,
    //
    // Summary:
    //     The status of the messaging entity is unknown.
    
    Unknown = 99
}
