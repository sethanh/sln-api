using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class SectionTaskManager(IRepository<SectionTask> repository) 
    : ManagementDomainService<SectionTask>(repository);
