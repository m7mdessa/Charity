using Azure.Core;
using Charity.Core.Data;
using Charity.Core.Data.DTO;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{
	public class AdminService : IAdminService
	{

		private readonly IAdminRepository adminRepository;
		public AdminService(IAdminRepository adminRepository)
		{
			this.adminRepository = adminRepository;
		}

        public void AcceptCharity(Charities charity)
        {
            adminRepository.AcceptCharity(charity);
        }

        public List<Benefits> benefits()
		{
			return adminRepository.benefits();
		}

		public List<Donations> GetAllDonations()
		{
			return adminRepository.GetAllDonations();
		}

		public List<CharityNotification> GetAllNotifications()
		{
			return adminRepository.GetAllNotifications();
		}


		public int GetNumberOfCharities()
        {
			return adminRepository.GetNumberOfCharities();
        }

		public int GetNumberOfNotifications()
		{
			return adminRepository.GetNumberOfNotifications();
		}

		public int GetNumberOfUsers()
		{
			return adminRepository.GetNumberOfUsers();
        }

		public List<CategoryWithMaxCharities> MaxCharityCategory()
        {
            return adminRepository.MaxCharityCategory();
        }

		public List<Reports> Reports()
		{
			return adminRepository.Reports();
		}

		public List<Reports> ReportsInterval(DateTime StartDate, DateTime EndDate)
		{
			return adminRepository.ReportsInterval(StartDate, EndDate);
		}

        public List<Charitys> SerchBetweenDates(DateTime DateFrom, DateTime DateTo)
        {
            return adminRepository.SerchBetweenDates(DateFrom, DateTo);
		}

		public void UpdateAdmin(CharityUser admin)
		{
			adminRepository.UpdateAdmin(admin);
		}

	
    }
}
