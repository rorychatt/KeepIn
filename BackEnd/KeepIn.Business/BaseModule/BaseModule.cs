using System.Text.Json;
using KeepIn.Business.Contracts;

namespace KeepIn.Business.BaseModule;

public abstract class BaseModule : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";
    public required IModule.Properties Properties { get; init; }

    public Dictionary<string, string> Dependencies { get; init; } = new();

    protected BaseModule()
    {
        try
        {
            ReadInConfigForModule();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ReadInConfigForModule()
    {
        var className = GetType().Name;
        var configFileName = $"{className}.config.json";
        var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName);

        if (File.Exists(configFilePath))
        {
            var jsonContent = File.ReadAllText(configFilePath);
            var configData = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonContent);
            if (configData == null) return;
            foreach (var kvp in configData)
            {
                Dependencies[kvp.Key] = kvp.Value;
            }
        }
        else
        {
            throw new FileNotFoundException($"Configuration file '{configFileName}' not found.");
        }
    }
}