using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.FinancialManagements;

public class FinancialEpicManager(IRepository<FinancialEpic> repository) 
    : ManagementDomainService<FinancialEpic>(repository);
