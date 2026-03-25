/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace TaskManagerProject.Helpers
{
    public class JsonUserHelper
    {
        public static T DeconvertUser<T>(string fileName) where T : new()
        {
            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
                return new T();

            string jsonString = File.ReadAllText(fullPath);

            if (string.IsNullOrWhiteSpace(jsonString))
                return new T();

            return JsonSerializer.Deserialize<T>(jsonString) ?? new T();
        }

        public static void ConvertUser<T>(List<T> list, string fileName)
        {
            try
            {
                string fullPath = GetPath(fileName);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                };

                string jsonString = JsonSerializer.Serialize(list);
                File.WriteAllText(fullPath, jsonString);

                Console.WriteLine("Gravado com sucesso!");
            }
            catch (Exception ex)
            {

                Console.WriteLine("pode não! tem coisa errada ai");
            }
        }

        public static string GetPath(string fileName)
        {
            string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string destinationFolder = Path.Combine(rootFolder, "JsonData");

            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }

            string fullPath = Path.Combine(destinationFolder, fileName);

            return fullPath;
        }
    }
}
*/