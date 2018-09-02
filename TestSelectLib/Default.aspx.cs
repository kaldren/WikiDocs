using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace TestSelectLib
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetCategories()
        {
            XDocument doc = XDocument.Load(@"C:\Users\KDRENSKI\source\repos\Wiki\TestSelectLib\Data.xml");
            var data = from x in doc.Root.Descendants("Category")
                       select new
                       {
                           id = x.Attribute("Id").Value,
                           text = x.Attribute("Text").Value
                       };

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(data.ToList());
        }
    }
}