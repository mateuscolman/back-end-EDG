using EscombrosDaGuerra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscombrosDaGuerra.DataBase
{
    public class EGContext : DbContext
    {
        public EGContext(DbContextOptions<EGContext> options) : base(options)
        {

        }

        public DbSet<Spells> Spells { get; set; }
    }
}
