using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Wiki.App_Code
{
    public class Model
    {
        private static string file = @"C:\Users\KDRENSKI\source\repos\Wiki\Wiki\App_Data\Wiki.xml";
        private static XDocument xDoc = XDocument.Load(file);

        private Model()
        {
        }

        public static void CreateEntry(WikiEntry entry)
        {
            XElement wikiEntry =
                    new XElement("WikiEntry",
                            new XAttribute("Id", Guid.NewGuid()),
                            new XAttribute("CreatedBy", "kaloyan@kukui.com"),
                            new XAttribute("CreatedAt", DateTimeOffset.UtcNow.ToString()),
                            new XAttribute("UpdatedBy", "kaloyan@kukui.com"),
                            new XAttribute("UpdatedAt", DateTimeOffset.UtcNow.ToString()),
                            new XAttribute("CategoryIds", string.Join(",", from x in entry.Categories select x.Id)),
                            new XAttribute("TagIds", string.Join(",", from x in entry.Tags select x.Id)),
                        new XElement("Title", entry.Title),
                        new XElement("Content", new XCData(entry.Content))
                    );
            xDoc.Root.Element("WikiEntries").Add(wikiEntry);
            xDoc.Save(file);
        }
    }
}