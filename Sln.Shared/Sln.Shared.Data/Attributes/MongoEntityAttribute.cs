namespace Sln.Shared.Data.Attributes;

[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)]
public class MongoEntityAttribute: Attribute
{
    public MongoEntityAttribute()
    {
        
    }
}