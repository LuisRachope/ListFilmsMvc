using ListFilmsMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListFilmsMvc.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }

        [Display(Name = "Realese Year")]
        public int RealeseYear { get; set; }
        public TypeGenre Genre { get; set; }
        public TypeCategory Category { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double Rating { get; set; }

        public Movie()
        {
        }

        public Movie(int id, string title, string director, int releaseYear, TypeGenre genre, TypeCategory category, double rating)
        {
            Id = id;
            Title = title;
            Director = director;
            RealeseYear = releaseYear;
            Genre = genre;
            Category = category;
            Rating = rating;
        }
    }
}
