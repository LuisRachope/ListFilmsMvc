using ListFilmsMvc.Models;
using ListFilmsMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenreServices _genreService;

        public GenresController(GenreServices genreServices)
        {
            _genreService = genreServices;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _genreService.FindAllAsync();
            return View(obj);
        }
    }
}
