using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferLayer.Models
{
    [Table("Sidebars")]
    public class SidebarDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public String Body { get; set; }

        public SidebarDto()
        {

        }

        public SidebarDto(Sidebar page)
        {
            Id = page.Id;
            Body = page.Body;
        }
    }
}
