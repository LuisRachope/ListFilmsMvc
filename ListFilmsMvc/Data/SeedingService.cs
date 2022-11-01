using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Data
{
    public class SeedingService
    {
        private ListFilmsMvcContext _context;

        public SeedingService(ListFilmsMvcContext context)
        {
            _context = context;
        }
    }
}
