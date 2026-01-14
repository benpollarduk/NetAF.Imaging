using NetAF.Assets;
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

            var frame = VisualHelper.CreateFrame(stream, new Size(80, 40), CellAspectRatio.Console, new BrightnessTexturizer());

            var adapter = new ConsoleAdapter();
            adapter.RenderFrame(frame);

            Console.ReadLine();
        }
    }
}
