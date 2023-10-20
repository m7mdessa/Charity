using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Service
{


	public interface ICharityService
	{
		List<Charities> GetAllCharities();
        public List<Charities> GetCharityByUserId(int userId);
        public List<Charities> GetCharityByCategory(int categoryId);

        public void CreateCharity(Charitys charity);
		public void UpdateCharity(Charities charity);

		void DeleteCharity(int id);
		Charitys GetCharityById(int id);


	}


}
