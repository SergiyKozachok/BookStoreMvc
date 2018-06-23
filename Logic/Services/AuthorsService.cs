using Database.Models;
using Database.UnitOfWork;
using Logic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLayer.Models;


namespace Logic.Services
{
    public class AuthorsService : IAuthorsService
    {
        public void Add(AuthorDto author)
        {
            using(var uow = new UnitOfWork())
            {
                Author authorDb = new Author()
                {
                    Id = author.Id,
                    firstName = author.FirstName,
                    lastName = author.LastName
                };

                uow.AuthorRepository.Insert(authorDb);
                uow.SaveChanges();
                //return ;
            }
        }

        public List<AuthorDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.AuthorRepository.GetAll().Select(x => new AuthorDto(x)).ToList();
            }
        }

        public AuthorDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getAuthor = uow.AuthorRepository.GetById(id);
                AuthorDto author = new AuthorDto(){
                    Id = getAuthor.Id,
                    FirstName = getAuthor.firstName,
                    LastName = getAuthor.lastName

                };
                return author;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Author author = uow.AuthorRepository.GetById(id);
                uow.AuthorRepository.Delete(author);
                uow.SaveChanges();
            }
        }

        public void Update(int id, AuthorDto author)
        {
            using (var uow = new UnitOfWork())
            {
                Author authorDb = new Author()
                {
                    Id = author.Id,
                    firstName = author.FirstName,
                    lastName = author.LastName
                };
                uow.AuthorRepository.Update(authorDb);
                uow.SaveChanges();
            }
        }

    }
}
