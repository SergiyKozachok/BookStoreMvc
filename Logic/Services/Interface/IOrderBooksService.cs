using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    public interface IOrderBooksService
    {
        List<OrderBooksDto> GetAll();
        OrderBooksDto GetById(int id);
        void Add(OrderBooksDto orderBooks);
        void Update(int id, OrderBooksDto orderBooks);
        void Remove(int id);
    }
}
