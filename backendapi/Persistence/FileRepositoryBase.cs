using System;
using System.Text.Json;

namespace backendApi.Persistence
{
    public abstract class FileRepositoryBase<T>
    {
        protected readonly string _filePath;

        public FileRepositoryBase(string filePath)
        {
            _filePath = filePath;
        }

        protected List<T> ReadData()
        {
            if (!File.Exists(_filePath))
                return new List<T>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new();
        }

        protected void WriteData(List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
