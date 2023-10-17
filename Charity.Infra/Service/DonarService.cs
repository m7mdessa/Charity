using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{
	public class DonarService : IDonarService
	{
		private readonly IDonarRepository donarRepository;
		public DonarService(IDonarRepository donarRepository)
		{
			this.donarRepository = donarRepository;
		}
        public List<CharityUser> GetUserById(int id)
        {
            return donarRepository.GetUserById(id);
        }
        public void UpdateUser(CharityUser user)
		{
            donarRepository.UpdateUser(user);
		}

		public void PayForCharity(int userId, int charityId, Payment payment)
		{
            donarRepository.PayForCharity(userId, charityId, payment);
		}
		public void DonateForCharity(int userId, int charityId, Payment payment)
		{
            donarRepository.DonateForCharity(userId, charityId, payment);
		}

		public List<Donations> GetDonationByUserId(int userId)
		{
			return donarRepository.GetDonationByUserId(userId);
		}

        public List<CharityNotification> GetUserNotifications(CharityNotification notification)
        {
            return donarRepository.GetUserNotifications(notification);
        }

        public int GetNumberOfUserNotifications(CharityNotification notification)
        {
            return donarRepository.GetNumberOfUserNotifications(notification);
        }
    }

}
	


