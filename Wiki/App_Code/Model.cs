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
            foreach (var item in entry.Categories)
            {
                string categoryId = "";

                // Category exists
                if (xDoc.Root.Element("Categories").Elements("Category").Any(c => c.Attribute("Text").Value == item.Text))
                {
                    continue;
                }
                else
                {
                    // Generate new Category
                    categoryId = (Convert.ToInt32(xDoc.Root.Element("Categories").Elements("Category").Last().Attribute("Id").Value) + 1).ToString();

                    xDoc.Root.Element("Categories").Add(
                        new XElement("Category", 
                            new XAttribute("Id", categoryId), 
                            new XAttribute("Text", item.Text))
                        );
                }
            }

            foreach (var item in entry.Tags)
            {
                string tagId = "";

                // Tag exists
                if (xDoc.Root.Element("Tags").Elements("Tag").Any(c => c.Attribute("Text").Value == item.Text))
                {
                    continue;
                }
                else
                {
                    // Generate new Tag
                    tagId = (Convert.ToInt32(xDoc.Root.Element("Tags").Elements("Tag").Last().Attribute("Id").Value) + 1).ToString();
                    xDoc.Root.Element("Tags").Add
                            (
                                new XElement("Tag", 
                                    new XAttribute("Id", tagId),
                                    new XAttribute("Text", item.Text))
                            );
                }
            }

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

        public static void DeleteEntry(string id)
        {
            var entry = xDoc.Root.Element("WikiEntries")
                                 .Elements("WikiEntry")
                                 .Where(e => e.Attribute("Id").Value == id).FirstOrDefault();

            if (entry == null)
            {
                return;
            }
            else
            {
                entry.Remove();
            }
        }
    }
}