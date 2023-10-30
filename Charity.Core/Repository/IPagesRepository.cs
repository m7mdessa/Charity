using Charity.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.Repository
{
    public interface IPagesRepository
    {
        List<CharityPage> GetAllPages();
        public void AddHomePage(CharityPage home);
        public void UpdateHomePage(CharityPage home);
        public void AddAboutPage(CharityPage about);
        public void UpdateAboutPage(CharityPage about);
        public void AddContactPage(CharityPage contact);
        public void UpdateContactPage(CharityPage contact);
        void DeletePage(int id);
        List<CharityPage> GetPageByTitle(string title);
    }
}
