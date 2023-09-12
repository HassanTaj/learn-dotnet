using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class myWebFourm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        // don't  need this if we impliment shit on button click
        //if (IsPostBack)
        //{
        //    string name = TextBox1.Text;
        //    string type = DropDownList1.SelectedValue;
        //    string filename = FileUpload1.FileName;
        //    // to - do record in db 
        //    FileUpload1.SaveAs(Server.MapPath("~/Content/" + filename));
        //    FeedBack.Text = "Submission Saved";
        //}

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;
        string type = DropDownList1.SelectedValue;
        string filename = FileUpload1.FileName;
        // to - do record in db 
        FileUpload1.SaveAs(Server.MapPath("~/Content/" + filename));
        FeedBack.Text = "Submission Saved";
    }
}