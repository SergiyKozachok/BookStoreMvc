using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Database.UnitOfWork;
using Logic.Services.Interface;
using TransferLayer.Models;

namespace Logic.Services
{
    public class PageService : IPageService
    {
        public void Add(PageDto page)
        {
            using (var uow = new UnitOfWork())
            {
                Page pageDb = new Page()
                {
                    Id = page.Id,
                    Title = page.Title,
                    Slug = page.Slug,
                    Body = page.Body,
                    Sorting = page.Sorting,
                    HasSidebar = page.HasSidebar
            };

                uow.PageRepository.Insert(pageDb);
                uow.SaveChanges();
                //return ;
            }
        }

        public List<PageDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.PageRepository.GetAll().Select(x => new PageDto(x)).ToList();
            }
        }

        public PageDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getPage = uow.PageRepository.GetById(id);
                PageDto page = new PageDto()
                {
                    Id = getPage.Id,
                    Title = getPage.Title,
                    Slug = getPage.Slug,
                    Body = getPage.Body,
                    Sorting = getPage.Sorting,
                    HasSidebar = getPage.HasSidebar

                };
                return page;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Page page = uow.PageRepository.GetById(id);
                uow.PageRepository.Delete(page);
                uow.SaveChanges();
            }
        }

        public void Update(int id, PageDto page)
        {
            using (var uow = new UnitOfWork())
            {
                Page pageDb = new Page()
                {
                    Id = page.Id,
                    Title = page.Title,
                    Slug = page.Slug,
                    Body = page.Body,
                    Sorting = page.Sorting,
                    HasSidebar = page.HasSidebar
                };
                uow.PageRepository.Update(pageDb);
                uow.SaveChanges();
            }
        }
    }
}
