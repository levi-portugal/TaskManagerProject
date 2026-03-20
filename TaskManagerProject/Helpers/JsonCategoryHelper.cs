using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace TaskManagerProject.Helpers
{
    public class JsonCategoryHelper
    {

        public static T DeconvertCategory<T>(string fileName)
        {
            // tirar try catch
            // validar se o arquivo ta vazio - perguntar a emmanuel


            
                string fullPath = GetPath(fileName);

                if (!File.Exists(fullPath))
                    return default;

                var defaultList = Activator.CreateInstance<T>();

                string jsonString = File.ReadAllText(fullPath);

                if (jsonString == "" || jsonString == null)
                {
                    return defaultList;
                }

                return JsonSerializer.Deserialize<T>(jsonString);
            

        }

        public static void ConvertCategory<T>(List<T> list, string fileName)
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
