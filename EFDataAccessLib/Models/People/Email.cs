using EFDataAccessLib.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models.People
{
    public class Email : DbEntityObject
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string EmailAdress { get; set; }
    }
}
