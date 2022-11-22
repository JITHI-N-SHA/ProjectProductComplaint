using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjectProductComplaint.User
{
    public partial class Complaint : System.Web.UI.Page
    {
        BAL.ComplaintBAL objprdtbl = new BAL.ComplaintBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                productid_bind();
            }
        }
        public void productid_bind()
        {
            DataTable prod = objprdtbl.ProductValues();
            DropDownList2.DataSource = objprdtbl.ProductValues();
            DropDownList2.DataTextField = "productid";
            DropDownList2.DataValueField = "productid";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("-- Select --", "0"));
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            objprdtbl.productid = Convert.ToInt32(DropDownList2.SelectedValue);
            objprdtbl.userid = Convert.ToInt32(Session["userid"]);
            objprdtbl.cmpmsg = cmpmsg.Text;
            int i = objprdtbl.complaint_reg();
            if (i == 1)
            {
                Response.Write("<script>alert('Complaint Registered Successfully');</script>");
            }
        }
    }
}






