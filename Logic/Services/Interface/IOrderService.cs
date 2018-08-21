using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    public interface IOrderService
    {
        List<OrderDto> GetAll();
        OrderDto GetById(int id);
        void Add(OrderDto order);
        void Update(int id, OrderDto order);
        void Remove(int id);
    }
}
