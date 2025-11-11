
using Sln.Payment.Data;
using Sln.Payment.Data.Abstractions;
using Sln.Payment.Data.Entities;

namespace Sln.Payment.Business.Managers;

public class JobInfoManager(ISchedulerRepository<JobInfo> jobInfoRepository)
    : SchedulerDomainService<JobInfo>((Shared.Data.Interfaces.IRepository<JobInfo>)jobInfoRepository);
