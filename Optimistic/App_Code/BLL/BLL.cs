using Optimistic.OptimisticConcurrencyTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Optimistic
{
    public class BLL
    {
        private CustomerTableAdapter _customersAdapter = null;
        protected CustomerTableAdapter Adapter
        {
            get
            {
                if (_customersAdapter == null)
                    _customersAdapter = new CustomerTableAdapter();
                return _customersAdapter;
            }
        }
        public OptimisticConcurrency.CustomerDataTable GetCustomers()
        {
            return Adapter.GetCustomer();
        }

        public bool DeleteCustomer(int original_customerID, string original_customerName, string original_customerSurname)
        {
            int rowsAffected = Adapter.Delete(original_customerID, original_customerName, original_customerSurname);
            // silme işlemi başarılı olursa geriye silinen toplam kayıt sayısını döner. Eğer bu sayı 1 ise başarılı 0 ise başarısız olmuş demektir.
            return rowsAffected == 1;
        }

  
        public bool UpdateCustomer(string customerName, string customerSurname,
            string original_customerName,
            string original_customerSurname,
            int original_customerID)
        {
            // Veri tabanından veriler okunur.
            OptimisticConcurrency.CustomerDataTable customers = Adapter.GetDataBy(original_customerID);
            if (customers.Count == 0)
                return false;
            OptimisticConcurrency.CustomerRow customer = customers[0];
            // Orjinal değerlerini customer nesnesine atıyoruz.
            customer.CustomerName = original_customerName;
            customer.CustomerSurname = original_customerSurname;
            //kontrolü yaptırıyoruz.
            customer.AcceptChanges();
            //yeni değerleri customer nesnesine atıyoruz.
            customer.CustomerName = customerName;
            customer.CustomerSurname = customerSurname;
            // customer'ı güncelliyoruz.
            int rowsAffected = Adapter.Update(customer);
            // eğer başarılı olursa etkilenen kayıt sayısı olarak 1 döner.
            //başarısız olursa 0
            return rowsAffected == 1;
        }
    }
}