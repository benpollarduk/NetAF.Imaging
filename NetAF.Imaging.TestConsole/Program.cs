using NetAF.Imaging.Textures;
using NetAF.Targets.Console;

namespace NetAF.Imaging.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "Tree.jpg";

            var fileBytes = File.ReadAllBytes(path);
            var stream = new MemoryStream(fileBytes);

            var frame = VisualHelper.CreateFrame(stream, new(80, 25), CellAspectRatio.Square, new BrightnessTexturizer());

            var adapter = new ConsoleAdapter();
            adapter.RenderFrame(frame);

            Console.ReadLine();
        }
    }
}
