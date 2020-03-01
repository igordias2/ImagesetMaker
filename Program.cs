using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files;

            if (Directory.Exists(args[0]))
            {
                files = Directory.GetFiles(args[0]);

                foreach (var f in files)
                    CreateImageset(args[0], f);

            }
        }
        static void CreateImageset(string folder, string file)
        {

            string[] f = file.Split('/');
            if (f.Contains(".DS_Store"))
                return;
            string fN = f.Last().Split('.')[0];
            Console.WriteLine(fN);
            DirectoryInfo folderN = Directory.CreateDirectory(folder + "/" + fN + ".imageset");
            File.Move(file, folderN.FullName+ "/" +f.Last());

            FileStream fs = File.Create(folderN.FullName + "/Contents.json");
            string fileName = fs.Name;
            fs.Close();
            fs.Dispose();

            File.WriteAllText(fileName, GetDataString(f.Last()));


            
            // for (int i = 0; i < f.Length; i++)
            // {
            //     if(f[i] != ".DS_Store")
            //         if(f[i] != ".")
            //             if(f[i] != folder)
            //             {

            //                DirectoryInfo folderN = Directory.CreateDirectory(folder + file + ".imageset");
            //             }
            //                 //Console.Write(f[i]);
            // }
        }
        static string GetDataString(string filename)
        {
            const string quote = "\"";  
            return @"{
                "+  quote + "images"+  quote + @" : [
                    {
                    "+  quote + @"idiom"+  quote + @" : "+  quote + @"universal"+  quote + @",
                    "+  quote + @"filename"+  quote + @" : " + quote+ filename + quote + @",
                    "+  quote + @"scale"+  quote + @" : "+  quote + @"1x"+  quote + @"
                    },
                    {
                    "+  quote + @"idiom"+  quote + @" : "+  quote + @"universal"+  quote + @",
                    "+  quote + @"filename"+  quote + @" : " + quote+ filename + quote + @",
                    "+  quote + @"scale"+  quote + @" : "+  quote + @"2x"+  quote + @"
                    },
                    {
                    "+  quote + @"idiom"+  quote + @" : "+  quote + @"universal"+  quote + @",
                    "+  quote + @"filename"+  quote + @" : " + quote+ filename + quote + @",
                    "+  quote + @"scale"+  quote + @" : "+  quote + @"3x"+  quote + @"
                    },
                    {
                    "+  quote + @"idiom"+  quote + @" : "+  quote + @"watch"+  quote + @",
                    "+  quote + @"filename"+  quote + @" : " + quote+ filename + quote + @",
                    "+  quote + @"scale"+  quote + @" : "+  quote + @"2x"+  quote + @"
                    }
            ],
            "+  quote + @"info"+  quote + @" : {
                "+  quote + @"version"+  quote + @" : 1,
                "+  quote + @"author"+  quote + @" : "+  quote + @"xcode"+  quote + @"
            }
            }";
        }


    }
    class json
    {

        public List<images> images = new List<images>();
        public info info;

    }
    public class images
    {
        public string idiom;
        public string filename;
        public string scale;
    }
    public class info
    {
        public int version = 1;
        public string author = "xcode";
    }
}
