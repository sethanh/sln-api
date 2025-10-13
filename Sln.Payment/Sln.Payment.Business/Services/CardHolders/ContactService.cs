using Sln.Payment.Contract.Errors.CardHolders;
using Sln.Payment.Contract.Requests.CardHolders;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.CardHolders;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace Sln.Payment.Business.Services.CardHolders;

public class ContactService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ContactManager ContactManager => GetService<ContactManager>();

    public Task<ContactGetAllResponse> GetAll(ContactGetAllRequest request)
    {
        var ContactQuery = ContactManager.GetAll()
            .Include(c => c.Photo)
            .Include(c => c.SocialContacts)
            .Where(c => c.CreatedId == CurrentAccount.Id);

        var paginationResponse = PaginationResponse<Contact>.Create(
            ContactQuery,
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

        if (string.IsNullOrEmpty(request.ProfileName))
        {
            contact.ProfileName = Guid.NewGuid().ToString();
        }

        ContactManager.Add(contact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ContactCreateResponse>(contact);
    }

    public async Task<ContactUpdateResponse> Update(ContactUpdateRequest request)
    {
        var contact = ContactManager.FirstOrDefault(o => o.Id == request.Id);
        
        if (string.IsNullOrEmpty(request.ProfileName))
        {
            contact.ProfileName = Guid.NewGuid().ToString();
        }

        if (contact == null)
        {
            throw new HttpBadRequest(ContactErrors.CONTACT_NOT_FOUND);
        }

        // TODO: Update contact properties
        var updateContact = request.Adapt(contact);

        ContactManager.Update(updateContact);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ContactUpdateResponse>(updateContact);
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

    public Task<ContactGetDetailResponse> GetByProfileName(ContactGetByProfileNameRequest request)
    {
        var contact = ContactManager
            .GetAll()
            .Include(c => c.Photo)
            .Include(c => c.SocialContacts)
            .FirstOrDefault(o => o.ProfileName == request.ProfileName);

        if (contact == null)
        {
            throw new HttpNotFound(ContactErrors.CONTACT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ContactGetDetailResponse>(contact));
    }
}
