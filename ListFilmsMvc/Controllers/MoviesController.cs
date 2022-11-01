using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using ListFilmsMvc.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly ListFilmsMvcContext _context;

        //public MoviesController(ListFilmsMvcContext context)
        //{
        //_context = context;
        //}


        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie(1, "O Poderoso Chefão", "Francis Ford Coppola", 1972, TypeGenre.Drama,
                TypeCategory.Film, 9.2));
            movies.Add(new Movie(2, "Guerra nas Estrelas", "George Lucas", 1977, TypeGenre.Adventure,
                TypeCategory.Film, 8.6));
            movies.Add(new Movie(3, "O Silêncio dos Inocentes", "Jonathan Demme", 1991, TypeGenre.Drama,
                TypeCategory.Film, 8.6));
            movies.Add(new Movie(4, "The Office", "Greg Daniels", 2005, TypeGenre.Comedy,
                TypeCategory.Series, 9.0));
            movies.Add(new Movie(5, "O Mandaloriano", "Jon Favreau", 2019, TypeGenre.Fantasy,
                TypeCategory.Series, 8.7));
            movies.Add(new Movie(6, "Alquimia das Almas", "Jonathan Demme", 2022, TypeGenre.Fantasy,
                TypeCategory.Series, 8.7));

            return View(movies);
        }

    }
}
