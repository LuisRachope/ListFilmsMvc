using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Genre()
        {
        }

        public Genre(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
