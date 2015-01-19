using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Pessimistic
{
    public class Class1
    {
        public void MyMethod()
        {
            using (TransactionScope ts = new TransactionScope())
            { 
                //işlemlerimizi yapıyoruz....
                //işlemlerimizi yapıyoruz....
                ts.Complete();
            }

            using (var ts = new TransactionScope())
            {
                IsolationLevel isolationLevel = Transaction.Current.IsolationLevel;
                TimeSpan defaultTimeout = TransactionManager.DefaultTimeout;
                TimeSpan maximumTimeout = TransactionManager.MaximumTimeout;
            }

            var option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.ReadCommitted;
            option.Timeout = TimeSpan.FromMinutes(5);
            using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                //ExcuteSQL("CREATE TABLE Customer(Id int);");
                scope.Complete();
            } 

        
        }



    }
}
