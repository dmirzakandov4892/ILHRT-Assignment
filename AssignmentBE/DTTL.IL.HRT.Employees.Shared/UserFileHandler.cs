using System;
using System.Text.Json;

namespace DTTL.IL.HRT.Employees.Shared
{
    public class UsersFileHandler
    {
        private readonly string _fileNameCsv;
        private readonly string _fileNameUsers;
        private readonly string _fileNameDaily;
        public UsersFileHandler(string filePath, string filePathDaily)
        {
            _fileNameUsers = filePath;
            _fileNameDaily = filePathDaily;
            _fileNameCsv = filePathDaily.Replace("json", "csv");
        }

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,

        };

        public List<User> ReadUsers()
        {
            return ReadUsers(_fileNameUsers);
        }

        public List<User> ReadUsersDaily()
        {
            return ReadUsers(_fileNameDaily);
        }

        private List<User> ReadUsers(string filename)
        {

            List<User> users = new();
            try
            {
                string json = readFromFile(filename);
                users = JsonSerializer.Deserialize<List<User>>(json, _options);
            }
            catch (Exception ex)
            {

            }
            return users;
        }

        public void WriteUsers(object obj)
        {
            var options = new JsonSerializerOptions(_options);
            var jsonString = JsonSerializer.Serialize(obj, options);
            writeToFile(jsonString, _fileNameUsers);
        }

        public void WriteUsersDaily(object obj)
        {
            var options = new JsonSerializerOptions(_options);
            var jsonString = JsonSerializer.Serialize(obj, options);
            writeToFile(jsonString, _fileNameDaily);

            var c = (obj as List<User>);
            var str = c.FirstOrDefault()?.ToCSVFormatHeader();
            foreach (var u in c)
                str += "\n" + u.ToCSVFormat();
            writeToFile(str, _fileNameCsv);
        }


        public void writeToFile(string str, string fileName)
        {
            File.WriteAllText(fileName, str);
        }

        public string readFromFile(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return json;
        }
    }
}

