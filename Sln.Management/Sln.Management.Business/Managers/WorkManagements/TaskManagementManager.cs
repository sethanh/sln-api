using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class TaskManagementManager(IRepository<TaskManagement> repository) 
    : ManagementDomainService<TaskManagement>(repository);
