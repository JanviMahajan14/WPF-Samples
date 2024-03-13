using Microsoft.Windows.Plugins.Endpoints;
using System.Text.Json.Serialization;

namespace WindowsPluginTemplate
{
    [WindowsCopilotPlugin]
    public sealed class MyPlugin
    {
        [Endpoint]
        public Result SayHello(string personName)
        {
            string output = Execution.Current.ResolveString("SayHelloOutput", personName);
            return new(output) { DescriptionForModel = $"Successfully said hello to {personName}." };
        }

        // Add more functions to your plugin by using the [Endpoint] attribute:
        // [Endpoint]
        // public Result SayGoodbye(string personName)
        // {
        //     string output = Execution.Current.ResolveString("SayGoodbyeOutput", personName);
        //     return new (output) { DescriptionForModel = $"Successfully said goodbye to {personName}." };
        // }
    }
}
