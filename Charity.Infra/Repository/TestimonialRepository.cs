using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.DTO;
using Charity.Core.Repository;
using Dapper;
using System.Data;

namespace Charity.Infra.Repository
{
	public class TestimonialRepository : ITestimonialRepository
	{
		private readonly IDbContext _dbContext;
		public TestimonialRepository(IDbContext dBContext)
		{
            _dbContext = dBContext;
		}
		public void CreateTestimonial(CharityTestimonial testimonial)
		{
			var p = new DynamicParameters();
			p.Add("u_testimonial", testimonial.Testimonial, dbType: DbType.String, direction: ParameterDirection.Input);
			p.Add("t_user_id", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
		}

		public void DeleteTestimonial(int id)
		{
			var p = new DynamicParameters();
			p.Add("t_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Package.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
		}

		public List<Testimonials> GetAllTestimonials()
		{
			IEnumerable<Testimonials> result = _dbContext.Connection.Query<Testimonials>("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public CharityTestimonial GetTestimonialById(int id)
		{
			var p = new DynamicParameters();
			p.Add("t_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			IEnumerable<CharityTestimonial> result = _dbContext.Connection.Query<CharityTestimonial>("Testimonial_Package.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}
        public List<Testimonials> GetTestimonialByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("t_user_id", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Testimonials> result = _dbContext.Connection.Query<Testimonials>("Testimonial_Package.GetTestimonialByUserId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateTestimonial(CharityTestimonial testimonial)
		{
			var p = new DynamicParameters();
			p.Add("t_id", testimonial.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			p.Add("t_status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("Testimonial_Package.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
		}
		
	}
}
