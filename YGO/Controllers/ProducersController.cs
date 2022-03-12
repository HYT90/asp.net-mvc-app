using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Data;

namespace YGO.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext appDbContext;

        public ProducersController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var result = await appDbContext.Producers.ToListAsync();
            return View(result);
        }
    }
}
