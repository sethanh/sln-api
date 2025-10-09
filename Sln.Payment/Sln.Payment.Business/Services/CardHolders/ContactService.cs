using Sln.Payment.Contract.Errors.CardHolders;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.CardHolders;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Payment.Business.Services.CardHolders;

public class ContactService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ContactManager ContactManager => GetService<ContactManager>();

    public Task<ContactGetAllResponse> GetAll(ContactGetAllRequest request)
    {
        var Contact = ContactManager.GetAll();

        var paginationResponse = PaginationResponse<Contact>.Create(
            Contact,
            request
        );

        return Task.FromResult(Mapper.Map<ContactGetAllResponse>(paginationResponse));
    }

    public Task<ContactGetDetailResponse> GetDetail(ContactGetDetailRequest request)
    {
        var contact = ContactManager.FirstOrDefault(o => o.Id == request.Id);

        if (contact == null)
        {
            throw new HttpNotFound(ContactErrors.CONTACT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ContactGetDetailResponse>(contact));
    }

    public async Task<ContactCreateResponse> Create(ContactCreateRequest request)
    {
        var contact = Mapper.Map<Contact>(request);

        ContactManager.Add(contact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ContactCreateResponse>(contact);
    }

    public async Task<ContactUpdateResponse> Update(ContactUpdateRequest request)
    {
        var contact = ContactManager.FirstOrDefault(o => o.Id == request.Id);

        if(contact == null)
        {
            throw new HttpBadRequest(ContactErrors.CONTACT_NOT_FOUND);
        }

        // TODO: Update contact properties

        var updatedContact = ContactManager.Update(contact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ContactUpdateResponse>(updatedContact);
    }

    public async Task Delete(ContactDeleteRequest request)
    {
        var contact = ContactManager.FirstOrDefault(o => o.Id == request.Id);

        if (contact == null)
        {
            throw new HttpNotFound(ContactErrors.CONTACT_NOT_FOUND);
        }

        ContactManager.Delete(contact);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
