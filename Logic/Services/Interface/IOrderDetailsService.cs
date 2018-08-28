using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    public interface IOrderDetailsService
    {
        List<OrderDetailsDto> GetAll();
        OrderDetailsDto GetById(int id);
        void Add(OrderDetailsDto orderBooks);
        void Update(int id, OrderDetailsDto orderBooks);
        void Remove(int id);
    }
}
