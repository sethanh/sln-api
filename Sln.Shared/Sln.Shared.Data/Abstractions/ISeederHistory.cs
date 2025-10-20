using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Abstractions
{
    public interface ISeederHistory<TID>: IDataModel<TID> where TID : struct
    {
        public string SeederName { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}