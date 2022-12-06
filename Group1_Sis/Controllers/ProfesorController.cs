using Group1_Sis.Data;
using Group1_Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Group1_Sis.Controllers
{
    public class ProfesorController : Controller
    {

        private readonly Konteksti _konteksti;

        public List<SelectListItem> MerriKomunat()
        {
            List<Komuna> komunat = _konteksti.Komunat.ToList();
            List<SelectListItem> lista = new List<SelectListItem>();

            foreach (var kom in komunat)
            {
                SelectListItem item = new SelectListItem();
                item.Text = kom.Emri;
                item.Value = kom.Id.ToString();
                lista.Add(item);
            }

            return lista;
        }
        public ProfesorController(Konteksti kont)
        {
            _konteksti = kont;
        }
        public IActionResult Listo()
        {
           List<Profesor> profesoret= _konteksti.Profesoret.Include(x=>x.Komuna).ToList();
           var komunat = _konteksti.Komunat.ToList();

            return View(profesoret);
        }
        [HttpPost]
        public IActionResult Krijo(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Profesoret.Add(profesor);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            ViewBag.Kom = MerriKomunat();
            return View(profesor);
        }
        public IActionResult Krijo()
        {
            Profesor prof = new Profesor();

            ViewBag.Kom = MerriKomunat();

            return View(prof);
        }

        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Profesor prof = _konteksti.Profesoret.Find(id);
            if (prof == null)
            {
                return NotFound();
            }

            ViewBag.Komunat = MerriKomunat();

            return View(prof);
        }
        [HttpPost]
        public IActionResult Fshi(Profesor prof)
        {
  
                _konteksti.Profesoret.Remove(prof);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
        }


        [HttpPost]
        public IActionResult Ndrysho(Profesor prof)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Profesoret.Update(prof);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            ViewBag.Komunat = MerriKomunat();
            return View(prof);
        }
        public IActionResult Ndrysho(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            Profesor prof= _konteksti.Profesoret.Find(id);
            if (prof == null)
            {
                return NotFound();
            }

            ViewBag.Komunat = MerriKomunat();

            return View(prof);
        }
    }
}
