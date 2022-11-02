using ListFilmsMvc.Models;
using ListFilmsMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Data
{
    public class SeedingService
    {
        private ListFilmsMvcContext _context;

        public SeedingService(ListFilmsMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Movie.Any())
            {
                return; // DB has been seeded
            }

            // Creation data to migration on DB (Movie)
            Movie m1 = new Movie(1, "O Poderoso Chefão", "Francis Ford Coppola", 1972, TypeGenre.Drama, TypeCategory.Film, 9.2);
            Movie m2 = new Movie(2, "Guerra nas Estrelas", "George Lucas", 1977, TypeGenre.Adventure, TypeCategory.Film, 8.6);
            Movie m3 = new Movie(3, "O Silêncio dos Inocentes", "Jonathan Demme", 1991, TypeGenre.Drama, TypeCategory.Film, 8.6);
            Movie m4 = new Movie(4, "The Office", "Greg Daniels", 2005, TypeGenre.Comedy, TypeCategory.Series, 9.0);
            Movie m5 = new Movie(5, "O Mandaloriano", "Jon Favreau", 2019, TypeGenre.Fantasy, TypeCategory.Series, 8.7);
            Movie m6 = new Movie(6, "Alquimia das Almas", "Jonathan Demme", 2022, TypeGenre.Fantasy, TypeCategory.Series, 8.7);

            // Adding movies on DB
            _context.Movie.AddRange(m1, m2, m3, m4, m5, m6);

            // Execution saving data
            _context.SaveChanges();

        }
    }
}
