using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Wiki.App_Code
{
    public class WikiDAL
    {
        private XDocument xDoc { get; set; }
        private List<WikiEntry> Entries = new List<WikiEntry>();

        public WikiDAL(string file)
        {
            xDoc = XDocument.Load(file);
        }

        public void Add(WikiEntry entry)
        {
            if (entry == null)
            {
                throw new NullReferenceException("Null");
            }
            Entries.Add(entry);
            entry.Status = EntityStatus.Inserted;
        }

        public void Save()
        {
            if (Entries == null)
            {
                throw new NullReferenceException("Null");
            }

            foreach (var entry in Entries)
            {
                if (entry.Status == EntityStatus.Inserted)
                {
                    Model.CreateEntry(entry);
                }
                else if (entry.Status == EntityStatus.Updated)
                {
                  //Model.UpdateEntry(entry);   
                }
                else if (entry.Status == EntityStatus.Deleted)
                {
                    Model.DeleteEntry(entry.Id);
                }
            }
        }
    }
}