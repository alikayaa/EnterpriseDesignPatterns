using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Optimistic
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //default olarak eğer birden fazla delete parametremiz varsa buradan eklememiz gerekiyor.
            ObjectDataSource1.DeleteParameters["original_customerName"].DefaultValue = e.Values["CustomerName"].ToString();
            ObjectDataSource1.DeleteParameters["original_customerSurname"].DefaultValue = e.Values["CustomerSurname"].ToString();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //eğer update ederken birden fazla değer where şartının içerisine girecekse buradan eklemeliyiz.
            ObjectDataSource1.UpdateParameters["original_customerName"].DefaultValue = e.OldValues["CustomerName"].ToString();
            ObjectDataSource1.UpdateParameters["original_customerSurname"].DefaultValue = e.OldValues["CustomerSurname"].ToString();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException != null)
            {
                if (e.Exception.InnerException is System.Data.DBConcurrencyException)
                {
                    //hata burada yakalanıp handle edilir eğer DBConcurrencyException hatası aldıysak
                    //o zaman conflict olmuş demektir. Hata mesajını gösteren label'ın visible'ını açalım.
                    DeleteConflictMessage.Visible = true;
                    e.ExceptionHandled = true;
                }
            }
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null && e.Exception.InnerException != null)
            {
                if (e.Exception.InnerException is System.Data.DBConcurrencyException)
                {
                    //hata burada yakalanıp handle edilir eğer DBConcurrencyException hatası aldıysak
                    //o zaman conflict olmuş demektir. Hata mesajını gösteren label'ın visible'ını açalım.
                    UpdateConflictMessage.Visible = true;
                    e.ExceptionHandled = true;
                }
            }
        }

        protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue != null && e.ReturnValue is bool)
            {
                bool deleteReturnValue = (bool)e.ReturnValue;
                if (deleteReturnValue == false)
                {
                    DeleteConflictMessage.Visible = true;
                }
            }
        }
    }
}