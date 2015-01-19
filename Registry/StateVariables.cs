using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registry
{
    //bütün konfigürsayon değerlerini bir sınıf içerisinde tuttuğumuzu düşünelim.
    //onlarca değer olabileceğini düşünürseniz bu sınıfın ne kadar uzun olabileceğini
    //siz de tahmin edebilirsiniz
    public class StateVariables
    {
        private StateVariables() { }

        private static int conf1 = 0;
        private static int conf2 = 1500;
        private static int conf3 = 0;
        private static String conf4 = null;

        public static int getConf1() { return conf1; }
        public static int getConf2() { return conf2; }
        public static int getConf3() { return conf3; }
        public static String getConf4() { return conf4; }

        public static void setConf1(int o) { conf1 = o; }
        public static void setConf2(int l) { conf2 = l; }
        public static void setConf3(int m) { conf3 = m; }
        public static void setConf4(String a) { conf4 = a; }
    }
}
