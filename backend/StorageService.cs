using System.Text.Json;

public static class StorageService
{
    public static void SaveToFile<T>(T data, string filePath)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static T? LoadFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}
