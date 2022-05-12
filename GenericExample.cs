using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericTypeT
{
    internal class GenericExample
    {
        Data? d = new();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //private List<Music>? musicList = new();
        //private List<Movie>? movieList = new();

        //private List<Base> baseList = new();
        //private List<Base>? base2List;

        public GenericExample()
        {
            d.musicList.Add(new Music { Name = "Fields of Gold", Artist = "Sting", Id = 1 });
            d.movieList.Add(new Movie { Id = 13, Name = "Moon", MovieGenre = 1 });

            #region
            //baseList.AddRange(d.musicList);
            //baseList.AddRange(movieList);

            //foreach (var item in baseList)
            //{
            //    if (item.GetType() == typeof(Music))
            //    {
            //        Music musicItem = (Music)item;
            //        Console.WriteLine($"{musicItem.Name}, {musicItem.Artist}");
            //    }
            //    else
            //    {
            //        Movie movieItem = (Movie)item;
            //        Console.WriteLine($"{movieItem.Name}, {movieItem.MovieGenre}");
            //    }

            //}
            #endregion
            // Save the data
            Save(path + @"/Media.json", d);

            // Load the data depending on type
            d = Load<Data>(path + @"/Media.json");
        }

        /// <summary>
        /// Converts an Object to JSON and writes to file
        /// </summary>
        internal void Save<T>(string path, T data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Reads file from path and convert JSON to generic type T object
        /// </summary>
        internal T? Load<T>(string path)
        {
            string json = File.ReadAllText(path);
            T? obj = JsonSerializer.Deserialize<T>(json);
            return obj;
        }
    }

    class Data
    {
        public List<Music>? musicList { get; set; } = new();
        public List<Movie>? movieList { get; set; } = new();
    }

}
