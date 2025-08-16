using System;
using System.Collections.Generic;

namespace Abstractions;

public class EntityAuthorizationRule
{
    public string IssuerName { get; set; }

    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public IEnumerable<EntityAccessRights> Rights { get; set; }

    public string KeyName { get; set; }

    public DateTime CreatedTime { get; } = DateTime.UtcNow;

    public DateTime ModifiedTime { get; } = DateTime.UtcNow;

    public long Revision { get; set; } = 0L;
}
