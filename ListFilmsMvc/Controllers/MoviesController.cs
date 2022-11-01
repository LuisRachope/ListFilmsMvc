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

            return View(movies);
        }

    }
}
