namespace Sln.Shared.Contract.Models;

public class BaseRealtimeHubModel
{
    public string? ParentKey { get; set; }
    public string? Key { get; set; } = string.Empty;
    public object? Data { get; set; }
    public string? ChangeType { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 1000;
    public bool OnlyWatchForDataChange { get; set; } = false;

    public string GetGroupName(bool isParent = false) => $"GROUP:{(isParent ? (ParentKey ?? "") : GetKey())}";
    private string GetKey() => $"{Key}";
}