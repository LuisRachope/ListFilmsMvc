using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Services
{
    public class MovieService
    {
        private readonly ListFilmsMvcContext _context;

        public MovieService(ListFilmsMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> FindAllAsync()
        {
            return await _context.Movie.ToListAsync();
        }
    }
}
