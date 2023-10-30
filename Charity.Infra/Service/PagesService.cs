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

        public void AddAboutPage(CharityPage about)
        {
            pageRepository.AddAboutPage(about);
        }

        public void AddContactPage(CharityPage contact)
        {
            pageRepository.AddContactPage(contact);
        }

        public void AddHomePage(CharityPage home)
        {
            pageRepository.AddHomePage(home);
        }

        public void DeletePage(int id)
        {
            pageRepository.DeletePage(id);
        }

        public List<CharityPage> GetAllPages()
        {
           return pageRepository.GetAllPages();
        }

        public List<CharityPage> GetPageByTitle(string title)
        {
           return pageRepository.GetPageByTitle(title);
        }

        public void UpdateAboutPage(CharityPage about)
        {
            pageRepository.UpdateAboutPage(about);
        }

        public void UpdateContactPage(CharityPage contact)
        {
            pageRepository.UpdateContactPage(contact);
        }

        public void UpdateHomePage(CharityPage home)
        {
            pageRepository.UpdateHomePage(home);
        }

       
    }
}
