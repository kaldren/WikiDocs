using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Wiki
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
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
    }
}