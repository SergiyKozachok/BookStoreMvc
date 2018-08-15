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
    public class SidebarService : ISidebarService
    {
        public void Add(SidebarDto page)
        {
            using (var uow = new UnitOfWork())
            {
                Sidebar sidebarDb = new Sidebar()
                {
                    Id = page.Id,
                    Body = page.Body
                };

                uow.SidebarRepository.Insert(sidebarDb);
                uow.SaveChanges();
                //return ;
            }
        }

        public List<SidebarDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.SidebarRepository.GetAll().Select(x => new SidebarDto(x)).ToList();
            }
        }

        public SidebarDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getSidebar = uow.SidebarRepository.GetById(id);
                SidebarDto sidebar = new SidebarDto()
                {
                    Id = getSidebar.Id,
                    Body = getSidebar.Body
                };
                return sidebar;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Sidebar sidebar = uow.SidebarRepository.GetById(id);
                uow.SidebarRepository.Delete(sidebar);
                uow.SaveChanges();
            }
        }

        public void Update(int id, SidebarDto sidebar)
        {
            using (var uow = new UnitOfWork())
            {
                Sidebar sidebarDb = new Sidebar()
                {
                    Id = sidebar.Id,
                    Body = sidebar.Body
                };
                uow.SidebarRepository.Update(sidebarDb);
                uow.SaveChanges();
            }
        }
    }
}
