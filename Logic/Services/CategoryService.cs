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
    public class CategoryService : ICategoryService
    {
        public void Add(CategoryDto category)
        {
            using (var uow = new UnitOfWork())
            {
                Category categoryDb = new Category()
                {
                    Id = category.Id,
                    Title = category.Title
                };

                uow.CategoryRepository.Insert(categoryDb);
                uow.SaveChanges();
            }
        }

        public List<CategoryDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.CategoryRepository.GetAll().Select(x => new CategoryDto(x)).ToList();
            }
        }

        public CategoryDto GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var getCategory = uow.CategoryRepository.GetById(id);
                CategoryDto category = new CategoryDto()
                {
                    Id = getCategory.Id,
                    Title = getCategory.Title
                };
                return category;
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Category category = uow.CategoryRepository.GetById(id);
                uow.CategoryRepository.Delete(category);
                uow.SaveChanges();
            }
        }

        public void Update(int id, CategoryDto category)
        {
            using (var uow = new UnitOfWork())
            {
                Category categoryDb = new Category()
                {
                    Id = category.Id,
                    Title = category.Title
                };
                uow.CategoryRepository.Update(categoryDb);
                uow.SaveChanges();
            }
        }
    }
}
