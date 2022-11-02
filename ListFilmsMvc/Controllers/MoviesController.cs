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
        private readonly ListFilmsMvcContext _context;

        public MoviesController(ListFilmsMvcContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Movie> movies = _context.Movie.ToList();

            return View(movies);
        }

    }
}
