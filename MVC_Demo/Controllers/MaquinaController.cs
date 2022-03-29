using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Demo.Models;
using MVC_Demo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Demo.Controllers
{
    public class MaquinaController : Controller
    {
        private readonly ReportesFLAContext _context;
        public MaquinaController(ReportesFLAContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var maquinas = _context.Maquinas.Where(x => x.Id == 1).Include(b => b.Referencia).ToList(); //Se puede Usar Where o Select
            var maquinas = _context.Maquinas.Include(b => b.Referencia).ToList(); 
            return View( maquinas);
        }

        public IActionResult Create()
        {
            ViewData["Maquinas"] = new SelectList(_context.Maquinas,"Id","Nombre", "Descripcion");
            return View();
        }  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaquinaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maquina = new Maquina()
                {
                    Nombre = model.Nombre,
                    IdLinea = model.IdLinea,
                    Descripcion = model.Descripcion

                };
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return (RedirectToAction(nameof(Index)));
            };
            ViewData["Maquinas"] = new SelectList(_context.Maquinas, "IdLinea", "Nombre", "Descripcion", model.IdLinea.ToString());
            return View(model);
        }
    }
}
