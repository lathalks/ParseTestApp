using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParseFileApp;

namespace ParseFileApp
{
    public partial class Home : System.Web.UI.Page
    {
        ParseFiles1 pf = null; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkParseCSV_Click(object sender, EventArgs e)
        {
            pf= new ParseFiles1();
          spnJsonResult.InnerHtml=  pf.ParseFromCSVToJSON();



        }

        protected void lnkParseXML_Click(object sender, EventArgs e)
        {
            pf= new ParseFiles1();
            pf.ParseFromXMLtoSQL();
        }
    }
}