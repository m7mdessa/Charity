using Charity.Core.Data;

namespace Charity.Core.Service
{
	public interface ICategoryService
	{
		List<CharityCategory> GetAllCategories();
		void CreateCategory(CharityCategory category);
		void DeleteCategory(int id);
		CharityCategory GetCategoryById(int id);
		public void UpdateCategory(CharityCategory category);
	}
}
