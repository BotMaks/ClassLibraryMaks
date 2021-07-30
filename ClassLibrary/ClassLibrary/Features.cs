using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Features
    {
        static Dictionary<string, Feature> features = new Dictionary<string, Feature>();
        public Features()
        {
            features.Add("cp", new cp(new string[] { "cp [ścieżka do plik1] [ścieżka do plik2] - kopiuje podany plik do podanego miejsca", "cp -r [ścieżka do katalog1] [ścieżka do katalogu2] - kopiuje podany folder do podanego miejsca" }));
            features.Add("mv", new mv(new string[] { "mv [ścieżka do plik1/folder1] [ścieżka do plik2/folder2] - kopiuje podany plik/folder do podanego miejsca" }));
        }

        public void GetFeatureHelp(string command)
        {
            string[] com = command.Split();
            if (features.ContainsKey(com[1]))
            {
                //Console.WriteLine(features[com[1]]);
                features[com[1]].GetHelp();
            }
            else
            {
                Console.WriteLine("Brak komendy");
            }
        }

        public void GetHelp()
        {
            string[] temp = new string[1];
            features.Keys.CopyTo(temp, 0);
            foreach (string key in temp)
                Console.WriteLine(key);
        }

        public void CommandHandler(string command)
        {
            string[] com = command.Split(' ');
            if (com[0] == "cp")
            {
                cp temp;
                temp = (cp)features["cp"];
                if (com[1] == "-r")
                {
                    temp.WorkR(com[1], com[2]);
                    return;
                }
                else if (com.Length == 4)
                {
                    Console.WriteLine("Podano zły modyfikator");
                    return;
                }
                temp.Work(com[1], com[2]);
            }
            else
            {
                Console.WriteLine("brak komendy dla " + command);
            }
        }

    }
}
