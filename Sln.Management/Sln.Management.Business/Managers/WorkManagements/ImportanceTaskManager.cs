using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.WorkManagements;

public class ImportanceTaskManager(IRepository<ImportanceTask> repository) 
    : ManagementDomainService<ImportanceTask>(repository);
