using Dapper;
using Charity.Core.Common;
using Charity.Core.Data;
using Charity.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Repository
{
    public class PagesRepository : IPagesRepository
    {
        private readonly IDbContext DbContext;
        public PagesRepository(IDbContext dBContext)
        {
            DbContext = dBContext;
        }
        public void CreatePage(CharityPage Page)
        {
            var p = new DynamicParameters();
            p.Add("p_title", Page.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", Page.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide2", Page.Slide2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide3", Page.Slide3, dbType: DbType.String, direction: ParameterDirection.Input); 
            p.Add("p_content", Page.Content, dbType: DbType.String, direction: ParameterDirection.Input); 
            p.Add("p_logo", Page.Logo, dbType: DbType.String, direction: ParameterDirection.Input); 
            p.Add("p_Email", Page.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", Page.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", Page.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.CreatePage", p, commandType: CommandType.StoredProcedure);
        }

        public void DeletePage(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            DbContext.Connection.Execute("Pages_PACKAGE.DeletePage", p, commandType: CommandType.StoredProcedure);
        }

        public List<CharityPage> GetAllPages()
        {
            IEnumerable<CharityPage> result = DbContext.Connection.Query<CharityPage>("Pages_PACKAGE.GetAllPages", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CharityPage> GetPageByTitle(string title)
        {
            var p = new DynamicParameters();
            p.Add("p_Title", title, direction: ParameterDirection.Input);

            IEnumerable<CharityPage> result = DbContext.Connection.Query<CharityPage>("Pages_PACKAGE.GetPageByTitle", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdatePage(CharityPage Page)
        {
            var p = new DynamicParameters();
            p.Add("p_id", Page.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", Page.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", Page.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide2", Page.Slide2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide3", Page.Slide3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_content", Page.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_logo", Page.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", Page.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", Page.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", Page.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.UpdatePage", p, commandType: CommandType.StoredProcedure);
        }
    }
}
