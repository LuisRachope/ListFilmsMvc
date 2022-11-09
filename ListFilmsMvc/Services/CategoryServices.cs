using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Services
{
    public class CategoryServices
    {
        public readonly ListFilmsMvcContext _context;

        public CategoryServices(ListFilmsMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.ToListAsync();
        }
    }
}
