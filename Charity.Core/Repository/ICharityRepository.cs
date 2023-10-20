using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Repository
{
	public interface ICharityRepository
	{
		List<Charities> GetAllCharities();
        public List<Charities> GetCharityByUserId(int userId);
        public List<Charities> GetCharityByCategory(int categoryId);

        public void CreateCharity(Charitys charity);
		void DeleteCharity(int id);
		Charitys GetCharityById(int id);
		public void UpdateCharity(Charities charity);


	}

}
