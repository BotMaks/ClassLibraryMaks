using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class mv:Feature
    {
        public mv(string[] help) : base(help) { }

        public void Work(string target, string destination) 
        {
            if (File.Exists(target)) 
            {
                if (!Directory.Exists(destination)) 
                {
                    Console.WriteLine("Podana ścieżka do której chcesz przenieść plik nie istnieje");
                    return;
                }
                System.IO.File.Move(target, destination);
            }
            else if (Directory.Exists(target)) 
            {
                if (Directory.Exists(destination)) 
                {
                    Console.WriteLine("Podana ścieżka do której chcesz przenieśc folder nie istnieje");
                    return;
                }
                System.IO.Directory.Move(target, destination); 
            }
            else { Console.WriteLine("Podany plik/katalog do przeniesienia nie istnieje"); }
        }

    }
}
