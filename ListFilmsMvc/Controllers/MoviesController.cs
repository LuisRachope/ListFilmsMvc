using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using ListFilmsMvc.Models.ViewModels;
using ListFilmsMvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        public readonly MovieService _movieService;
        private readonly GenreServices _genreService;
        private readonly CategoryServices _categoryService;

        public MoviesController(MovieService movieService, GenreServices genreServices, CategoryServices categoryServices)
        {
            _movieService = movieService;
            _genreService = genreServices;
            _categoryService = categoryServices;
        }

        public async Task<IActionResult> Index()
        {

            var movies = await _movieService.FindAllAsync();
            var genres = await _genreService.FindAllAsync();
            var categories = await _categoryService.FindAllAsync();

            List<Movie> list = new List<Movie>();
            foreach (var obj in movies)
            {

                list.Add(new Movie(obj.Id,
                    obj.Title,
                    obj.Director,
                    obj.RealeseYear,
                    genres.FirstOrDefault(x => x.Id == obj.GenreId),
                    categories.FirstOrDefault(x => x.Id == obj.CategoryId),
                    obj.Rating)); ;
            }

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _genreService.FindAllAsync();
            var categories = await _categoryService.FindAllAsync();
            var viewModel = new MovieFormViewModel { Genres = genres, Categories = categories };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genres = await _genreService.FindAllAsync();
                var categories = await _categoryService.FindAllAsync();
                var viewModel = new MovieFormViewModel { Genres = genres, Categories = categories };
                return View(viewModel);
            }
            await _movieService.InsertAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var movie = await _movieService.FindByIdAsync(id.Value);
            var genres = await _genreService.FindAllAsync();
            var categories = await _categoryService.FindAllAsync();
            Movie obj = new Movie(movie.Id,
                movie.Title,
                movie.Director,
                movie.RealeseYear,
                genres.Find(x => x.Id == movie.GenreId),
                categories.Find(x => x.Id == movie.CategoryId),
                movie.Rating);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }


            var movie = await _movieService.FindByIdAsync(id.Value);
            var genres = await _genreService.FindAllAsync();
            var categories = await _categoryService.FindAllAsync();
            Movie obj = new Movie(movie.Id,
                movie.Title,
                movie.Director,
                movie.RealeseYear,
                genres.Find(x => x.Id == movie.GenreId),
                categories.Find(x => x.Id == movie.CategoryId),
                movie.Rating);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _movieService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Genre> genres = await _genreService.FindAllAsync();
            List<Category> categories = await _categoryService.FindAllAsync();
            MovieFormViewModel viewModel = new MovieFormViewModel { Movie = obj, Genres = genres, Categories = categories};

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel { Movie = movie };
                return View(viewModel);
            }
            if (id != movie.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _movieService.UpdateAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
