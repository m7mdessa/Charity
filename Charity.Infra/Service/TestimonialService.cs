using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{

	public class TestimonialService : ITestimonialService
	{
		private readonly ITestimonialRepository testimonialRepository;
		public TestimonialService(ITestimonialRepository testimonialRepository)
		{
			this.testimonialRepository = testimonialRepository;
		}
		public List<Testimonials> GetAllTestimonials()
		{
			return testimonialRepository.GetAllTestimonials();
		}
		public void CreateTestimonial(CharityTestimonial testimonial)
		{
			testimonialRepository.CreateTestimonial(testimonial);
		}
		public void DeleteTestimonial(int id)
		{
			testimonialRepository.DeleteTestimonial(id);
		}
		public void UpdateTestimonial(CharityTestimonial testimonial)
		{
			testimonialRepository.UpdateTestimonial(testimonial);
		}
		public CharityTestimonial GetTestimonialById(int id)
		{
			return testimonialRepository.GetTestimonialById(id);
		}
        public List<Testimonials> GetTestimonialByUserId(int user_id)
        {
            return testimonialRepository.GetTestimonialByUserId(user_id);
        }

    }

}
