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
    public class SubjectController : BaseController<SubjectModel>
    {
        public SubjectController(IBaseRepository<SubjectModel> context) : base(context)
        {
        }
    }
}
