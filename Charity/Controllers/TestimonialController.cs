using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Service;
using Charity.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	
	public class TestimonialController : Controller
	{
		private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;

		}

		[HttpGet]
		public List<Testimonials> GetAllTestimonials()
		{
			return _testimonialService.GetAllTestimonials();
		}

        [HttpGet]
        [Route("GetTestimonialByUserId/{userId}")]
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
            return _testimonialService.GetTestimonialByUserId(userId);
        }


        [HttpPost]
		public void CreateTestimonial(CharityTestimonial testimonial)
		{
            _testimonialService.CreateTestimonial(testimonial);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteTestimonial(int id)
		{
            _testimonialService.DeleteTestimonial(id);
		}

		[HttpGet]
		[Route("GetTestimonialById/{id}")]
		public CharityTestimonial GetTestimonialById(int id)
		{
			return _testimonialService.GetTestimonialById(id);
		}


		[HttpPut]
		public void UpdateTestimonial(CharityTestimonial testimonial)
		{
            _testimonialService.UpdateTestimonial(testimonial);
		
		}


	}

}
