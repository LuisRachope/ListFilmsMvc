using ListFilmsMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Data
{
    public class ListFilmsMvcContext : IdentityDbContext
    {
        public ListFilmsMvcContext(DbContextOptions<ListFilmsMvcContext> options)
          : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
