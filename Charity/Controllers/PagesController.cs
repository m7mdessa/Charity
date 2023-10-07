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
        public void CreatePage(CharityPage Page)
        {
            pageService.CreatePage(Page);
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

        public CharityPage GetPageByTitle(string title)
        {
            return pageService.GetPageByTitle(title);
        }


        [HttpPut]
        public void UpdatePage(CharityPage Page)
        {
            pageService.UpdatePage(Page);
        }

        [HttpPost]
        [Route("Slide1")]
        public CharityPage Slide1()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
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
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
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
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
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
            var fullPath = Path.Combine("C:\\Users\\ysym1\\Desktop\\tahaluf\\finalproject\\Charity.Angular\\src\\assets\\img", fileName);
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
