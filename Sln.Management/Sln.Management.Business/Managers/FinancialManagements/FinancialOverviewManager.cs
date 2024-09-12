using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.FinancialManagements;

public class FinancialOverviewManager(IRepository<FinancialOverview> repository) 
    : ManagementDomainService<FinancialOverview>(repository);
