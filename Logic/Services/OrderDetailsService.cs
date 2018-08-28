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
    public class OrderDetailsService : IOrderDetailsService
    {

        public void Add(OrderDetailsDto orderDetails)
        {
            using (var uow = new UnitOfWork())
            {
                OrderDetails orderDetailsDb = new OrderDetails()
                {
                    OrderId = orderDetails.OrderId,
                    BookId = orderDetails.BookId,
                    Price = orderDetails.Price,
                    Quantity = orderDetails.Quantity
                };
                uow.OrderDetailsRepository.Insert(orderDetailsDb);
                uow.SaveChanges();
            }
        }

        public List<OrderDetailsDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.OrderDetailsRepository.GetAll().Select(x => new OrderDetailsDto(x)).ToList();
            }
        }

        public OrderDetailsDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getOrderDetails = uow.OrderDetailsRepository.GetById(id);
                OrderDetailsDto orderDetails = new OrderDetailsDto()
                {
                    OrderId = getOrderDetails.OrderId,
                    BookId = getOrderDetails.BookId,
                    Price = getOrderDetails.Price,
                    Quantity = getOrderDetails.Quantity
                };
                return orderDetails;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                OrderDetails orderDetails = uow.OrderDetailsRepository.GetById(id);
                uow.OrderDetailsRepository.Delete(orderDetails);
                uow.SaveChanges();
            }
        }

        public void Update(int id, OrderDetailsDto orderDetails)
        {
            using (var uow = new UnitOfWork())
            {
                OrderDetails orderDetailsDb = new OrderDetails()
                {
                    BookId = orderDetails.BookId,
                    OrderId = orderDetails.OrderId,
                    Price = orderDetails.Price,
                    Quantity = orderDetails.Quantity
                };
                uow.OrderDetailsRepository.Update(orderDetailsDb);
                uow.SaveChanges();
            }
        }

    }
}
