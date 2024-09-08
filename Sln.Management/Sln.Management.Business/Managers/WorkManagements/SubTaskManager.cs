using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class SubTaskManager(IRepository<SubTask> repository) 
    : ManagementDomainService<SubTask>(repository);
