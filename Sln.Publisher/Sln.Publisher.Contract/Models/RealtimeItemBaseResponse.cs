namespace Sln.Publisher.Contract.Models;

public class RealtimeItemBaseResponse
{
    public required string Key { get; set; }
    public string? ParentKey { get; set; }
    public object? Data { get; set; }
    public string? ChangeType { get; set; }
}