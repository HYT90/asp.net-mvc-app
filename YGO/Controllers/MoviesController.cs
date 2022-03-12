using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Data;

namespace YGO.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext appDbContext;

        public MoviesController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await appDbContext.Movies.Include(item => item.Cinema).ToListAsync();
            return View(result);
        }
    }
}
