using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{
	public class CharityService : ICharityService
	{
		private readonly ICharityRepository charityRepository;
		public CharityService(ICharityRepository charityRepository)
		{
			this.charityRepository = charityRepository;
		}
		public void CreateCharity(Charitys charity)
		{
			charityRepository.CreateCharity(charity);
		}

		public void DeleteCharity(int id)
		{
			charityRepository.DeleteCharity(id);
		}

	

		public List<Charities> GetAllCharities()
		{
			return charityRepository.GetAllCharities();
		}
        public List<Charities> GetCharityByUserId(int userId)
        {
            return charityRepository.GetCharityByUserId(userId);
        }
        public Charitys GetCharityById(int id)
		{
			return charityRepository.GetCharityById(id);
		}

		

		public void UpdateCharity(Charities charity)
		{
			charityRepository.UpdateCharity(charity);
		}
	}
}
