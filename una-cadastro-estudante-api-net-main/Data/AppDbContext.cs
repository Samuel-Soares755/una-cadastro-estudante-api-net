using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroEstudanteApi324147097.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroEstudanteApi324147097.Data
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Estudante> Estudantes { get; set;}
    }
}