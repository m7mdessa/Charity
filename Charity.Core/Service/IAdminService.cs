

using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;

namespace Charity.Core.Service
{
	public interface IAdminService
	{
		public void UpdateAdmin(CharityUser admin);
		public int GetNumberOfUsers();
		public int GetNumberOfCharities();

		public List<CategoryWithMaxCharities> MaxCharityCategory();
        public List<Charitys> SerchBetweenDates(DateTime DateFrom, DateTime DateTo);
        List<Reports> Reports();
		public List<Reports> ReportsInterval(DateTime StartDate, DateTime EndDate);

		public List<Benefits> benefits();
		public int GetNumberOfNotifications();

		public List<CharityNotification> GetAllNotifications();
		public List<Donations> GetAllDonations();


	}
}
