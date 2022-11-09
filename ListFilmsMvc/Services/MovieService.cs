using ListFilmsMvc.Data;
using ListFilmsMvc.Models;
using ListFilmsMvc.Models.ViewModels;
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

        public async Task InsertAsync(Movie obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            try
            {
                var obj = _context.Movie.Find(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Can't delete Movie/Serie.\n{e.Message}");
            }
        }

        public async Task UpdateAsync(Movie obj)
        {
            bool hasAny = await _context.Movie.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new Exception("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}
