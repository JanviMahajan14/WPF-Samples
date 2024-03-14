using Microsoft.Windows.Plugins.Endpoints;
using System.Diagnostics;
using System.IO.Pipes;
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
         [Endpoint]
         public Result SayGoodbye(string personName)
         {
             string output = Execution.Current.ResolveString("SayGoodbyeOutput", personName);
             return new (output) { DescriptionForModel = $"Successfully said goodbye to {personName}." };
         }

        [Endpoint]
        public Result StickyNotes(string message)
        {
            //string output = Execution.Current.ResolveString("message", message);
            string output = message;

            var p = new Process();
            p.StartInfo.FileName = "D:\\projects\\Hackathon\\WPF-Samples\\Sample Applications\\StickyNotesDemo\\bin\\Debug\\net8.0-windows\\StickyNotesDemo.exe"; // Replace with the path to your second application
            p.Start();

            //Task.Delay(1000).Wait();

            //Client
            var client = new NamedPipeClientStream("PipesOfPiece");
            client.Connect();
            //StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            writer.WriteLine(output);
            writer.Flush();
            //Console.WriteLine(reader.ReadLine());

            return new(output) { DescriptionForModel = $"Successfully opened sticky notes: {message}." };
        }
    }
}
