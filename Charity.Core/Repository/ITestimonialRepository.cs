using Charity.Core.Data;
using Charity.Core.DTO;

namespace Charity.Core.Repository
{
	public interface ITestimonialRepository
	{
		List<Testimonials> GetAllTestimonials();
		void CreateTestimonial(CharityTestimonial testimonial);
		void DeleteTestimonial(int id);
		public void UpdateTestimonial(CharityTestimonial testimonial);
		CharityTestimonial GetTestimonialById(int id);
        public List<Testimonials> GetTestimonialByUserId(int userId);

    }
}
