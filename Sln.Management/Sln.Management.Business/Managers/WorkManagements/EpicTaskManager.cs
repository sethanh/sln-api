using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class EpicTaskManager(IRepository<EpicTask> repository) 
    : ManagementDomainService<EpicTask>(repository);
