using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using TaskManagerProject.Entities;

namespace TaskManagerProject.Helpers
{
    public static class JsonHelper
    {
        public static void Convert<T>(List<T> list, string fileName)
        {
            try
            {
                string fullPath = GetPath(fileName);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
                };

                string jsonString = JsonSerializer.Serialize(list, options);
                File.WriteAllText(fullPath, jsonString);

                Console.WriteLine("Gravado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("pode não! tem coisa errada ai");
            }
        }

        public static T Deconvert<T>(string fileName)
        {
            string fullPath = GetPath(fileName);

            if (!File.Exists(fullPath))
                return default;

            string jsonString = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<T>(jsonString);
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
//só pra alterar