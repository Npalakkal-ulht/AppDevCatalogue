using BusinessObjects;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppDevCatalogue
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AppDevCatalogueGridView_Init(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            //GridViewHelper.InitGridView(grid, "DeviceID", "Device");
            //GridViewHelper.InitGridViewPager(grid, "Device");
            //grid.DataSource = new BLL.ApplicationBLL().GetApplications();
            //grid.DataBind();

        }

        protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            var obj = e.InputParameters["Application"] as ApplicationBO;
            short test = Login.CookieHelper.GetCookieUserID();
            obj.EditedByUserID = (byte)test;
            obj.DateLastEdited = DateTime.Now;


        }
        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            var obj = e.InputParameters["Application"] as ApplicationBO;
            short test = Login.CookieHelper.GetCookieUserID();
            obj.CreatedByUserID = (byte)test;
            obj.DateCreated= DateTime.Now;


        }
        protected void AppDevCatalogueGridView_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            //short test = Login.CookieHelper.GetCookieUserID();
            //e.NewValues["CreatedByUserID"] = (byte)test;
            //e.NewValues["DateCreated"] = DateTime.Now;
            ASPxGridView grid = sender as ASPxGridView;
            if (e.ButtonType == ColumnCommandButtonType.Update)
                e.Text = grid.IsNewRowEditing ? "Insert" : "Update";
            
            //col.UpdateButton.Text = "Save";
            
            
        }



    }
}