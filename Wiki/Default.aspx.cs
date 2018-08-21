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
        public static List<Category> categoriesList;
        public static List<Tag> tagsList;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string GetCategories(string search)
        {
            XDocument doc = XDocument.Load(@"C:\Users\KDRENSKI\source\repos\Wiki\Wiki\App_Data\Wiki.xml");

            var data = from x in doc.Descendants("Categories").Elements()
                .Where(p => p.Attribute("Text").Value
                .StartsWith(search))
                       select new
                       {
                           id = x.Attribute("Id").Value,
                           text = x.Attribute("Text").Value
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
                .Where(p => p.Attribute("Text").Value
                .StartsWith(search))
                       select new
                       {
                           id = x.Attribute("Id").Value,
                           text = x.Attribute("Text").Value
                       };

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(data.ToList());
        }

        [WebMethod]
        public static List<Category> SaveCategories(string categories)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = js.Deserialize<List<Category>>(categories.ToString());

            categoriesList = data;

            return data;
        }

        [WebMethod]
        public static List<Tag> SaveTags(string tags)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var data = js.Deserialize<List<Tag>>(tags.ToString());

            tagsList = data;

            return data;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            var wikiEntry = new WikiEntry(txtTitle.Text, txtContent.Text, "John Doe", DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, "John Die", categoriesList, tagsList);
            WikiDAL wikiDal = new WikiDAL(@"C:\Users\KDRENSKI\source\repos\Wiki\Wiki\App_Data\Wiki.xml");
            wikiDal.Add(wikiEntry);
            wikiDal.Save();
        }
    }
}