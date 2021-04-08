using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_School_Data.Models
{
    public class ClassesModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Stream { get; set; }
    }
}
