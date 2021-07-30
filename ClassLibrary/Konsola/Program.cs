using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;


namespace Konsola
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Features feat = new Features();
            string com;
            Console.WriteLine("Zadanie dodatkowe \n----------------");
            do
            {
                com = Console.ReadLine();
                com = com.Trim();
                string[] help = com.Split();
                if (help[0] == "help" || help[0] == "?")
                {
                    feat.GetFeatureHelp(com);
                }
                else if (com != "" || com != null) 
                {
                    feat.CommandHandler(com);
                }
                if(com == "exit") { exit = true; }

            } while (exit == false);
        }
    }
}
