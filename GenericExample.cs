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
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private List<Music>? musicList = new();
        public GenericExample()
        {
            // Save the data
            Save(path + @"/MediaMaster/Music.json", musicList);

            // Load the data depending on type
            musicList = Load<List<Music>>(path + @"/MediaMaster/Music.json");
        }

        /// <summary>
        /// Converts an Object to JSON and writes to file
        /// </summary>
        internal void Save(string path, object data)
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
}
