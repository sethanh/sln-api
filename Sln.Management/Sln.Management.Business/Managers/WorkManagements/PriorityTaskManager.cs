using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class PriorityTaskManager(IRepository<PriorityTask> repository) 
    : ManagementDomainService<PriorityTask>(repository);
