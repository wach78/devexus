using System;
using System.Linq;
using System.Collections.Generic;

namespace devexus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello devexus!");
            List<Person> persons = new List<Person>();

            //Create two XML object a  XDocument is createtd from the input files
            var xml = new XML("XMLindata\\indata1.xml");
            var xml2 = new XML("XMLindata\\indata2.xml");

            //Load data from the XDocument
            
            var indata1 = xml.GetElementFromXML("Person");
            var indata2 = xml2.GetElementFromXML("Person");

            //Read the data to a List
            // It is importet  to add the indata which has the highest priority first because of how isthandler.RemoveDublicate works
            Listhandler.AddPersonToList(indata1,persons);
            Listhandler.AddPersonToList(indata2, persons);

            // remove dublicates
            var distinctedList = Listhandler.RemoveDublicate(persons);
            //sort List
            var sortedList = Listhandler.SortPersonList(distinctedList);

            string file = "outdata\\out.txt";

            //if out.txt file exits delete the file
            if (Filehandler.FileExists(file))
            {
                Filehandler.DeleteFile(file);
            }

            // ?? Enumerable.Empty<Person>() prevent nullExeptions if  sortedList is null
            // Loop through sortedList and write all person objcets to file,
            foreach (var p in sortedList ?? Enumerable.Empty<Person>())
            {
                Filehandler.WriteToFIle(p,file);
            }

            Console.ReadLine();
        }
    }
}


// Null Conditional Operator to Avoid NullReferenceExceptions ?

//https://stackoverflow.com/questions/9993172/remove-objects-with-a-duplicate-property-from-list

 