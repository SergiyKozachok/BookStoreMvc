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
    public class OrderService : IOrderService
    {
        public void Add(OrderDto order)
        {
            using (var uow = new UnitOfWork())
            {
                Order orderDb = new Order()
                {
                    Id = order.Id,
                    OrderName = order.OrderName,
                    OrderDate = order.OrderDate,
                    PaymentType = order.PaymentType,
                    Status = order.Status,
                    CustomerName = order.CustomerName,
                    CustomerSurname = order.CustomerSurname,
                    CustomerPhone = order.CustomerPhone,
                    CustomerEmail = order.CustomerEmail,
                    CustomerAddress = order.CustomerAddress
            };

                uow.OrderRepository.Insert(orderDb);
                uow.SaveChanges();
            }
        }

        public List<OrderDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.OrderRepository.GetAll().Select(x => new OrderDto(x)).ToList();
            }
        }

        public OrderDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getOrder = uow.OrderRepository.GetById(id);
                OrderDto order = new OrderDto()
                {
                    Id = getOrder.Id,
                    OrderName = getOrder.OrderName,
                    OrderDate = getOrder.OrderDate,
                    PaymentType = getOrder.PaymentType,
                    Status = getOrder.Status,
                    CustomerName = getOrder.CustomerName,
                    CustomerSurname = getOrder.CustomerSurname,
                    CustomerPhone = getOrder.CustomerPhone,
                    CustomerEmail = getOrder.CustomerEmail,
                    CustomerAddress = getOrder.CustomerAddress
                };
                return order;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Order order = uow.OrderRepository.GetById(id);
                uow.OrderRepository.Delete(order);
                uow.SaveChanges();
            }
        }

        public void Update(int id, OrderDto order)
        {
            using (var uow = new UnitOfWork())
            {
                Order orderDb = new Order()
                {
                    Id = order.Id,
                    OrderName = order.OrderName,
                    OrderDate = order.OrderDate,
                    PaymentType = order.PaymentType,
                    Status = order.Status,
                    CustomerName = order.CustomerName,
                    CustomerSurname = order.CustomerSurname,
                    CustomerPhone = order.CustomerPhone,
                    CustomerEmail = order.CustomerEmail,
                    CustomerAddress = order.CustomerAddress
                };
                uow.OrderRepository.Update(orderDb);
                uow.SaveChanges();
            }
        }
    }
}
