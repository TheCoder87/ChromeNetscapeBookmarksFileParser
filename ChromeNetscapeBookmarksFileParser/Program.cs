using BookmarksManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleBookmarksFileParseToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Test
                string fileToParse = "NewTL.html";
                //Read bookmarks from file
                using (var file = File.OpenRead(fileToParse))
                {
                    var reader = new NetscapeBookmarksReader();
                    //supports encoding detection when reading from stream
                    var bookmarks = reader.Read(file);
                    foreach (var b in bookmarks.AllLinks)
                    {
                        Console.WriteLine("Type: {0}, Title: {1}, Url:{2}", b.GetType().Name, b.Title, b.Url);
                    }
                }
                #endregion                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }


    }
}
