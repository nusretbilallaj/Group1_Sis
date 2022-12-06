using Group1_Sis.Data;
using Group1_Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Group1_Sis.Controllers
{
    public class KategoriController : Controller
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
        public KategoriController(Konteksti kont)
        {
            _konteksti = kont;
        }
        public IActionResult Listo()
        {
           List<Kategoria> kategorite= _konteksti.Kategorite.ToList();
           var komunat = _konteksti.Komunat.ToList();

            return View(kategorite);
        }
        [HttpPost]
        public IActionResult Krijo(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Add(kat);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            return View(kat);
        }
        public IActionResult Krijo()
        {
            Kategoria kat = new Kategoria();
            return View(kat);
        }

        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kategoria kat = _konteksti.Kategorite.Find(id);
            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
        [HttpPost]
        public IActionResult Fshi(Kategoria kat)
        {
  
                _konteksti.Kategorite.Remove(kat);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
        }


        [HttpPost]
        public IActionResult Ndrysho(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Update(kat);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            return View(kat);
        }
        public IActionResult Ndrysho(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            Kategoria kat= _konteksti.Kategorite.Find(id);
            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
    }
}
