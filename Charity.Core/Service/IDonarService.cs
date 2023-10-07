using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;

namespace Charity.Core.Service
{
	public interface IDonarService
    {
		public void UpdateUser(CharityUser user);
	
		public void PayForCharity(int userId, int charityId, Payment payment);
		public void DonateForCharity(int userId, int charityId, Payment payment);
		public List<Donations> GetDonationByUserId(int userId);
        public List<CharityNotification> GetUserNotifications(CharityNotification notification);
        public int GetNumberOfUserNotifications(CharityNotification notification);

    }
}
