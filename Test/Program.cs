using NetAF.Adapters;
using NetAF.Assets;
using NetAF.Imaging;
using NetAF.Imaging.Textures;
using NetAF.Rendering.Console;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var displaySize = new Size(80, 50);
            var adapter = new SystemConsoleAdapter();
            
            var frame = new GridVisualFrame(VisualHelper.FromImage(@"C:\Test\l.jpg", displaySize, CellAspectRatio.Console));
            adapter.RenderFrame(frame);

            adapter.WaitForAcknowledge();
            adapter.WaitForAcknowledge();
        }
    }
}
