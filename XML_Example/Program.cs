using System;
using System.Linq;
using System.Xml.Linq;

namespace XML_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("persons.xml");
            var persons = xml.Descendants("person");
            var teachers = persons.SelectMany(person => person.Elements("teacher"));
            var qualificationsContainer = teachers.SelectMany(teacher => teacher.Elements("qualifications"));
            var qualifications = qualificationsContainer.SelectMany(qualificationContainer => qualificationContainer.Elements("qualification"));
            var qualificationIds = qualifications.Select(qualification => qualification.Element("id").Value);
            var distinctQualificationIds = qualificationIds.Distinct();
            foreach (var id in distinctQualificationIds)
            {
                Console.WriteLine(id);
            }

            Console.WriteLine();
        }
    }
}