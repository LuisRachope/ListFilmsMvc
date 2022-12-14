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

        [Display(Name = "Genre")]
        public Genre TypeGenre { get; set; }
        public int GenreId { get; set; }

        [Display(Name = "Category")]
        public Category TypeCategory { get; set; }
        public int CategoryId { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1}")]
        public double Rating { get; set; }

        public Movie()
        {
        }

        public Movie(int id, string title, string director, int releaseYear, Genre genre, Category category, double rating)
        {
            Id = id;
            Title = title;
            Director = director;
            RealeseYear = releaseYear;
            TypeGenre = genre;
            TypeCategory = category;
            Rating = rating;
        }

    }
}
