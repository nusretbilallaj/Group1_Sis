using Group1_Sis.Data;
using Group1_Sis.Models;
using Microsoft.AspNetCore.Mvc;

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
           List<Student> studentet= _konteksti.Studentet.ToList();
            return View(studentet);
        }
    }
}
