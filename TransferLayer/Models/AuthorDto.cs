using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }

        //[JsonProperty("firstName")]
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public AuthorDto() { }

        public AuthorDto(Author entity)
        {
            Id = entity.Id;
            FirstName = entity.firstName;
            LastName = entity.lastName;
        }

        public Author GetEntity()
        {
            return new Author()
            {
                Id = Id,
                firstName = FirstName,
                lastName = LastName
            };
        }
    }

    public class SelectListItemViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
