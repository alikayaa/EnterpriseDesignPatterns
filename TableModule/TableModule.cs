using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TableModule
{
    // Table Module Tasarım Kalıbı Sınıfı
    public class TableModule
    {
        // Veri
        protected DataTable table;
        // Yapıcı Fonksiyon
        protected TableModule(DataSet ds, String tableName)
        {
            table = ds.Tables[tableName];
        }
    }
}