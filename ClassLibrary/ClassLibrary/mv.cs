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
                System.IO.File.Move(target, destination);
            }
            else if (Directory.Exists(target)) 
            {
                System.IO.Directory.Move(target, destination); 
            }
            else { Console.WriteLine("Podany plik/katalog do przeniesienia nie istnieje"); }
        }

    }
}
