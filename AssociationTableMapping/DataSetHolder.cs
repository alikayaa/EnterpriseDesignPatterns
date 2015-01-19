using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AssociationTableMapping
{
    public class DataSetHolder
    {
        public DataSet Data = new DataSet();
        private Hashtable DataAdapters = new Hashtable();
    }
}