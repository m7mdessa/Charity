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


        public void AddHomePage(CharityPage home)
        {
            var p = new DynamicParameters();
            p.Add("p_title", home.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", home.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide2", home.Slide2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide3", home.Slide3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_content", home.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_logo", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", home.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", home.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", home.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.AddHomePage", p, commandType: CommandType.StoredProcedure);
        }

        public void AddAboutPage(CharityPage about)
        {
            var p = new DynamicParameters();
            p.Add("p_title", about.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", about.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_content", about.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            
            DbContext.Connection.Execute("Pages_PACKAGE.AddAboutPage", p, commandType: CommandType.StoredProcedure);
        }

        public void AddContactPage(CharityPage contact)
        {
            var p = new DynamicParameters();

            p.Add("p_title", contact.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", contact.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", contact.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.AddContactPage", p, commandType: CommandType.StoredProcedure);

        }

        public void UpdateHomePage(CharityPage home)
        {
            var p = new DynamicParameters();
            p.Add("p_id", home.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", home.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", home.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide2", home.Slide2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide3", home.Slide3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_content", home.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_logo", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", home.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", home.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", home.Location, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.UpdateHomePage", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateAboutPage(CharityPage about)
        {
            var p = new DynamicParameters();
            p.Add("p_id", about.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", about.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_slide1", about.Slide1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_content", about.Content, dbType: DbType.String, direction: ParameterDirection.Input);

            DbContext.Connection.Execute("Pages_PACKAGE.UpdateAboutPage", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateContactPage(CharityPage contact)
        {
            var p = new DynamicParameters();
            p.Add("p_id", contact.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_title", contact.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Phone", contact.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Location", contact.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            DbContext.Connection.Execute("Pages_PACKAGE.UpdateContactPage", p, commandType: CommandType.StoredProcedure);

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

        
       

      
    }
}
