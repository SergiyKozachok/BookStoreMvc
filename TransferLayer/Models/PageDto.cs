using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Database.Models;

namespace TransferLayer.Models
{
    
    [Table("Pages")]
    public class PageDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public String Title { get; set; }

        public String Slug { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public String Body { get; set; }

        public int Sorting { get; set; }

        public bool HasSidebar { get; set; }

        public PageDto()
        {

        }

        public PageDto(Page page)
        {
            Id = page.Id;
            Title = page.Title;
            Slug = page.Slug;
            Body = page.Body;
            Sorting = page.Sorting;
            HasSidebar = page.HasSidebar;
        }
    }
}
