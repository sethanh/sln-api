using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class FrequencyTaskManager(IRepository<FrequencyTask> repository) 
    : ManagementDomainService<FrequencyTask>(repository);
