using System.Text.Json;
using KeepIn.Business.Contracts;

namespace KeepIn.Business.BaseModule;

public abstract class BaseModule : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";

    public IModule.Properties Properties { get; private set; } = new()
    {
        Name = "Base Module",
        Version = "1.0.0"
    };

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
            var configData = JsonSerializer.Deserialize<IModule.Properties>(jsonContent);
            if (configData != null)
            {
                Properties = configData;
            }
        }
        else
        {
            throw new FileNotFoundException($"Configuration file '{configFileName}' not found.");
        }
    }
}