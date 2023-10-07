using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Repository;
using Dapper;
using System.Data;

namespace Charity.Infra.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly IDbContext DbContext;
		public CategoryRepository(IDbContext dBContext)
		{
			DbContext = dBContext;
		}

		public void CreateCategory(CharityCategory category)
		{
			var p = new DynamicParameters();
			p.Add("c_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("c_image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Category_Package.CreateCategory", p, commandType: CommandType.StoredProcedure);
		}

		public void DeleteCategory(int id)
		{
			var p = new DynamicParameters();
			p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
		    DbContext.Connection.Execute("Category_Package.DeleteCategory", p, commandType: CommandType.StoredProcedure);
		}

		public List<CharityCategory> GetAllCategories()
		{
			IEnumerable<CharityCategory> result = DbContext.Connection.Query<CharityCategory>("Category_Package.GetAllCategories", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public CharityCategory GetCategoryById(int id)
		{
			var p = new DynamicParameters();
			p.Add("c_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<CharityCategory> result = DbContext.Connection.Query<CharityCategory>("Category_Package.GetCategoryById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}

		public void UpdateCategory(CharityCategory category)
		{
			var p = new DynamicParameters();
			p.Add("c_id", category.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("c_name", category.Categoryname, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("c_image", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
			DbContext.Connection.Execute("Category_Package.UpdateCategory", p, commandType: CommandType.StoredProcedure);
		}
	}
}
