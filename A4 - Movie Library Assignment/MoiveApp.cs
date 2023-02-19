

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;



namespace A4___Movie_Library_Assignment 
{
    public class MovieApp
    {
        public List<string> movieList = new List<string>();
        public List<Movie> listOfMovieObjects = new List<Movie>();
        //private string file = @"C:\Users\051686\RiderProjects\A4 - Movie Library Assignment\A4 - Movie Library Assignment\Files\movies.csv";
        private string file = "Files/movies.csv";
        public void createList()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };

                using (var streamReader = new StreamReader(file))
                {
                    using (var csvReader = new CsvReader(streamReader, config))
                    {
                        listOfMovieObjects = csvReader.GetRecords<Movie>().ToList();
                        streamReader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with creating list");
                throw;
            }

        }


        public MovieApp(){}
        
        public void AddMovie(String movieId, String title, String genres)
        {
            try
            {
                Movie newMovie = new Movie(movieId, title, genres);
                listOfMovieObjects.Add(newMovie);
                movieList.Add(newMovie.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding movie to list");
                throw;
            }
        }

        public void displayList()
        {
           
            
            try
            {
                string controller = "";
                int movieCount = 0;

                while (controller != "q" && movieCount < listOfMovieObjects.Count)
                {
                    List<Movie> output = listOfMovieObjects.GetRange(movieCount, 100);
                    
                    foreach (Movie movie in output)
                    {
                        Console.WriteLine(movie);
                    }

                    Console.WriteLine($"To show next 100, press Enter. To quit, press q.");
                    movieCount += 100;

                    controller = Console.ReadLine().ToLower();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error displaying list");
                throw; 
            }
        }


        public void NewMovie()
        {
            FileStream movieFile= new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                  StreamReader sr = new StreamReader(movieFile);
                  string line = sr.ReadLine();  
                  //To get last ID
                    var lastLine = "";
                    while (sr.EndOfStream == false)
                    {
                        lastLine = sr.ReadLine();
                    }
                    var columnSplitForId = Regex.Split(lastLine, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");;
                    string movieId = columnSplitForId[0];
                    int nextMovieId = Convert.ToInt32(movieId) + 1;
                    string nextMovieIdString = nextMovieId.ToString();
                    
                    sr.Close();
                    movieFile.Close();

                    
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Enter Title: ");
                    string title = Console.ReadLine();
                    string titleFormat = title;
                    if (title.Contains(","))
                    {
                        titleFormat = $"\"{title}\"";
                    }
                    else
                    {
                        titleFormat = title;
                    }
                    
                    while (listOfMovieObjects.FirstOrDefault(o => o.title == titleFormat) != null)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Duplicate Movie. Enter Title: ");
                         title = Console.ReadLine();
                         titleFormat = title;
                        if (title.Contains(","))
                        {
                            titleFormat = $"\"{title}\"";
                        }
                        else
                        {
                            titleFormat = title;
                        }  
                    }
                    
                    string genreList = "";
                    string genre = "";
                    Console.WriteLine("Enter genre: ");
                    genreList = Console.ReadLine().ToLower();
                    genre = genre + genreList;

                    while (genreList != "done")
                    {
                        Console.WriteLine("Enter genre. Type done to quit: ");
                         genreList = Console.ReadLine().ToLower();
                         if (genreList != "done")
                         {
                             genre =  genre +"|"+ genreList;
                         }
                         else
                         {

                         }
                    }
                    
                    string newMovie = nextMovieId + "," + titleFormat + "," + genre;
                    AddMovie(nextMovieIdString, titleFormat , genre);

                    try
                    {

                        StreamWriter sw = new StreamWriter(file, true);
                        newMovie = nextMovieId + "," + titleFormat + "," + genre;
                        sw.WriteLine(newMovie);
                        sw.Close();
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with writing file");
                        throw;
                    }

                    Console.WriteLine($"New Movie Add: {newMovie}");
 
                    


            
                 
        }
        
        
        
        
        
        
    }
}