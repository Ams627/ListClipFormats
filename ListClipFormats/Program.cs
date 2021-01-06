using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListClipFormats
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                System.Windows.Forms.IDataObject content = Clipboard.GetDataObject();
                string[] formats = content.GetFormats();
                foreach (var f in formats)
                {
                    Console.WriteLine($"{f}");
                }

                if (Clipboard.ContainsImage())
                {
                    var clipboardImage = Clipboard.GetImage();
                    string imagePath = @"r:\temp\images\png\p1.png";
                    clipboardImage.Save(imagePath);
                }
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
