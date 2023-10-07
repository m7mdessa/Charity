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
		private readonly ITestimonialService TestimonialService;

		public TestimonialController(ITestimonialService TestimonialService)
		{
			this.TestimonialService = TestimonialService;

		}

		[HttpGet]
		public List<Testimonials> GetAllTestimonials()
		{
			return TestimonialService.GetAllTestimonials();
		}
        [HttpGet]
        [Route("GetTestimonialByUserId/{user_id}")]
        public List<Testimonials> GetTestimonialByUserId(int user_id)
        {
            return TestimonialService.GetTestimonialByUserId(user_id);
        }


        [HttpPost]
		public void CreateTestimonial(CharityTestimonial Testimonial)
		{
			TestimonialService.CreateTestimonial(Testimonial);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteTestimonial(int id)
		{
			TestimonialService.DeleteTestimonial(id);
		}

		[HttpGet]
		[Route("GetTestimonialById/{id}")]
		public CharityTestimonial GetTestimonialById(int id)
		{
			return TestimonialService.GetTestimonialById(id);
		}


		[HttpPut]
		public void UpdateTestimonial(CharityTestimonial Testimonial)
		{
			TestimonialService.UpdateTestimonial(Testimonial);
		
		}


	}

}
