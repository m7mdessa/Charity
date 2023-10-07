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
        void CreatePage(CharityPage Page);
        void DeletePage(int id);
        CharityPage GetPageByTitle(string title);
        public void UpdatePage(CharityPage Page);
    }
}
