using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace devexus
{
    class Listhandler
    {
        /// <summary>
        /// Create a Person object and add it to List
        /// </summary>
        /// <param name="indata"></param>
        /// <param name="p"></param>
        public static void AddPersonToList(IEnumerable<XElement> indata, List<Person> p)
        {
            try
            {
                foreach (var item in indata)
                {
                    // ? Null Conditional Operator to Avoid NullReferenceExceptions
                    p.Add(new Person(item.Element("PersonNummer")?.Value,
                                           item.Element("Fornamn")?.Value,
                                           item.Element("Efternamn")?.Value,
                                           item.Element("Telefonnummer")?.Value,
                                           item.Element("Stad")?.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Sort Person objects in List and return the new list with no dublicates
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<Person> SortPersonList(List<Person> p)
        {
            try
            {
                return p.OrderBy(o => o.Ssn)
                        .ToList();
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("ArgumentException: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Group the list by Person's object ssn attributes and select the first element to avoid duplicates returns sorted List
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        public static List<Person> RemoveDublicate(List<Person> persons)
        {
            try
            {
                return persons.GroupBy(p => p.Ssn)
                              .Select(f => f.First())
                              .ToList();
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("ArgumentException: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine("InvalidOperationException: " + ex.Message);
                return null;
            }

        }
    }
}
