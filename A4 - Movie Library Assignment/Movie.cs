

using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;

namespace A4___Movie_Library_Assignment
{
    public class Movie
    {

        [Name("movieId")]
        public string movieId { get; set; }

        [Name("title")]
        public string title { get; set; }

        [Name("genres")]
        public string genres { get; set; }


        public Movie(string x, string y, string z)
        {
            movieId = x;
            title = y;
            genres = z;
        }

        public override string ToString()
        {
            return $"{movieId}, {title}, {genres}";
        }

   
        
        
        
        
        
    }
}