using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Wiki.App_Code;

namespace Wiki
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var categories = new List<Category>();
            var tags = new List<Tag>();

            var cat1 = new Category();
            cat1.Id = "1";
            cat1.Title = "Some Title";

            var cat2 = new Category();
            cat2.Id = "2";
            cat2.Title = "Other Title";

            categories.Add(cat1);
            categories.Add(cat2);

            var tag1 = new Tag();
            tag1.Id = "1";
            tag1.Title = "Some Tag";

            var tag2 = new Tag();
            tag2.Id = "2";
            tag2.Title = "Other Tag";

            tags.Add(tag1);
            tags.Add(tag2);

            var wikiEntry = new WikiEntry(txtTitle.Text, txtContent.Text, "John Doe", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, "John Die", categories, tags);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetCategories(string search)
        {
            XDocument doc = XDocument.Load(@"C:\Users\KDRENSKI\source\repos\Wiki\Wiki\App_Data\Wiki.xml");

            var data = from x in doc.Descendants("Categories").Elements()
                .Where(p => p.Attribute("Title").Value
                .StartsWith(search))
                       select new
                       {
                           id = x.Attribute("Id").Value,
                           text = x.Attribute("Title").Value
                       };

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(data.ToList());
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetTags(string search)
        {
            XDocument doc = XDocument.Load(@"C:\Users\KDRENSKI\source\repos\Wiki\Wiki\App_Data\Wiki.xml");
            var data = from x in doc.Descendants("Tags").Elements()
                .Where(p => p.Attribute("Title").Value
                .StartsWith(search))
                       select new
                       {
                           id = x.Attribute("Id").Value,
                           text = x.Attribute("Title").Value
                       };

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(data.ToList());
        }

        [WebMethod]
        public static void SaveCategories(string categories)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = js.Deserialize<List<Category>>(categories.ToString());
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            List<Category> categories = new List<Category>();
            List<Tag> tags = new List<Tag>();

            foreach (var category in lbCategories.Items)
            {
                categories.Add(new Category()
                {
                    Id = 5.ToString(),
                    Title = category.ToString()
                });
            }
        }
    }
}