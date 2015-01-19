using Plugin.Engine;
using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace Plugin.Starter
{
    /// <summary>
    /// Ana hesap makinesi uygulamamız içinde plug-in'lerimizi çalıştıracak olan class'ımız.
    /// </summary>
    public static class PlugInDomain
    {
        public static List<ICommand> Start()
        {
            var setUp = new AppDomainSetup();
            setUp.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;

            // Kısıtlı ve güvenli olarak üretiyoruz.
            var permissionSet = new PermissionSet(PermissionState.None);
            // Çalıştırabilmek için yetki veriyoruz
            permissionSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            // Sadece gerekli klasörümüze keşife izin veriyoruz
            permissionSet.AddPermission
                (new FileIOPermission(FileIOPermissionAccess.PathDiscovery, AppDomain.CurrentDomain.BaseDirectory));
            // Sadece gerekli klasörümüze okuma izni veriyoruz
            permissionSet.AddPermission
                (new FileIOPermission(FileIOPermissionAccess.Read, AppDomain.CurrentDomain.BaseDirectory + "PlugIns"));
            // Gerekli bilgileri vererek domain ismi, kurulum bilgisi ve güvenlik izinleri gibi domainimizi üretiyoruz
            var plugInApplicationDomain = AppDomain.CreateDomain("Plug In App Domain", null, setUp, permissionSet); 
            
            // Diğer application domain'imizde PlugInEngine'mizi üretip bu objenin bize ObjectHandle bilgisini geriye döner.
            var plugInEngine = (PluginEngine)plugInApplicationDomain.CreateInstanceAndUnwrap
                (typeof(PluginEngine).Assembly.FullName, typeof(PluginEngine).FullName);

            return plugInEngine.LoadPlugInCommands();
        }
    }
}
