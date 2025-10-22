using Sln.Payment.Contract.Errors.Sales;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Sales;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Sales;

public class FacilityService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private FacilityManager FacilityManager => GetService<FacilityManager>();

    public Task<FacilityGetAllResponse> GetAll(FacilityGetAllRequest request)
    {
        var Facility = FacilityManager.GetAll();

        var paginationResponse = PaginationResponse<Facility>.Create(
            Facility,
            request
        );

        return Task.FromResult(Mapper.Map<FacilityGetAllResponse>(paginationResponse));
    }

    public Task<FacilityGetDetailResponse> GetDetail(FacilityGetDetailRequest request)
    {
        var facility = FacilityManager.FirstOrDefault(o => o.Id == request.Id);

        if (facility == null)
        {
            throw new HttpNotFound(FacilityErrors.FACILITY_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<FacilityGetDetailResponse>(facility));
    }

    public async Task<FacilityCreateResponse> Create(FacilityCreateRequest request)
    {
        var facility = Mapper.Map<Facility>(request);

        FacilityManager.Add(facility);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<FacilityCreateResponse>(facility);
    }

    public async Task<FacilityUpdateResponse> Update(FacilityUpdateRequest request)
    {
        var facility = FacilityManager.FirstOrDefault(o => o.Id == request.Id);

        if(facility == null)
        {
            throw new HttpBadRequest(FacilityErrors.FACILITY_NOT_FOUND);
        }

        // TODO: Update facility properties

        var updateFacility = request.Adapt(facility);

        FacilityManager.Update(updateFacility);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<FacilityUpdateResponse>(updateFacility);
    }

    public async Task Delete(FacilityDeleteRequest request)
    {
        var facility = FacilityManager.FirstOrDefault(o => o.Id == request.Id);

        if (facility == null)
        {
            throw new HttpNotFound(FacilityErrors.FACILITY_NOT_FOUND);
        }

        FacilityManager.Delete(facility);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
