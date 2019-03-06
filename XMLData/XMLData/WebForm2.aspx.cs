using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace XMLData
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = getRecord("getCource", null);
                DropDownList1.DataTextField = "cr_name";
                DropDownList1.DataValueField = "cr_id";
                DropDownList1.DataBind();    
            }
            
        }

        public DataSet getRecord(string spName, SqlParameter spParameter)
        {
            string con = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(spName, conn);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (spParameter != null)
                {
                    ad.SelectCommand.Parameters.Add(spParameter);
                }
                DataSet ds = new DataSet();
                ad.Fill(ds);
                conn.Close();
                return ds;

            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32( DropDownList1.SelectedValue.ToString());
            SqlParameter sp = new SqlParameter("@courceID", id);
            DropDownList2.DataSource = getRecord("getFaculty", sp);
            DropDownList2.DataTextField = "fc_name";
            DropDownList2.DataValueField = "fc_id";
            DropDownList2.DataBind(); 
        }

    }
}