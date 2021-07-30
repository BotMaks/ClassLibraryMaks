using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class cp:Feature
    {
        public cp(string[] help):base(help) { }

        public void Work(string target, string destination) 
        {
            if (!File.Exists(target))
            {
                Console.WriteLine("Podany plik do skopiowania nie istnieje");
                return;
            }
            if (Directory.Exists(destination)) 
            {
                Console.WriteLine("Podana ścieżka do której chcesz skopiowac plik nie istnieje");
                return;
            }
            File.Copy(target, destination, true);
            
        }
        public void WorkR(string target, string destination) 
        {
            if (!Directory.Exists(target))
            {
                Console.WriteLine("Podany katalog do skopiowania nie istnieje");
                return;
            }
            if (!Directory.Exists(destination)) 
            {
                Console.WriteLine("Podana ścieżka do której chcesz skopiowac folder nie istnieje");
                return;
            }
            string[] temp = target.Split('/');
            string name = temp[temp.Length - 1];
            destination += name;
            Directory.CreateDirectory(destination);
        }
    }
}
