using Sln.Publisher.Data;
using Sln.Publisher.Data.Entities.Realtime;

namespace Sln.Publisher.Business.Managers.Realtime;

public class RealtimeItemManager(PublisherRepository<RealtimeItem> realtimeItemRepository) 
    : PublisherDomainService<RealtimeItem>(realtimeItemRepository)
    {
        
    };
