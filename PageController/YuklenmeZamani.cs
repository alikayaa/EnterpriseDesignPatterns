using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PageController
{
    //burada yazmış olduğumuz httpmodule' ümüz aynı zamanda bir Page controller' dır.
    //çünkü bütün sayfalarımıza istek gitmeden önce buradaki kod çalışacaktır.
    //biz burada bu HttpModule' yi her sayfamızın yüklenme zamanını ekrana yazdırmak
    //adına yaptık. Burda aldığımız süre değişkenimizi template view' imizde label' a 
    //basarız. Ancak burada sayfaya girişte yetki kontolü gibi daha karmaşık bir 
    //işlem de yaptırılabilirdi.
    public class YuklenmeZamani:IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            //istek başladığında ve bittiğinde çalışması fırlatılacak
            //olan eventlere burada abone alıp, toplam saniyeyi hesaplıyoruz.
            //hesapladığımız değeri htpp context nesnemizle sayfalarımıza geçiriyoruz. 
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
            
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;
            Stopwatch zaman = new Stopwatch();
            httpContext.Items["sure"] = zaman;
            zaman.Start();
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;
            Stopwatch zaman = (Stopwatch)httpContext.Items["sure"];
            zaman.Stop();
            if (httpContext.Response.ContentType == "text/html")
            {
                double sure = (double)zaman.ElapsedTicks / Stopwatch.Frequency;
                httpContext.Application["yuklenme"] = sure.ToString("0.00");

            }
        }
    }
}