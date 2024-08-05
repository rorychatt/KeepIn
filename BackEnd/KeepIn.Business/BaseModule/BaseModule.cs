using System.Text.Json;
using KeepIn.Business.Contracts;

namespace KeepIn.Business.BaseModule;

public abstract class BaseModule : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";
    public IModule.Properties? Properties { get; private set; }

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
        var templateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BaseModule.config.json");

        if (!File.Exists(configFilePath))
        {
            if (File.Exists(templateFilePath))
            {
                File.Copy(templateFilePath, configFilePath);
            }
            else
            {
                throw new FileNotFoundException($"Template configuration file '{templateFilePath}' not found.");
            }
        }

        var jsonContent = File.ReadAllText(configFilePath);
        Properties = JsonSerializer.Deserialize<IModule.Properties>(jsonContent);
    }
}