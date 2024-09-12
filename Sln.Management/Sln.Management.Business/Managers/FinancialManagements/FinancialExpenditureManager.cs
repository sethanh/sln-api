using Sln.Shared.Data.Interfaces;
using Sln.Management.Data.Entities;

namespace Sln.Management.Business.Managers.FinancialManagements;

public class FinancialExpenditureManager(IRepository<FinancialExpenditure> repository) 
    : ManagementDomainService<FinancialExpenditure>(repository);
