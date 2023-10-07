using Charity.Core.Data;


namespace Charity.Core.Repository
{
	public interface IContactRepository
	{
		List<CharityContact> GetAllContact();
		void DeleteContact(int id);
		void CreateContact(CharityContact contact);

	}
}
