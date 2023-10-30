using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Charity.Core.Data;
using Charity.Core.Service;

namespace Charity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {

        private readonly IPagesService pageService;
        public PagesController(IPagesService pageService)
        {
            this.pageService = pageService;
        
        }


        [HttpPost]
        [Route("homePage")]

        public void AddHomePage(CharityPage home)
        {
            pageService.AddHomePage(home);
        }

        [HttpPost]
        [Route("aboutPage")]

        public void AddAboutPage(CharityPage about)
        {
            pageService.AddAboutPage(about);
        }

        [HttpPost]
        [Route("contactPage")]

        public void AddContactPage(CharityPage contact)
        {
            pageService.AddContactPage(contact);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeletePage(int id)
        {
            pageService.DeletePage(id);
        }

        [HttpGet]
        public List<CharityPage> GetAllPages()
        {
            return pageService.GetAllPages();
        }


        [HttpGet]
        [Route("GetPageByTitle/{title}")]

        public List<CharityPage> GetPageByTitle(string title)
        {
            return pageService.GetPageByTitle(title);
        }


        [HttpPut]
        [Route("homePage")]

        public void UpdateHomePage(CharityPage home)
        {
            pageService.UpdateHomePage(home);
        }

        [HttpPut]
        [Route("aboutPage")]

        public void UpdateAboutPage(CharityPage about)
        {
            pageService.UpdateAboutPage(about);
        }


        [HttpPut]
        [Route("contactPage")]

        public void UpdateContactPage(CharityPage contact)
        {
            pageService.UpdateContactPage(contact);
        }
       
        [HttpPost]
        [Route("Slide1")]
        public CharityPage Slide1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CharityPage item = new CharityPage();
            item.Slide1 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Slide2")]
        public CharityPage Slide2()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CharityPage item = new CharityPage();
            item.Slide2 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Slide3")]
        public CharityPage Slide3()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CharityPage item = new CharityPage();
            item.Slide3 = fileName;
            return item;
        }

        [HttpPost]
        [Route("Logo")]
        public CharityPage Logo()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\Charity-Frontend\\src\\assets\\img", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CharityPage item = new CharityPage();
            item.Logo = fileName;
            return item;
        }
    }
}
