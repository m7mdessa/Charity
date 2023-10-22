using Charity.Core.Data;
using Charity.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Charity.API.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[HttpGet]
		public List<CharityCategory> GetAllCategories()
		{
			return categoryService.GetAllCategories();
		}

		[HttpPost]
		public void CreateCategory(CharityCategory category)
		{
			categoryService.CreateCategory(category);
		}

		[HttpPut]
		public void UpdateCategory(CharityCategory category)
		{
			categoryService.UpdateCategory(category);
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public void DeleteCategory(int id)
		{
			categoryService.DeleteCategory(id);
		}

		[HttpGet]
		[Route("getCategoryById/{id}")]
		public CharityCategory GetCategoryById(int id)
		{
			return categoryService.GetCategoryById(id);
		}


		[Route("uploadImage")]
		[HttpPost]
		public CharityCategory UploadImage()
		{
			var file = Request.Form.Files[0];
			var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			CharityCategory item = new CharityCategory();
			item.Image = fileName;
			return item;
		}

	}
}
