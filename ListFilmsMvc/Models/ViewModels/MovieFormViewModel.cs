using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Models.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
