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


            //var wikiEntry = new WikiEntry(txtTitle.Text,txtContent.Text, "John Doe", DateTimeOffset.UtcNow,DateTimeOffset.UtcNow,"John Die",;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static IEnumerable<object> GetCategories(string search)
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

            return data;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static IEnumerable<object> GetTags(string search)
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

            return data;
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