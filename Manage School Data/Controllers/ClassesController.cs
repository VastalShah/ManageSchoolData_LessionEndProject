using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_School_Data;
using Manage_School_Data.Models;
using DataLayer;

namespace Manage_School_Data.Controllers
{
    public class ClassesController : BaseController<ClassesModel>
    {
        public ClassesController(IBaseRepository<ClassesModel> repo) : base(repo)
        {
        }

        /*//*private bool ClassesModelExists(int id)
        {
            return _context.ClassesModel.Any(e => e.ID == id);
        }*/
    }
}
