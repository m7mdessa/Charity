using Charity.Core.Data;

namespace Charity.Core.Service
{
	public interface IContactService
	{
		List<CharityContact> GetAllContact();
		void DeleteContact(int id);
		void CreateContact(CharityContact contact);

	}
}
