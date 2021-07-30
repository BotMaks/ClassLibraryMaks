using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    class rm:Feature
    {
        public rm(string[] help) : base(help) { }

        public void Work(string target) 
        {
            if (Directory.Exists(target)) 
            {
                try
                {
                    Directory.Delete(target);
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (File.Exists(target))
            {
                try
                {
                    File.Delete(target);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void WorkR(string target) 
        {
            if (Directory.Exists(target)) 
            {
                try 
                {
                    Directory.Delete(target, true);
                }
                catch(IOException e) 
                { 
                    Console.WriteLine(e.Message); 
                }
            }
        }
    }
}
