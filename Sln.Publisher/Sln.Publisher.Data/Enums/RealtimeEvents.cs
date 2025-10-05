namespace Sln.Publisher.Data.Enums;

public enum RealtimeEvents
{
    DataFetched,
    DataModified,
    DataAdded,
    DataRemoved,
    ChildDataFetched,
    ChildDataModified,
    ChildDataAdded,
    ChildDataRemoved,
    Error
}

public enum RealtimeChangeType
{
    Added,
    Modified,
    Removed,
    UnChange
}