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
    public class OrderBooksService : IOrderBooksService
    {

        public void Add(OrderBooksDto orderBooks)
        {
            using (var uow = new UnitOfWork())
            {
                OrderBooks orderBooksDb = new OrderBooks()
                {
                    Order_Id = orderBooks.Order_Id,
                    Book_Id = orderBooks.Book_Id,
                    Price = orderBooks.Price,
                    Quantity = orderBooks.Quantity
                };
                uow.OrderBooksRepository.Insert(orderBooksDb);
                uow.SaveChanges();
            }
        }

        public List<OrderBooksDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.OrderBooksRepository.GetAll().Select(x => new OrderBooksDto(x)).ToList();
            }
        }

        public OrderBooksDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getOrderBooks = uow.OrderBooksRepository.GetById(id);
                OrderBooksDto orderBooks = new OrderBooksDto()
                {
                    Order_Id = getOrderBooks.Order_Id,
                    Book_Id = getOrderBooks.Book_Id,
                    Price = getOrderBooks.Price,
                    Quantity = getOrderBooks.Quantity
                };
                return orderBooks;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                OrderBooks orderBooks = uow.OrderBooksRepository.GetById(id);
                uow.OrderBooksRepository.Delete(orderBooks);
                uow.SaveChanges();
            }
        }

        public void Update(int id, OrderBooksDto orderBooks)
        {
            using (var uow = new UnitOfWork())
            {
                OrderBooks orderBooksDb = new OrderBooks()
                {
                    Book_Id = orderBooks.Book_Id,
                    Order_Id = orderBooks.Order_Id,
                    Price = orderBooks.Price,
                    Quantity = orderBooks.Quantity
                };
                uow.OrderBooksRepository.Update(orderBooksDb);
                uow.SaveChanges();
            }
        }

    }
}
