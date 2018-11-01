using System;
using System.Diagnostics;
using System.IO;

namespace devexus
{
    class Filehandler
    {
        /// <summary>
        ///  Check if File Exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns>true or false</returns>
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        ///  Delete a file
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("IOException" + ex.Message);
            }

        }
        /// <summary>
        /// Write a Person object to file
        /// </summary>
        /// <param name="p"></param>
        /// <param name="filename"></param>
        public static void WriteToFIle(Person p,string filename)
        {
            using (var file = new StreamWriter(filename,true))
            {
                file.Write("SSN:".PadRight(12));
                file.WriteLine(p.Ssn);
                file.Write("Firstname:".PadRight(12));
                file.WriteLine(p.Firstname);
                file.Write("Surname:".PadRight(12));
                file.WriteLine(p.Surname);
                file.Write("Phone:".PadRight(12));
                file.WriteLine(p.Phone);
                file.Write("City:".PadRight(12));
                file.WriteLine(p.City);
                file.WriteLine("*************************");
            }
        }

    }
}
