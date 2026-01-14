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
            var adapter = new ConsoleAdapter();
            var frame = VisualHelper.CreateFrame(stream, new Size(80, 40), CellAspectRatio.Console, new NoTexturizer());
            
            adapter.RenderFrame(frame);

            Console.ReadLine();
        }
    }
}
