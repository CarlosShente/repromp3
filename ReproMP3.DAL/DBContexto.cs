using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReproMP3.EN;
using Microsoft.EntityFrameworkCore;

namespace ReproMP3.DAL
{
    public class DBContexto : DbContext
    {
        public DbSet<Mmusica> Dmusica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=Mmusica;Integrated Security=True;Trust Server Certificate=true;");
        }
    }
}
