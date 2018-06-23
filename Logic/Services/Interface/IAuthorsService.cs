using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;

namespace Logic.Services.Interface
{
    interface IAuthorsService
    {
        List<AuthorDto> GetAll();
        AuthorDto GetById(int id);
        void Add(AuthorDto author);
        void Update(int id, AuthorDto author);
        void Remove(int id);
    }
}
