using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace DynamicShowHidePreview {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.DataBind();
        }

        private DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("AdditionalField", typeof(string));
            for(int i = 0; i < 10; i++) {
                table.Rows.Add(i, "Item " + i.ToString(), "Description " + i.ToString() + " - long text memo in this field is displayed in the preview pane.", "An additional field " + i.ToString());
            }
            return table;
        }

        const string MoreInfoPrefix = "MoreInfoForRow_";
        private string GetKey(object key) {
            return string.Format("{0}{1}", MoreInfoPrefix, key);
        }

        protected bool IsPreviewVisible(object key) {
            object isVisible = Session[GetKey(key)];
            return true.Equals(isVisible);
        }

        protected string GetShortDescriptionText(int visibleIndex) {
            string fullDescription = (string)ASPxGridView1.GetRowValues(visibleIndex, "Description");
            string shortDescription = fullDescription;
            if(fullDescription != null && fullDescription.Length > 15)
                shortDescription = fullDescription.Substring(0, 15) + "...";
            return shortDescription;
        }

        protected void btnExpand_Click(object sender, EventArgs e) {
            ImageButton btn = (ImageButton)sender;
            Control table = btn.Parent.Parent.Parent; // button -> cell -> row -> table -> template container
            GridViewPreviewRowTemplateContainer container = (GridViewPreviewRowTemplateContainer)table.Parent;
            object key = container.KeyValue;
            Session[GetKey(key)] = !IsPreviewVisible(key);
            ASPxGridView1.DataBind();
        }
    }
}
