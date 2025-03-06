using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace EventManagement.Models
{
    internal class ConservationDataAuthorizedUser
    {       

        static string GetFilePath()
        {
            //Получаем путь к папке appData, SpecialFolder - перечсиление содержащее системные пути к папкам
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //Формируем путь к каталогу EventManagemetn
            string appFolder = Path.Combine(appData, "EventManagemetn");
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder); //Если его не существует создаём, данный каталог по пути
            }

            //Возвращаем сформированный путь к файлу Data.json, что ещё не был создан
            return Path.Combine(appFolder, "Data.json");
        }
        

        public static void ConservationData(string token)
        {
            string pathToFile = GetFilePath();
            string json = JsonConvert.SerializeObject(token);
            File.WriteAllText(pathToFile, json);
        }

        public static void DeleteData()
        {
            string pathToFile = GetFilePath();
            if (File.Exists(pathToFile))
            {
                File.Delete(pathToFile);
            }
        }

        public static string? LoadUser()
        {
            string pathToFile = GetFilePath();
            if (File.Exists(pathToFile))
            {
                string json = File.ReadAllText(pathToFile);
                return JsonConvert.DeserializeObject<string>(json);
            }
            else
                return null;
        }

    }
}
