using Manage_School_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage_School_Data
{
    public class MVC_Context : DbContext
    {
        public MVC_Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StudentModel> StudentModel { get; set; }
        
        public DbSet<SubjectModel> SubjectModel { get; set; }
        
        public DbSet<ClassesModel> ClassesModel { get; set; }
    }
}
