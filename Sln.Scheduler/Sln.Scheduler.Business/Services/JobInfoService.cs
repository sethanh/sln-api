using Sln.Payment.Business.Managers;
using Sln.Payment.Business.Requests;
using Sln.Payment.Data.Entities;
using Sln.Payment.Data.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Sln.Shared.Business;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Common.Enums.Jobs;

namespace Sln.Payment.Business.Services;

public class JobInfoService(IServiceProvider serviceProvider) : ApplicationServiceBase(serviceProvider)
{
    private readonly JobInfoManager JobInfoManager = serviceProvider.GetRequiredService<JobInfoManager>();

    public JobInfo GetJobInfo(Guid id)
    {
        var jobInfo = JobInfoManager.GetAll().FirstOrDefault(c => c.Id == id);
        if (jobInfo == null)
        {
            throw new Exception($"JobInfo with id {id} not found");
        }
        return jobInfo;
    }

    public async Task<CreateJobInfoResponse> CreateJobInfoAsync(CreateJobInfoRequest request)
    {
        var jobInfo = Mapper.Map<JobInfo>(request);

        JobInfoManager.Add(jobInfo);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<CreateJobInfoResponse>(jobInfo);
    }

    public async Task<UpdateJobInfoResponse> UpdateJobInfoAsync(Guid id, UpdateJobInfoRequest request)
    {
        var jobInfo = GetJobInfo(id);

        var jobUpdated = request.Adapt(jobInfo);
        JobInfoManager.Update(jobInfo);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<UpdateJobInfoResponse>(jobUpdated);
    }

    public async Task<JobInfo?> DeleteByJobTypeAsync(Guid? objectId, JobEvent? jobEvent)
    {
        var jobInfoQuery = JobInfoManager.GetAll()
            .Where(x => x.JobStatus != JobStatus.Deleted)
            .Where(x => x.ObjectId == objectId);
        if (jobEvent != null)
        {
            jobInfoQuery = jobInfoQuery.Where(c => c.JobEvent == jobEvent);
        }
        ;

        var jobInfo = jobInfoQuery
            .FirstOrDefault();

        if (jobInfo != null)
        {
            jobInfo.JobStatus = JobStatus.Deleted;
            JobInfoManager.Update(jobInfo);
            await UnitOfWork.SaveChangesAsync();
        }

        return jobInfo;
    }
    public async Task<List<JobInfo>> DeleteMultipleByJobTypeAsync(Guid objectId)
    {
        var jobInfos = await JobInfoManager.GetAll()
            .Where(x => x.JobStatus != JobStatus.Deleted)
            .ToListAsync();
        if (jobInfos != null)
        {
            foreach (var jobInfo in jobInfos)
            {
                jobInfo.JobStatus = JobStatus.Deleted;
            }

        }
        JobInfoManager.UpdateRange(jobInfos ?? []);
        await UnitOfWork.SaveChangesAsync();
        return jobInfos ?? [];
    }
}