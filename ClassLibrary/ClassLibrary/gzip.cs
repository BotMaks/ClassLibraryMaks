using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ClassLibrary
{
    class gzip:Feature
    {
        public gzip(string[] help):base(help) { }

        public void WorkGzip(string target) 
        {
            if (File.Exists(target)) {
                FileInfo file = new FileInfo(target);
                using(FileStream original = file.OpenRead()) 
                {
                    if ((File.GetAttributes(file.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & file.Extension != ".gz") 
                    {
                        using (FileStream compressed = File.Create(file.FullName + ".gz"))
                        {
                            using(GZipStream compressStream = new GZipStream(compressed, CompressionMode.Compress))
                            {
                                original.CopyTo(compressStream);
                            }
                        }
                    }
                }   
            }
            else if (Directory.Exists(target))
            {
                Console.WriteLine("Nie można skompresować folderu");
            }
            else
            {
                Console.WriteLine("Podany plik ne istnieje");
            }


        }
        public void WorkGunzip(string target) 
        {
            if (File.Exists(target))
            {
                FileInfo file = new FileInfo(target);
                using (FileStream original = file.OpenRead())
                {
                    string name = file.FullName;
                    string newname = name.Remove(name.Length - file.Extension.Length);

                    using(FileStream decompres = File.Create(newname))
                    {
                        using (GZipStream decompresStream = new GZipStream(original, CompressionMode.Decompress))
                        {
                            decompresStream.CopyTo(decompres);
                        }
                    }

                }

            }
            else if (Directory.Exists(target))
            {
                Console.WriteLine("Podano folder, podaj plik do skompresowania");
            }
            else
            {
                Console.WriteLine("Podany plik nie istnieje");
            }
        }
    }
}
