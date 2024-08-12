using System.Text.Json;
using KeepIn.Business.Contracts;

namespace KeepIn.Business.BaseModule;

public class BaseModule : IModule
{
    public string Id { get; init; } = $"module_{Guid.NewGuid()}";
    public ModuleProperties Properties { get; private set; } = null!;

    public BaseModule()
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
        var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, className, configFileName);

        if (!File.Exists(configFilePath))
        {
            throw new FileNotFoundException(
                $"Configuration file for {className} not found. Looked at {configFilePath}");
        }

        var jsonContent = File.ReadAllText(configFilePath);
        //Todo: better checks here
        Properties = JsonSerializer.Deserialize<BaseModuleConfigJson>(jsonContent)!.Properties!;
    }
    
}