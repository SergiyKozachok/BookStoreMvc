using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    interface IBooksService
    {
        List<BookDto> GetAll();
        BookDto GetById(int id);
        void Add(BookDto book);
        void Update(int id, BookDto book);
        void Remove(int id);
    }
}
