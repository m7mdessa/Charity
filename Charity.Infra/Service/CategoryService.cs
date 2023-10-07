using Charity.Core.Data;
using Charity.Core.Repository;
using Charity.Core.Service;

namespace Charity.Infra.Service
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;
		public CategoryService(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}
		public void CreateCategory(CharityCategory category)
		{
			categoryRepository.CreateCategory(category);
		}

		public void DeleteCategory(int id)
		{
			categoryRepository.DeleteCategory(id);
		}

		public List<CharityCategory> GetAllCategories()
		{
			return categoryRepository.GetAllCategories();
		}

		public CharityCategory GetCategoryById(int id)
		{
			return categoryRepository.GetCategoryById(id);
		}

		public void UpdateCategory(CharityCategory category)
		{
			categoryRepository.UpdateCategory(category);
		}
	}
}
