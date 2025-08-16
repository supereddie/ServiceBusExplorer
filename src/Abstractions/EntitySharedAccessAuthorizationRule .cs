namespace Abstractions;

public class EntitySharedAccessAuthorizationRule : EntityAuthorizationRule
{
    public string PrimaryKey { get; set; }

    public string SecondaryKey { get; set; }

}
