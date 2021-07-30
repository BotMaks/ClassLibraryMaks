using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public partial class Features
    {
        static Dictionary<string, Feature> features = new Dictionary<string, Feature>();
        public Features()
        {
            features.Add("cp", new cp(new string[] { "cp [ścieżka do plik1] [ścieżka do plik2] - kopiuje podany plik do podanego miejsca", "cp -r [ścieżka do katalog1] [ścieżka do katalogu2] - kopiuje podany folder do podanego miejsca" }));
            features.Add("mv", new mv(new string[] { "mv [ścieżka do plik1/folder1] [ścieżka do plik2/folder2] - kopiuje podany plik/folder do podanego miejsca" }));
            features.Add("rm", new rm(new string[] { "rm [ścieżka do plik1/folder1] - usuwa podany plik/folder", "rm -r [ścieżka do folderu] - usuwa całą strukturę we wskazanym folderze łącznie z nim samym" }));
            features.Add("gzip", new gzip(new string[] { "gzip [ścieżka do plik1] - kompresuje podany plik do GZIP", "gunzip [ścieżka do plik1] - dekompresuje podany plik z GZIP" }));
            features.Add("ls", new ls(new string[] { "ls - wyswietlenie plikow", "ls -l - nie dziala", "ls -la - wyswietlenie" +
                "wszystkich plikow, w tym ukrytych, oraz folderow" }));
            features.Add("cd", new cd(new string[] { "cd - przemieszczanie sie po sciezkach. napisz 'cd ..' aby wyjsc" +
                "z aktualnej sciezki, lub 'cd [folder]' aby wejsc do folderu."}));
            features.Add("md5sum", new md5sum(new string[] { "md5sum - wyliczenie sumy kontrolnej pliku z aktualnego folderu." +
                " Skladnia 'md5sum [file]'"}));
            features.Add("sha256sum", new sha256sum(new string[] { "sha256sum - wyliczenie sumy kontrolnej pliku" +
                "z aktualnego folderu. Skladnia 'sha256sum [file]'"}));
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
                if (com.Length > 4 || com.Length < 3) 
                { 
                    Console.WriteLine("Zła składnia"); 
                    return; 
                }
                if (com[1] == "-r")
                {
                    temp.WorkR(com[1], com[2]);
                    return;
                }
                if (com.Length == 4)
                {
                    Console.WriteLine("Podano zły modyfikator");
                    return;
                }
                temp.Work(com[1], com[2]);
            }
            else if(com[0] == "mv")
            {
                mv temp;
                temp = (mv)features["mv"];
                if(com.Length != 3) 
                {
                    Console.WriteLine("Zła składnia");
                    return;
                }
                temp.Work(com[1], com[2]);
            }
            else if (com[0] == "rm")
            {
                rm temp;
                temp = (rm)features["rm"];
                if(com.Length > 4)
                {
                    Console.WriteLine("Zła składnia");
                    return;
                }
                if (com[1] == "-r") 
                {
                    temp.WorkR(com[2]);
                    return;
                }
                if(com.Length == 3)
                {
                    Console.WriteLine("Podano zły modyfikator");
                    return;
                }
                temp.Work(com[2]);
            }
            else if (com[0] == "gzip" || com[0] == "gunzip")
            {
                gzip temp;
                temp = (gzip)features["gzip"];
                if(com.Length > 2) 
                {
                    Console.WriteLine("Zła składnia");
                    return;
                }
                if (com[0] == "gzip") { }
                if(com[0] == "gunzip") { }
            }
            else
            {
                Console.WriteLine("brak komendy dla " + command);
            }
        }

    }
}
