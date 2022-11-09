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

            // Creation data of Categories
            Category c1 = new Category(1, "Film");
            Category c2 = new Category(2, "Serie");

            // Creation data of Genres
            Genre g1 = new Genre(1, "Adventure");
            Genre g2 = new Genre(2, "Comedy");
            Genre g3 = new Genre(3, "Drama");
            Genre g4 = new Genre(4, "Horror");
            Genre g5 = new Genre(5, "Romance");
            Genre g6 = new Genre(6, "Science Fiction");
            Genre g7 = new Genre(7, "Mystery");
            Genre g8 = new Genre(8, "Fantasy");

            // Creation data of movies/series
            Movie m1 = new Movie(1, "O Poderoso Chefão", "Francis Ford Coppola", 1972, g3, c1, 9.2);
            Movie m2 = new Movie(2, "Guerra nas Estrelas", "George Lucas", 1977, g1, c1, 8.6);
            Movie m3 = new Movie(3, "O Silêncio dos Inocentes", "Jonathan Demme", 1991, g3, c1, 8.6);
            Movie m4 = new Movie(4, "The Office", "Greg Daniels", 2005, g2, c2, 9.0);
            Movie m5 = new Movie(5, "O Mandaloriano", "Jon Favreau", 2019, g8, c2, 8.7);
            Movie m6 = new Movie(6, "Alquimia das Almas", "Jonathan Demme", 2022, g8, c2, 8.7);

            // Adding movies on DB
            _context.Category.AddRange(c1,c2);
            _context.Genre.AddRange(g1, g2, g3, g4, g5, g6, g7, g8);
            _context.Movie.AddRange(m1, m2, m3, m4, m5, m6);

            // Execution saving data
            _context.SaveChanges();
        }
    }
}
