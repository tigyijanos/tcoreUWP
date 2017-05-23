using System;
using System.IO;
using TCore.UniversalApp.Helpers.Json;
using TCore.UniversalApp.Interfaces.DataOperations;

namespace TCore.UniversalApp.DataOperations
{
    public class LocalStorageService : ILocalStorageService
    {
        public string _localStorage { get; private set; }

        public LocalStorageService(string localStorageFolder = "")
        {
            if (string.IsNullOrWhiteSpace(localStorageFolder))
            {
                _localStorage = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "TCoreLocalStorage");
            }
            else
            {
                _localStorage = localStorageFolder;
            }

            if (!Directory.Exists(_localStorage))
            {
                Directory.CreateDirectory(_localStorage);
            }
        }

        public void CleanLocalStorage()
        {
            var files = Directory.GetFiles(_localStorage);

            foreach (var file in files)
            {
                File.Delete(file);
            }
        }

        public T Get<T>(Enum key)
        {
            var serialized = ReadFromDisc(key.ToString());

            var deserialized = XmlConverter.Deserialize<T>(serialized);

            return deserialized;
        }

        public void Insert<T>(Enum key, T value)
        {
            var serialized = XmlConverter.Serialize<T>(value);

            WriteToDisc(key.ToString(), serialized);
        }

        public void InValidate(Enum key)
        {
            var filePath = Path.Combine(_localStorage, key.ToString());

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void WriteToDisc(string fileName, string content)
        {
            var filePath = Path.Combine(_localStorage, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = new StreamWriter(new FileStream(filePath, FileMode.CreateNew)))
            {
                writer.Write(content);
                writer.Flush();
            }
        }

        private string ReadFromDisc(string fileName)
        {
            string content = "";

            var filePath = Path.Combine(_localStorage, fileName);

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
            }

            return content;
        }

    }
}
