using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XMLData
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
           // string path = Server.MapPath("students.xml");
            ds.ReadXml(Server.MapPath("students.xml"));
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "studentName";
            DropDownList1.DataValueField = "studentEnrollment";
            DropDownList1.DataBind();
        }
    }
}