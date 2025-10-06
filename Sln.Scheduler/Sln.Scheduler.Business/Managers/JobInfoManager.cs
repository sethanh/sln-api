
using Sln.Scheduler.Data;
using Sln.Scheduler.Data.Abstractions;
using Sln.Scheduler.Data.Entities;

namespace Sln.Scheduler.Business.Managers;

public class JobInfoManager(ISchedulerRepository<JobInfo> jobInfoRepository) 
    : SchedulerDomainService<JobInfo>((Shared.Data.Interfaces.IRepository<JobInfo>)jobInfoRepository);
