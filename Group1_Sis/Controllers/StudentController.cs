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
        [HttpPost]
        public IActionResult Krijo(Student student)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Studentet.Add(student);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            ViewBag.Kom = MerriKomunat();
            return View(student);
        }
        public IActionResult Krijo()
        {
            Student studi = new Student();

          

           ViewBag.Kom = MerriKomunat();

            return View(studi);
        }

        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Student stud = _konteksti.Studentet.Find(id);
            if (stud == null)
            {
                return NotFound();
            }

            ViewBag.Komunat = MerriKomunat();

            return View(stud);
        }
        [HttpPost]
        public IActionResult Fshi(Student stu)
        {
  
                _konteksti.Studentet.Remove(stu);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
        }


        [HttpPost]
        public IActionResult Ndrysho(Student stud)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Studentet.Update(stud);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            ViewBag.Komunat = MerriKomunat();
            return View(stud);
        }
        public IActionResult Ndrysho(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            Student stud= _konteksti.Studentet.Find(id);
            if (stud==null)
            {
                return NotFound();
            }

            ViewBag.Komunat = MerriKomunat();

            return View(stud);
        }
    }
}
