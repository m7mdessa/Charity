using Charity.Core.Data;
using Charity.Core.Repository;
using Charity.Core.Service;

namespace Charity.Infra.Service
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository ContactRepository;
		public ContactService(IContactRepository ContactRepository)
		{
			this.ContactRepository = ContactRepository;
		}
		public void DeleteContact(int id)
		{
			 ContactRepository.DeleteContact(id);
		}

		public List<CharityContact> GetAllContact()
		{
			return ContactRepository.GetAllContact();
		}

		
		public void CreateContact(CharityContact contact)
		{
			ContactRepository.CreateContact(contact);
		}
	}
}
