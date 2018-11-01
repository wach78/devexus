using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace devexus
{
    class XML
    {
        private XDocument xmlDoc;
        /// <summary>
        /// initialize the XML object and create a XDocument
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public XML(string xmlFilePath)
        {
            try
            {
                xmlDoc = XDocument.Load(xmlFilePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Return all Person elements in the file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<XElement> GetElementFromXML(string ele)
        {
            try
            {
                return xmlDoc.Root.Descendants(ele);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}







