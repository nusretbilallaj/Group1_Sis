using Group1_Sis.Models;
using Microsoft.EntityFrameworkCore;

namespace Group1_Sis.Data
{
    public class Konteksti: DbContext
    {
        public Konteksti(DbContextOptions<Konteksti> opcionet):base(opcionet)
        {
            
        }

        public DbSet<Student> Studentet { get; set; }
        public DbSet<Komuna> Komunat { get; set; }

    }
}
