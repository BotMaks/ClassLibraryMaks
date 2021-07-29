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
            if (File.Exists(target))
            {
                //string path = Directory.GetCurrentDirectory();
                File.Copy(target, destination, true);
            }
            else { Console.WriteLine("Podany plik do skopiowania nie istnieje"); }
            
        }
        public void WorkR(string target, string destination) 
        {
            if (Directory.Exists(target))
            {
                string[] temp = target.Split('/');
                string name = temp[temp.Length - 1];
                destination += name;
                Directory.CreateDirectory(destination);
                //DirectoryCopy(target, destination, true);
            }
            else { Console.WriteLine("Podany katalog do skopiowania nie istnieje"); }
        }
    }
}
