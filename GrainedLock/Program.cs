using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GrainedLock
{
    class Program
    {
        static void Main(string[] args)
        {
            DBIslem islem=new DBIslem();
            Thread birinci = new Thread(() => islem.OgrenciIslem());
            Thread ikinci = new Thread(() => islem.OgrenciIslem());
            birinci.Start();
            ikinci.Start();
            birinci.Join();
            ikinci.Join();
        }
    }
}
