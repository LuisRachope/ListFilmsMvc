using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Services
{
    public class GenreServices
    {
        private readonly ListFilmsMvcContext _context;

        public GenreServices(ListFilmsMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genre.ToListAsync();
        }
    }
}
