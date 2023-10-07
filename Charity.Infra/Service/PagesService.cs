using Charity.Core.Data;
using Charity.Core.Repository;
using Charity.Core.Service;
using Charity.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Infra.Service
{
    public class PagesService : IPagesService
    {
        private readonly IPagesRepository pageRepository;
        public PagesService(IPagesRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }
        public void CreatePage(CharityPage Page)
        {
            pageRepository.CreatePage(Page);
        }

        public void DeletePage(int id)
        {
            pageRepository.DeletePage(id);
        }

        public List<CharityPage> GetAllPages()
        {
           return pageRepository.GetAllPages();
        }

        public CharityPage GetPageByTitle(string title)
        {
           return pageRepository.GetPageByTitle(title);
        }

        public void UpdatePage(CharityPage Page)
        {
            pageRepository.UpdatePage(Page);
        }
    }
}
