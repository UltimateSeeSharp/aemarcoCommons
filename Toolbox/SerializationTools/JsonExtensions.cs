﻿using System.IO;
using aemarcoCommons.Extensions.FileExtensions;
using Newtonsoft.Json;

namespace aemarcoCommons.Toolbox.SerializationTools
{
    public static class JsonExtensions
    {
        public static T StoreFromFile<T>(this string filePath) 
            where T: new()
        {
            if (!File.Exists(filePath)) return new T();
            
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
            }
            catch
            {
                new FileInfo(filePath).TryDelete();
                return new T();
            }
        }

        public static void StoreToFile(this string filePath, object store)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(store, Formatting.Indented));
        }
    }
}
