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
            optionsBuilder.UseSqlServer(@"workstation id=Mmusica.mssql.somee.com;packet size=4096;user id=carlos1678_SQLLogin_1;pwd=w31qmpo264;data source=Mmusica.mssql.somee.com;persist security info=False;initial catalog=Mmusica;Trust Server Certificate=true;");
            //optionsBuilder.UseSqlServer(@"Data Source=M22-CVI;Initial Catalog=Mmusica;Integrated Security=True;Trust Server Certificate=true;");
        }
    }
}
