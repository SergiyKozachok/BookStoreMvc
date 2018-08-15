using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    public interface IPageService
    {
        List<PageDto> GetAll();
        PageDto GetById(int id);
        void Add(PageDto page);
        void Update(int id, PageDto page);
        void Remove(int id);
    }
}
