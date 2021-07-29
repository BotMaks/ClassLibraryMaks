using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Feature
    {
        string[] help { get; set; }
        public Feature(string[] help)
        {
            this.help = help;
        }

        public void GetHelp()
        {
            foreach (string line in help)
            {
                Console.WriteLine(line);
            }
        }

        public override string ToString()
        {
            GetHelp();
            return "";
        }
    }
}
