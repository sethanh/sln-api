using Sln.Payment.Contract.Errors.CardHolders;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.CardHolders;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Payment.Business.Services.CardHolders;

public class SocialContactService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private SocialContactManager SocialContactManager => GetService<SocialContactManager>();

    public Task<SocialContactGetAllResponse> GetAll(SocialContactGetAllRequest request)
    {
        var SocialContact = SocialContactManager.GetAll();

        var paginationResponse = PaginationResponse<SocialContact>.Create(
            SocialContact,
            request
        );

        return Task.FromResult(Mapper.Map<SocialContactGetAllResponse>(paginationResponse));
    }

    public Task<SocialContactGetDetailResponse> GetDetail(SocialContactGetDetailRequest request)
    {
        var socialContact = SocialContactManager.FirstOrDefault(o => o.Id == request.Id);

        if (socialContact == null)
        {
            throw new HttpNotFound(SocialContactErrors.SOCIAL_CONTACT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<SocialContactGetDetailResponse>(socialContact));
    }

    public async Task<SocialContactCreateResponse> Create(SocialContactCreateRequest request)
    {
        var socialContact = Mapper.Map<SocialContact>(request);

        SocialContactManager.Add(socialContact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SocialContactCreateResponse>(socialContact);
    }

    public async Task<SocialContactUpdateResponse> Update(SocialContactUpdateRequest request)
    {
        var socialContact = SocialContactManager.FirstOrDefault(o => o.Id == request.Id);

        if (socialContact == null)
        {
            throw new HttpBadRequest(SocialContactErrors.SOCIAL_CONTACT_NOT_FOUND);
        }

        // TODO: Update socialContact properties

        var updatedSocialContact = SocialContactManager.Update(socialContact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SocialContactUpdateResponse>(updatedSocialContact);
    }

    public async Task Delete(SocialContactDeleteRequest request)
    {
        var socialContact = SocialContactManager.FirstOrDefault(o => o.Id == request.Id);

        if (socialContact == null)
        {
            throw new HttpNotFound(SocialContactErrors.SOCIAL_CONTACT_NOT_FOUND);
        }

        SocialContactManager.Delete(socialContact);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
