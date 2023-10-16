using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;

namespace Charity.Infra.Service
{

	public class TestimonialService : ITestimonialService
	{
		private readonly ITestimonialRepository _testimonialRepository;
		public TestimonialService(ITestimonialRepository testimonialRepository)
		{
			_testimonialRepository = testimonialRepository;
		}
		public List<Testimonials> GetAllTestimonials()
		{
			return _testimonialRepository.GetAllTestimonials();
		}
		public void CreateTestimonial(CharityTestimonial testimonial)
		{
            _testimonialRepository.CreateTestimonial(testimonial);
		}
		public void DeleteTestimonial(int id)
		{
            _testimonialRepository.DeleteTestimonial(id);
		}
		public void UpdateTestimonial(CharityTestimonial testimonial)
		{
            _testimonialRepository.UpdateTestimonial(testimonial);
		}
		public CharityTestimonial GetTestimonialById(int id)
		{
			return _testimonialRepository.GetTestimonialById(id);
		}
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
            return _testimonialRepository.GetTestimonialByUserId(userId);
        }

    }

}
