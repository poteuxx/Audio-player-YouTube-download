using System;
using System.IO;
using System.Text.Json;

public static class ConfigManager
{
    private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

    public static Config LoadConfig()
    {
        if (!File.Exists(configFilePath))
        {
            return new Config();
        }

        string jsonString = File.ReadAllText(configFilePath);
        return JsonSerializer.Deserialize<Config>(jsonString);
    }

    public static void SaveConfig(Config config)
    {
        string jsonString = JsonSerializer.Serialize(config);
        File.WriteAllText(configFilePath, jsonString);
    }
}

public class Config
{
    public bool IsWebView2Installed { get; set; } = false;
}