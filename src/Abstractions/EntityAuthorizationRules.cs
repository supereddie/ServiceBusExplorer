using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace Abstractions;

public class EntityAuthorizationRules : Collection<EntityAuthorizationRule>
{
    public void AddAllowRule(string issuerName, string claimType, string claimValue, IEnumerable<EntityAccessRights> rights)
    {
        Add(new EntityAuthorizationRule
        {
            IssuerName = issuerName,
            ClaimType = claimType,
            ClaimValue = claimValue.ToLowerInvariant(),
            Rights = rights,
            KeyName = claimValue.ToLowerInvariant(),
        });
    }

    public void AddSharedAccessRule(string keyName, string primaryKey, string secondaryKey, IEnumerable<EntityAccessRights> rights)
    {
        if (string.IsNullOrWhiteSpace(primaryKey))
        {
            primaryKey = GenerateRandomKey();
        }

        if (string.IsNullOrWhiteSpace(secondaryKey))
        {
            secondaryKey = GenerateRandomKey();
        }

        Add(new EntitySharedAccessAuthorizationRule
        {
            ClaimType = "SharedAccessKey",
            ClaimValue = "None",
            Rights = rights,
            KeyName = keyName,
            PrimaryKey = primaryKey,
            SecondaryKey = secondaryKey
        });
    }

    private static string GenerateRandomKey()
    {
        byte[] array = new byte[32];
        using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
        {
            rNGCryptoServiceProvider.GetBytes(array);
        }

        return Convert.ToBase64String(array);
    }

}
