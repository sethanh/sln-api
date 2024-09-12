using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class BoardTaskManager(IRepository<BoardTask> repository) 
    : ManagementDomainService<BoardTask>(repository);
