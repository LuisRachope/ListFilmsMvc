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

        public async Task<Genre> FindByIdAsync(int id)
        {
            return _context.Genre.FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public async Task InsertAsync(Genre obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var obj = _context.Genre.Find(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete Genre.\n{e.Message}");
            }
        }
    }
}
