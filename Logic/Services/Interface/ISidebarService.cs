using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    public interface ISidebarService
    {
        List<SidebarDto> GetAll();
        SidebarDto GetById(int id);
        void Add(SidebarDto page);
        void Update(int id, SidebarDto sidebar);
        void Remove(int id);
    }
}
