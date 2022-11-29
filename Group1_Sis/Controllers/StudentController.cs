using Group1_Sis.Data;
using Group1_Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Group1_Sis.Controllers
{
    public class StudentController : Controller
    {
        private readonly Konteksti _konteksti;
        public StudentController(Konteksti kont)
        {
            _konteksti = kont;
        }
        public IActionResult Listo()
        {
           List<Student> studentet= _konteksti.Studentet.Include(x=>x.Komuna).ToList();
           var komunat = _konteksti.Komunat.ToList();

            return View(studentet);
        }

        public IActionResult Krijo()
        {
            Student studi = new Student();

           List<Komuna> komunat= _konteksti.Komunat.ToList();
           List<SelectListItem> lista = new List<SelectListItem>();

           foreach (var kom in komunat)
           {
               SelectListItem item = new SelectListItem();
               item.Text = kom.Emri;
               item.Value = kom.Id.ToString();
               lista.Add(item);
           }

           ViewBag.Komunat = lista;

            return View(studi);
        }
    }
}
