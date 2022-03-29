using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Demo.Controllers
{
    public class LineaController : Controller
    {

        private readonly ReportesFLAContext _context;

        public LineaController(ReportesFLAContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _context.Lineas.ToListAsync());
        }
    }
}
