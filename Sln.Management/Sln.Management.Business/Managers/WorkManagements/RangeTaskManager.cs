using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class RangeTaskManager(IRepository<RangeTask> repository) 
    : ManagementDomainService<RangeTask>(repository);
