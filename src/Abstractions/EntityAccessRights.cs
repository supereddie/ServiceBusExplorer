using System.Runtime.Serialization;

namespace Abstractions;

public enum EntityAccessRights
{
    //
    // Summary:
    //     The access right is Manage.
    [EnumMember]
    Manage,
    //
    // Summary:
    //     The access right is Send.
    [EnumMember]
    Send,
    //
    // Summary:
    //     The access right is Listen.
    [EnumMember]
    Listen,

    [EnumMember]
    ManageNotificationHub
}
